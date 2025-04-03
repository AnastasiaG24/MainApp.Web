using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;

namespace eUseControl.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public UserLoginResp UserLogin(UserLoginData data)
          {
               return base.UserSessionData(data);
          }

          public LevelStatus CheckLevel(string key)
          {
               return base.CheckLevel(key);
          }
     }
}
