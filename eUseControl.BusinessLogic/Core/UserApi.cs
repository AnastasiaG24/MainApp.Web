using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User.Global;
using eUseControl.Domain.Entities.Product;
using eUseControl.BusinessLogic.DBModel;
using System.Linq;
using System;
using System.Collections.Generic;


namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        public bool UserSessionStatus()
        {
            return true;
        }
        internal ULoginResp UserSessionData(ULoginData data)
        {
            UDbTable result;
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password ==
                data.Password);
            }
            if (result == null)
            {
                return new ULoginResp
                {
                    Status = false,
                    StatusMsg = "The username or password is incorrect"
                };
            }
            return new ULoginResp { Status = true };
        }
    }
}
