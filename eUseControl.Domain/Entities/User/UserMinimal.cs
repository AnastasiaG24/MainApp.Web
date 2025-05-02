using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
     public class UserMinimal
     {
          public string Username { get; set; }
          public string Role { get; set; }
          public string SessionKey { get; set; }
     }
}
