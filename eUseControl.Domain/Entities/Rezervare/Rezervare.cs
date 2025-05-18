using System;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Domain.Entities
{
    public class Rezervare
    {
        public int Id { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Destinatie { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DataPlecare { get; set; }
    }
}
