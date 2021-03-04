using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExceeded(carImage.CarId));


            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }



        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }


        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }



        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfImageIsNull(id));
        }



        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }



        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }







        private IResult CheckIfImageLimitExceeded(int id)
        {
            var result = _carImageDal.GetAll(i => i.CarId == id).Count;
            if (result>=5)
            {
                return new ErrorResult("En fazla 5 resim yüklenebilir.");
            }
            return new SuccessResult();
        }


        private IResult CheckIfCarExists(int id)
        {
            var result = _carService.GetById(id);
            if (result.Data == null)
            {
                return new ErrorResult("Bu Id numarası ile bir araç yok.");
            }
            return new SuccessResult();
        }


        private List<CarImage> CheckIfImageIsNull(int id)
        {
            var path = Environment.CurrentDirectory + @"\wwwroot\Images\Default.jpg";
            var result = _carImageDal.GetAll(i => i.CarId == id);
            if (!result.Any())
            {
                return new List<CarImage> { new CarImage { CarId = id, Date = DateTime.Now, ImagePath = path } };
            }
            return _carImageDal.GetAll(p=>p.CarId == id);
        }

       
    }
}
