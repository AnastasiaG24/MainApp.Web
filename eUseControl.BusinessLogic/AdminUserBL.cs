using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System.Collections.Generic;
using System.Linq;

namespace eUseControl.BusinessLogic
{
     public class AdminUserBL : IAdminUser
     {
          public List<UserDbTable> GetAllUsers()
          {
               using (var db = new UserContext())
               {
                    return db.Users.ToList();
               }
          }
     }
}
