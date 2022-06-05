using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineCoolerLib;

namespace RestWineCooler.Manager
{
    public class WineManager
    {
        private static int _nextId = 1;
        //Cooler tilføjet via dll fil reference.
        private static List<Cooler> coolersList = new List<Cooler>()
        {
            new Cooler() {CoolerId = _nextId++, Temp = 15, CapacityOfBottles = 20, BottlesInStorage = 11},
            new Cooler() {CoolerId = _nextId++, Temp = 12, CapacityOfBottles = 10, BottlesInStorage = 2},
            new Cooler() {CoolerId = _nextId++, Temp = 13, CapacityOfBottles = 30, BottlesInStorage = 13},
            new Cooler() {CoolerId = _nextId++, Temp = 14, CapacityOfBottles = 20, BottlesInStorage = 5},
        };

        public List<Cooler> GetAllCoolers()
        {
            return coolersList;
        }

        public Cooler GetCooler(int id)
        {
            return coolersList.Find(c => c.CoolerId == id);
        }

        public Cooler AddCooler(Cooler cooler)
        {
            cooler.CoolerId = _nextId++;
            coolersList.Add(cooler);
            return cooler;
        }

        public Cooler Delete(int id)
        {
            Cooler coolerToBeDeleted = GetCooler(id);
            coolersList.Remove(coolerToBeDeleted);
            return coolerToBeDeleted;
        }

        public int AddWine(int coolerId)
        {
            Cooler cooler = GetCooler(coolerId);

            int result = cooler.AddWine();

            return result;
        }
    }
}
