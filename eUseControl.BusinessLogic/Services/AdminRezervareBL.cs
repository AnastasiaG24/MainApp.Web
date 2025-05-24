using eUseControl.BusinessLogic.Core;
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
    internal class AdminRezervareBL : AdminApi, IAdminRezervare
    {
        public new void SalveazaOferta(RezervareOferta oferta)
        {
            base.SalveazaOferta(oferta);
        }

        public new void SalveazaRezervare(Rezervare rezervare)
        {
            base.SalveazaRezervare(rezervare);
        }
    }
}
