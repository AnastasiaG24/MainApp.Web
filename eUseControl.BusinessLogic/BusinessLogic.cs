using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic;

namespace eUseControl.BusinessLogic
{
     public class BusinessLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }

          public IUserOfert GetProductBL()
          {
               return new ProductBL();
          }
          public IAdminUser GetAdminUserBL()
          {
               return new AdminUserBL(); 
          }
          public IRezervare GetRezervareBL()
          {
               return new RezervareBL();
          }

     }
}
