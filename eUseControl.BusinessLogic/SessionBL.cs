using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;

namespace eUseControl.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public ActionStatus UserLogin(UserLoginData data)
          {
               return UserSessionData(data);
          }

          public LevelStatus CheckLevel(string key)
          {
               return CheckLevelLogic(key);
          }
     }
}
