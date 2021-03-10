using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
     
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }



        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,car.add")]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }



        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }



        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }


        //PerformanceAspect, AspectInterceptorSelector içine taşındı.
        [CacheAspect]
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

        

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }



        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult();
        }



    }
}
