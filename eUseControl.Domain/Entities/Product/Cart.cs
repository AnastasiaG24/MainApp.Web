using System.Collections.Generic;

namespace eUseControl.Domain.Entities.Product
{
     public class Cart
     {
          public int Id { get; set; }
          public int UserId { get; set; }
          public List<Ofert> Oferts { get; set; }
     }
}
