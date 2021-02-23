using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1 , BrandId=1 , ColorId=1, DailyPrice=535, ModelYear= 2017 , Description= "BMW"},
                new Car {Id=2 , BrandId=2 , ColorId=5, DailyPrice=634, ModelYear= 2019 , Description= "Citroen"},
                new Car {Id=3 , BrandId=3 , ColorId=3, DailyPrice=223, ModelYear= 2015 , Description= "Fiat"},
                new Car {Id=4 , BrandId=4 , ColorId=3, DailyPrice=842, ModelYear= 2020 , Description= "Audi"},
                new Car {Id=5 , BrandId=5 , ColorId=4, DailyPrice=443, ModelYear= 2018 , Description= "Ford"},

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(cd => cd.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        //InMemory ihtiyacımız kalmadığı için buralar boş kalabilir
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;

            
        }
    }
}
