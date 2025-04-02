using eUseControl.BusinessLogic.Interfaces;

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
     }
}
