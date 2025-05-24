using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Product;
using System.Collections.Generic;

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
        public new List<RezervareOferta> GetRezervariByUsername(string username)
        {
            return base.GetRezervariByUsername(username);
        }
    }
}
