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
