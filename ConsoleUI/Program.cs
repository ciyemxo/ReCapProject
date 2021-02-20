using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Add(new Car { Id = 6, BrandId = 2, ColorId = 7, DailyPrice = 432, ModelYear = 2009, Description = "Yeni eklenen Araba" });

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            Car carToDelete = carManager.GetById(1);
            carManager.Delete(carToDelete);

            //güncelleme kısmı
            var result = carManager.GetById(5);
            carManager.Update(result);
            result.Description = "güncellenen araba";

            //Hepsini listeleme kısmı
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

        }

    } 
}
