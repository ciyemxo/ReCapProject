using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddColor();

            //AddBrand();

            //AddNewCar();

            //ListAllCars();

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + "-" + car.ColorName + "-" + car.Description +  "     Fiyatı: " + car.DailyPrice);
            }

        }//extract edilmiş methodlar

        private static void ListAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }


        //Araba ekleme methodu
        private static void AddNewCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                Id = 4,
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 525,
                ModelYear = 2016,
                Description = "Audi TT Coupe 2.0 Quattro S-Tronic"
            });
        }

        //marka ekleme methodu
        private static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 6, BrandName = "Kia" });
        }

        //renk ekleme methodu
        private static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(
                new Color { ColorId = 5, ColorName = "Lacivert" });
        }
    } 
}
