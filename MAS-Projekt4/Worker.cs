using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace MAS_Projekt4
{
    class Worker
    {
        private string _name;
        private string _surname;
        private string _idCard;
        private static readonly IComparer<Car> comparer = new Compare();
        private SortedSet<Car> _carSet = new SortedSet<Car>(comparer);
        private SortedSet<Car> _brokenCars = new SortedSet<Car>(comparer);
        
        public Worker(string name, string surname, string idCard)
        {
            _name = name;
            _surname = surname;
            _idCard = idCard;
        }

        public void AddCar(Car car)
        {
            if (_carSet.Contains(car))
                return;
            if(!(car.GetWorker() == null || car.GetWorker() == this))
            {
                throw new Exception("Inny pracownik zostal przypisany do samochodu"); //
            }
            else
            {
                _carSet.Add(car);
                car.SetWorker(this);
            }
        }
        public void AddBrokenCar(Car car)
        {
            if(car == null)
            {
                throw new Exception("Car is null");
            }
            if (_carSet.Contains(car))
            {
                _brokenCars.Add(car);
            }
            else
            {
                throw new Exception(String.Format("Car is not in CarSet", car));
            }
        }
        public SortedSet<Car> GetCars()
        {
            return _carSet;
        }
        public SortedSet<Car> GetBrokenCars()
        {
            return _brokenCars;
        }

        public void removeCar(Car car)
        {
            if (_carSet.Contains(car))
            {
                _carSet.Remove(car);
            }
        }
        public override string ToString()
        {
            return _name + " " +_surname+ " " +_idCard + Environment.NewLine + string.Join("",_carSet) ;
        }
        class Compare : IComparer<Car>
        {
            int IComparer<Car>.Compare(Car x, Car y)
            {
                return (x.GetPrice().CompareTo(y.GetPrice()));
            }
        }
    }
}
