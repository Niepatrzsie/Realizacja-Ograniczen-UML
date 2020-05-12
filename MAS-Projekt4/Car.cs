using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace MAS_Projekt4
{
    class Car
    {
        private double _mileage;
        private double _price;
        private string _brand;
        public readonly static double minimumPrice = 15000.0;
        private int _idCar; //unique
        private readonly static Dictionary<int, Car> _idMap = new Dictionary<int, Car>();
        private Worker _worker;
        public Car(int idCar,double mileage, double price, string brand)
        {
            if(mileage < 0 || price < 0)
            {
                throw new Exception("Milage or Price cannot be smaller than 0");
            }
            if (_idMap.ContainsKey(idCar))
            {
                throw new Exception("this id Car number already exists");
            }
            _idCar = idCar;
            _mileage = mileage;
            _price = price;
            _brand = brand;
            _idMap.Add(_idCar, this);
        }
        public double GetMileage()
        {
            return _mileage;
        }
        public double GetPrice()
        {
            return _price;
        }
        public string GetBrand()
        {
            return _brand;
        }
        //ograniczenie dynamiczne - zalezy od stanu atrybutu poprzeniego (przebieg nie moze się zmieniszyć)
        public void SetMileage(double milage)
        {
            if(milage < _mileage)
            {
                throw new Exception("The milage cannot change to a smaller one");
            }
            _mileage = milage;
        }
        //ograniczenie statyczne - niezalezy od poprzedniego stanu atrybutu nie ma to znaczenia
        public void SetPrice(double price)
        {
            if(price < minimumPrice)
            {
                throw new Exception("The new price cannot be smaller than minimum price");
            }
            _price = price;
        }
        public static Car GetCarById(int id)
        {
            Car car;
            if(_idMap.TryGetValue(id,out car))
            {
                return car;
            }
            else
            {
                throw new Exception("Could not find the specified key.");
            }
        }
        public static void RemoveCarById(int id)
        {
            if (_idMap.ContainsKey(id))
            {
                _idMap.Remove(id);
            }
            else
            {
                Console.WriteLine("Key \"id\" is not found.");
            }
        }
        public void SetWorker(Worker worker)
        {
            _worker = worker;
        }
        public Worker GetWorker()
        {
            return _worker;
        }
        public override string ToString()
        {
            return "Brand " + _brand + ", Milage " + _mileage + ", Price " + _price +" USD " + Environment.NewLine;
        }
  
        
    }
}
