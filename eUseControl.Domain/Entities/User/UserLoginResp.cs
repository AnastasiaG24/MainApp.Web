namespace eUseControl.Domain.Entities.User
{
     public class UserLoginResp
     {
          public bool Status { get; set; }
          public string StatusMessage { get; set; }
          public UserDbTable UserData { get; set; }
     }
}
