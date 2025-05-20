using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic
{
     public class RezervareBL : IRezervare
     {
          public void SalveazaRezervare(Rezervare rezervare)
          {
               using (var db = new UserContext())
               {
                    db.Rezervari.Add(rezervare);
                    db.SaveChanges();
               }
          }

          public void SalveazaOferta(RezervareOferta oferta)
          {
               using (var db = new UserContext())
               {
                    db.RezervariOferte.Add(oferta);
                    db.SaveChanges();
               }
          }
     }
}
