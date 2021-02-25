using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
     
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        
        public IResult Add(Car car)
        {
            if (car.Description.Length<2)
            {
                return new ErrorResult(Messages.CarDesriptionInvalid);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new DataResult<Car> (_carDal.Get(c=> c.CarId == carId),true);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c=> c.BrandId == brandId),true);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId),true);
        }

        public IResult Update(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarDesriptionInvalid);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        




    }
}
