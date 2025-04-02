using System;

namespace eUseControl.Domain.Entities.Product
{
     public class Ofert
     {
          public int Id { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public DateTime StartDate { get; set; }
          public DateTime EndDate { get; set; }
          public decimal Price { get; set; }
          public bool IsAllIn { get; set; }
     }
}
