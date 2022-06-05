using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWineCooler.Manager;
using WineCoolerLib;

namespace RestWineCooler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoolerController : ControllerBase
    {
        private WineManager _manager = new WineManager();


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<Cooler>> GetAll()
        {
            List<Cooler> result = _manager.GetAllCoolers();
            if (result.Count() == 0)
            {
                NoContent();
            }
            return Ok(result);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Cooler> Get(int id)
        {
            //Cooler cooler = _manager.GetCooler(id);
            //if (cooler == null)
            //{
            //    NotFound();
            //}
            return Ok(_manager.GetCooler(id));
        }
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Cooler> Post([FromBody] Cooler newCooler)
        {
            Cooler createdCooler = new Cooler();
            if (newCooler.Temp > 50)
            {
                return BadRequest();
            }
            createdCooler = _manager.AddCooler(newCooler);
            return Created("api/Cooler/" + createdCooler.CoolerId, createdCooler);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public ActionResult<Cooler> Delete(int id)
        {
            Cooler coolerToBeDeleted = _manager.GetCooler(id);

            _manager.Delete(id);
            return Ok(coolerToBeDeleted);
        }

        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}/AddWine")]
        public ActionResult<int> AddWine([FromRoute]int id)
        {
            Cooler cooler = _manager.GetCooler(id);
            if (cooler.CoolerIsFull())
            {
                return Conflict();
            }
            int result = _manager.AddWine(id);
            //Den gode dokumentering.
            return  Ok("Bottles before: "  + (result- 1) + "    Bottles now: "  + result);
        }

    }
}
