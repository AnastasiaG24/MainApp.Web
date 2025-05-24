using eUseControl.Domain.Entities;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IRezervare
     {
          void SalveazaRezervare(Rezervare rezervare);
          void SalveazaOferta(RezervareOferta oferta);
     }

}
