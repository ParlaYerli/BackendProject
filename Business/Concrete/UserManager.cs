using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal _userDal)
        {
            this._userDal = _userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(i => i.Email == email);
        }

        public List<OperationClaim> GetClaim(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
