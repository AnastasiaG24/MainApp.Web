using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic.Services;

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
            return new OffertBL();
        }
        public IAdminUser GetAdminUserBL()
        {
            return new AdminUserBL();
        }
        public IRezervare GetRezervareBL()
        {
            return new RezervareBL();
        }

        public IAdminOfert GetAdminOfertBL()
        {
            return new AdminOffertBL();
        }

        public IAdminRezervare GetAdminRezervareBL()
        {
            return new AdminRezervareBL();
        }
     }
}
