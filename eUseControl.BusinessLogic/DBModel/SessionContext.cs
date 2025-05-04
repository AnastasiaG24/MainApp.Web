using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel
{
     public class SessionContext : DbContext
     {
          public DbSet<Session> Sessions { get; set; }

          public SessionContext() : base("name=DefaultConnection")
          {
          }
     }
}
