using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Global;
using eUseControl.Domain.Entities.Res;

namespace eUseControl.BusinessLogic.Interfaces
{
   public interface ISession
    {
        ActionStatus UserLogin(ULoginData data);

        LevelStatus CheckLevel(string key);
    }
}
