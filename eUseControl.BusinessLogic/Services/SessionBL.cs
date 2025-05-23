﻿using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;

namespace eUseControl.BusinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public new UserLoginResp UserLogin(UserLoginData data)
          {
               return base.UserSessionData(data);
          }

          public new LevelStatus CheckLevel(string key)
          {
               return base.CheckLevel(key);
          }
     }
}
