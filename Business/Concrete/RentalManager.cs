using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {

            var carToAdd = _rentalDal.Get(r => r.CarId == rental.CarId);
            
            if (carToAdd == null || carToAdd.ReturnDate < DateTime.Now )
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.ProcedureSuccessful);
                
            }
            return new ErrorResult(Messages.CarIsNotReturned);

            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ProcedureSuccessful);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ProcedureSuccessful);
        }
    }
}
