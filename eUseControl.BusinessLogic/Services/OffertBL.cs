using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic
{
     class OffertBL :UserApi, IUserOfert
     {
          public new List<Ofert> GetAllOferts()
          {
              return base.GetAllOferts();
          }

          public new Ofert GetOfertById(int id)
          {
              return base.GetOfertById(id);
          }
     }
}
