using System;
using System.ComponentModel;
using System.Dynamic;
using System.Linq.Expressions;

namespace MAS_Projekt4
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker1 = new Worker("Rav","Lagsownki","MSW-567");
            try{
                Car car = new Car(1, 2000.5, 22500, "Audi");
                Car car1 = new Car(2, 2244.57, 30000.00, "BMW");
                Car brokenCar = new Car(3, 3000.8, 25000, "A");
                car.SetMileage(300000); //ograniczenie dynamiczne
                car.SetPrice(20000); //ogarniczenie statyczne
                Console.WriteLine(Car.GetCarById(1)); //ograniczenie unique id
                worker1.AddCar(car);
                worker1.AddCar(car1); //ograniczenie Ordered, asocjacja pomiedzy Pracownikiem a samochodem "opiekuje się", ograniczenie sortuje po cenie i "przechowuje" samochody przypisane do pracownika. 
                worker1.AddCar(brokenCar);
                Console.WriteLine(string.Join("",worker1.GetCars()));
                worker1.AddBrokenCar(brokenCar); //ograniczenie subset, praconiwk również opikuje się samochodami zepsutymi, ktore sa do naprawy
                Console.WriteLine(worker1); 
            }
            catch (Exception ex)
               {
                throw;
               }
               
        
        }
    }
}
