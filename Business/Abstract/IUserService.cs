using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> Getall();
        IDataResult<List<User>> GetbyUserId(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        User GetByMail(string email);


        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
