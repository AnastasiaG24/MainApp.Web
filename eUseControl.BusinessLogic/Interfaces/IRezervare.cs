using eUseControl.Domain.Entities;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IRezervare
    {
        void SalveazaRezervare(Rezervare rezervare);
        void SalveazaOferta(RezervareOferta oferta);
        List<RezervareOferta> GetRezervariByUsername(string username);
     }

}
