using System;
using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int CarId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
