using eUseControl.Domain.Entities.Product;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IUserOfert
     {
          Ofert GetOfertById(int id);
          List<Ofert> GetAllOferts();

     }

     public interface IAdminOfert : IUserOfert
     {
          void AddOfert(Ofert ofert);
          void UpdateOfert(Ofert ofert);
          void DeleteOfertById(int id);
     }
}
