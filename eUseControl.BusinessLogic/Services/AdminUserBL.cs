using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System.Collections.Generic;
using System.Linq;

namespace eUseControl.BusinessLogic
{
     public class AdminUserBL : AdminApi, IAdminUser
     {
          public new List<UserDbTable> GetAllUsers()
          {
               return base.GetAllUsers();
          }
     }
}
