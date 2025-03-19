using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.Res;
using eUseControl.Domain.Entities.User.Global;
using eUseControl.Domain.Entities.Product;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        public ActionStatus UserLogData(ULoginData data)
        {
            return new ActionStatus();
        }

        internal LevelStatus CheckLevelLogic(string keySession)
        {
            return new LevelStatus();
        }

        internal ProductDetail GetProdUser(int id)
        {
            return new ProductDetail();
        }
    }
}