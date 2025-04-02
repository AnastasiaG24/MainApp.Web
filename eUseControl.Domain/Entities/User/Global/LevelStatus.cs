using eUseControl.Domain.Enums;
using System;

namespace eUseControl.Domain.Entities.User.Global
{
     public class LevelStatus
     {
          public URole Level { get; set; }
          public DateTime SessionTime { get; set; }
     }
}
