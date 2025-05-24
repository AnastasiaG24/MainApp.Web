using eUseControl.Domain.Entities.User;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IAdminUser
     {
          List<UserDbTable> GetAllUsers();
     }
}
