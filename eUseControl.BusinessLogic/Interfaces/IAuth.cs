﻿using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IAuth
    {
        ActionStatus UserLogin(UserLoginData data);
        bool CreateUser(UserRegisterData register);

    }
}
