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
            GetCarDetails();

            //AddUser();

            //AddCustomer();

            //AddCar();

            //AddRental();

        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = DateTime.UtcNow,
                ReturnDate = new DateTime(2021, 2, 27)

            }); Console.WriteLine(result.Message);
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 5,
                ColorId = 2,
                ModelId = 5,
                ModelYear = 2018,
                DailyPrice = 365,
                Description = "aile arabası, konforlu"

            });
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
                UserId = 3,
                CompanyName = "SAL & CO"
            });
        }

        private static void AddUser()
        {
            UserManager customerManager = new UserManager(new EfUserDal());
            customerManager.Add(
                new User
                {
                    FirstName = "Sabrina",
                    LastName = "Claudio",
                    Email = "confidentlylost@hotmail.com",
                    Password = "iminsanelol",

                });
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "-" + car.ColorName + "-" + car.Description + "     Fiyatı: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }

}
