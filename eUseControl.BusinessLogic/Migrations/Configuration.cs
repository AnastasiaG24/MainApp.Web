namespace eUseControl.BusinessLogic.Migrations
{
     using System.Data.Entity.Migrations;

     internal sealed class Configuration : DbMigrationsConfiguration<eUseControl.BusinessLogic.DBModel.UserContext>
     {
          public Configuration()
          {
               AutomaticMigrationsEnabled = false;
          }

          protected override void Seed(eUseControl.BusinessLogic.DBModel.UserContext context)
          {
               //  This method will be called after migrating to the latest version.

               //  You can use the DbSet<T>.AddOrUpdate() helper extension method
               //  to avoid creating duplicate seed data.
          }
     }
}
