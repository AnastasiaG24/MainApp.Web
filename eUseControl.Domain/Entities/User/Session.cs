using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
     public class Session
     {
          public int Id { get; set; }
          public string Username { get; set; }
          public string CookieString { get; set; }
          public DateTime ExpireTime { get; set; }
     }
}
