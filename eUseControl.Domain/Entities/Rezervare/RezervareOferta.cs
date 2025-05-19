using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities
{
    public class RezervareOferta
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string CereriSpeciale { get; set; }
        public int NrPersoane { get; set; }
        public string Destinatie { get; set; }
        public decimal Pret { get; set; } 
        public int Zile { get; set; } 
        public DateTime DataRezervare { get; set; }
    }
}