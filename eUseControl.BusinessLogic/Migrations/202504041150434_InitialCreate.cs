namespace eUseControl.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oferts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAllIn = c.Boolean(nullable: false),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.UserDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 30),
                        CartId = c.Int(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        LastIp = c.String(maxLength: 30),
                        Level = c.Int(nullable: false),
                        Credential = c.String(),
                        Country = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .Index(t => t.CartId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDbTables", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Oferts", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.UserDbTables", new[] { "CartId" });
            DropIndex("dbo.Oferts", new[] { "Cart_Id" });
            DropTable("dbo.Carts");
            DropTable("dbo.UserDbTables");
            DropTable("dbo.Oferts");
        }
    }
}
