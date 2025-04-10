using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IAuth
     {
          ActionStatus UserLogin(UserLoginData data);
          bool RegisterUser(UserRegisterData register);
     }
}
