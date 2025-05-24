using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic
{
     public class RezervareBL : UserApi, IRezervare
     {
          public new void SalveazaRezervare(Rezervare rezervare)
          {
               base.SalveazaRezervare(rezervare);
          }

          public new void SalveazaOferta(RezervareOferta oferta)
          {
               base.SalveazaOferta(oferta);
          }
     }
}
