using System;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Domain.Entities
{
    public class RezervareOferta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Email { get; set; }

        public string Cerere { get; set; }

        public int NumarPersoane { get; set; }

        public string Destinatie { get; set; }

        public DateTime DataRezervare { get; set; } = DateTime.Now;

        public bool Aprobat { get; set; } = false;
        public bool Respins { get; set; }
    }
}
