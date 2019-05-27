using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MVC2.Models;

namespace MVC2.DAL
{
    public class OnlineGameContext : DbContext
    {
        public OnlineGameContext() : base("OnlineGameDBContext")
        {

        }

        public DbSet<Gamer> Gamers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    
}