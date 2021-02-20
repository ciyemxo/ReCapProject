using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        //Costructor
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        //User authorization simulation
        bool userAuthorization = true;
        //Operations
        public void Add(Car car)
        {
            Car carToCheck = _carDal.GetById(car.Id);
            if (carToCheck != null)
            {
                Console.WriteLine("Id numarası kullanılıyor");
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Araba eklendi : " + car.Description + car.ModelYear);
            }
        }
        
        public void Delete(Car car)
        {
            
            if (userAuthorization == true)
            {
                _carDal.Delete(car);
                Console.WriteLine("Araba silindi : " + car.Description + car.ModelYear);
            }
            else
            {
                Console.WriteLine("Bu işlemi yapmaya yetkiniz yok.");
            } 
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.GetById(carId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araba güncellendi: " + car.Description);
        }
    }
}
