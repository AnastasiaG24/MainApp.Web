using eUseControl.Domain.Entities.Product;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IUserOfert
     {
          Ofert GetOfertById(int id);
          List<Ofert> GetAllOferts();
     }
}
