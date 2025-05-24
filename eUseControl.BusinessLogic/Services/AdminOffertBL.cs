using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Services
{
     public class AdminOffertBL : AdminApi, IAdminOfert
     {
          public new void AddOfert(Ofert ofert)
          {
               base.AddOfert(ofert);
          }

          public new void DeleteOfertById(int id)
          {
               base.DeleteOfertById(id);
          }

          public List<Ofert> GetAllOferts()
          {
               return base.GetAllOferts();
          }

          public Ofert GetOfertById(int id)
          {
               return base.GetOfertById(id);
          }

          public void UpdateOfert(Ofert ofert)
          {
               base.UpdateOfert(ofert);
          }
     }
}
