using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ActionStatus UserLogin(UserLoginData data);


          LevelStatus CheckLevel(string key);
     }
}
