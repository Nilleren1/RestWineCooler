using System;

namespace WineCoolerLib
{
    public class Cooler
    {
        private int _coolerId;
        private int _capacityOfBottles;
        private int _temp;
        private int _bottlesInStorage;

        public int CoolerId
        {
            get => _coolerId;
            set => _coolerId = value;
        }

        public int CapacityOfBottles
        {
            get => _capacityOfBottles;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity",  "Capacity should not be null");
                }
                _capacityOfBottles = value;
            }
        }

        public int Temp
        {
            get => _temp;
            set
            {
                //Tror ikke der skal være noget her.
                _temp = value;
            }
        }

        public int BottlesInStorage
        {
            get => _bottlesInStorage;
            set
            {
                if (value >= 0 && value <= CapacityOfBottles)
                {
                    _bottlesInStorage = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
                
            }
        }

        public string Status
        {
            get
            {
                if (BottlesInStorage == 0)
                {
                    return "Empty";
                }

                if (CoolerIsFull())
                {
                    return "Full";
                }

                else
                {
                    return "Not Full";
                }
            }
        }


        public Cooler(int capacityOfBottles, int temp, int bottlesInStorage)
        {
            CapacityOfBottles = capacityOfBottles;
            Temp = temp;
            BottlesInStorage = bottlesInStorage;
        }

        public Cooler()
        {

        }

        public bool CoolerIsFull()
        {
            if (BottlesInStorage == CapacityOfBottles)
            {
                return true;
            }
            return false;
        }


        public int AddWine()
        {
            if (CoolerIsFull())
            {
                throw new ArgumentException("Is full.");
            }
            BottlesInStorage++;
            return BottlesInStorage;
        }

        public override string ToString()
        {
            return $"Capacity: {CapacityOfBottles}, Temperature: {Temp}, Bottles in Storage{BottlesInStorage}";
        }
    }
}


________________________________________________________________________________________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WineCoolerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCoolerLib.Tests
{
    [TestClass()]
    public class CoolerTests
    {
        [TestMethod()]
        public void CoolerIsNotFull()
        {
            //Arrange
            Cooler cooler = new Cooler(25, 14, 4);

            //Act
            bool result = cooler.CoolerIsFull();

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void CoolerIsFull()
        {
            //Arrange
            Cooler cooler = new Cooler(25, 14, 25);

            //Act
            bool result = cooler.CoolerIsFull();

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void CoolerModelException()
        {
            //Arrange
            Cooler cooler = new Cooler(25, 14, 23);

            //Act
            //cooler.CoolerIsFull();

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cooler.BottlesInStorage = 26);
        }

        [TestMethod()]
        public void AddWineTest()
        {
            //Arrange
            Cooler cooler = new Cooler(25, 14, 24);

            //Act
            cooler.AddWine();

            //Assert
            Assert.AreEqual(25, cooler.BottlesInStorage);
        }

        [TestMethod()]
        public void AddWineTestException()
        {
            //Arrange
            Cooler cooler = new Cooler(25, 14, 25);

            //Act
            //cooler.AddWine();

            //Assert
            Assert.ThrowsException<ArgumentException>(() => cooler.AddWine());
        }
    }
}
