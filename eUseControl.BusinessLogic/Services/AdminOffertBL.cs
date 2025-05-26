using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.DBModel;
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
        public virtual void AddOfert(Ofert ofert)
        {
            using (var db = new UserContext())
            {
                db.Oferts.Add(ofert);
                db.SaveChanges(); 
            }
        }

        public new void DeleteOfertById(int id)
          {
               base.DeleteOfertById(id);
          }

          public new List<Ofert> GetAllOferts()
          {
               return base.GetAllOferts();
          }

          public new Ofert GetOfertById(int id)
          {
               return base.GetOfertById(id);
          }

          public new void UpdateOfert(Ofert ofert)
          {
               base.UpdateOfert(ofert);
          }
     }
}
