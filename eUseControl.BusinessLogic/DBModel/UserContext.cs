﻿using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Product;
using eUseControl.Domain.Entities.User;
using System.Data.Entity;

namespace eUseControl.BusinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() : base("name = DefaultConnection") { }
          public virtual DbSet<UserDbTable> Users { get; set; }
          public virtual DbSet<Ofert> Oferts { get; set; }
          public DbSet<Rezervare> Rezervari { get; set; }
          public DbSet<RezervareOferta> RezervariOferte { get; set; }

          public System.Data.Entity.DbSet<eUseControl.Domain.Entities.Product.Cart> Carts { get; set; }
     }
}

