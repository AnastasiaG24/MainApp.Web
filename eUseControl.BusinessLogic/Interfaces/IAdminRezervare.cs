using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IAdminRezervare : IRezervare
    {
        List<RezervareOferta> GetAllRezervari();
        void AprobaRezervare(int id);
        void RespingeRezervare(int id);
        void SalveazaRezervare(Rezervare rezervare);
        void SalveazaOferta(RezervareOferta oferta);
    }
}
