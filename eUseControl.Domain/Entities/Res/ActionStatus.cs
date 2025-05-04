using eUseControl.Domain.Entities.User;

namespace eUseControl.Domain.Entities.Res
{
     public class ActionStatus
     {
          public bool Status { get; set; }
          public string StatusMessage { get; set; }
          public string SessionKey { get; set; }
          public UserDbTable User { get; set; }
     }
}
