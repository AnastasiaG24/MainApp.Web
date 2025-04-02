using eUseControl.Domain.Entities.User;
using System.Data.Entity;

namespace eUseControl.BusinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() : base("name = eUseControl") //conection string name define in your web.config
          {

          }
          public virtual DbSet<UserDbTable> Users { get; set; }
     }
}

