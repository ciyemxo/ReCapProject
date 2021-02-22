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
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(
                new Car { Id=1 ,
                    BrandId = 1,
                    ColorId= 1 ,
                    ModelYear = 2021,
                    DailyPrice = 450,
                    Description = "Renault Megane 1.0 Joy 2021 Model Kırmızı"}
                );

 

        }

    } 
}
