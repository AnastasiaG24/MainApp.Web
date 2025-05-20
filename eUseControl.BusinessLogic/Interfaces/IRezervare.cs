using eUseControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interfaces
{
     public interface IRezervare
     {
          void SalveazaRezervare(Rezervare rezervare);
          void SalveazaOferta(RezervareOferta oferta);
     }

}
