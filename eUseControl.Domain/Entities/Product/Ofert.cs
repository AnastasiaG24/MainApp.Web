using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eUseControl.Domain.Entities.Product
{
     public class Ofert
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          [Display(Name = "Username")]
          [StringLength(30, MinimumLength = 5, ErrorMessage = "Username cannot be longer than 30 characters.")]
          public string Name { get; set; }
          public string Description { get; set; }
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
          public decimal Price { get; set; }
          public bool IsAllIn { get; set; }
     }
}
