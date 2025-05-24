using eUseControl.Domain.Entities.Product;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IAdminOfert : IUserOfert
     {
          void AddOfert(Ofert ofert);
          void UpdateOfert(Ofert ofert);
          void DeleteOfertById(int id);
     }

}
