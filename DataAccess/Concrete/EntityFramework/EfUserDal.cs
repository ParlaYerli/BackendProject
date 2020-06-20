using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; // eklemezsen hata veriyor.
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Concrete.Context;
using DataAccess.Abstract;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            // burada OperationClaim ile UserOperationClaim tablosu join ediliyor.Kullanıcın sahip olduğu yetkileri çekmek istiyorum o yüzden join edilmesi gerek
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}