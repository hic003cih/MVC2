namespace MVC2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVC2.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC2.DAL.OnlineGameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC2.DAL.OnlineGameContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var students = new List<Gamer>
            {
                new Gamer { Id = 1,Name = "Carson",   Gender = "Male",
                    Score = 501,GameMoney=502,Age = 18},
                new Gamer { Id = 2,Name = "Ca",   Gender = "Male",
                    Score = 100,GameMoney=2,Age = 60},
                new Gamer { Id = 3,Name = "6666", Gender = "Male",
                    Score = 100,GameMoney=2,Age = 60}
            };
            students.ForEach(s => context.Gamers.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
        }
    }
}
