using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Services
{
     public class AdminRezervareBL : AdminApi, IAdminRezervare
     {
          public new void SalveazaOferta(RezervareOferta oferta)
          {
               base.SalveazaOferta(oferta);
          }
          public new void SalveazaRezervare(Rezervare rezervare)
          {
               base.SalveazaRezervare(rezervare);
          }
          public new List<RezervareOferta> GetAllRezervari()
          {
               return base.GetAllRezervari();
          }
          public new void AprobaRezervare(int id)
          {
               base.AprobaRezervare(id);
          }
          public new void RespingeRezervare(int id)
          {
               base.RespingeRezervare(id);
          }
          public new List<RezervareOferta> GetRezervariByUsername(string username)
          {
               return base.GetRezervariByUsername(username);
          }
     }
}
