using System;

namespace eUseControl.Domain.Entities.User
{
     public class UserLoginData
     {
          public string Credential { get; set; }
          public string Password { get; set; }
          public string LoginIp { get; set; }
          public DateTime LoginDataTime { get; set; }
     }
}
