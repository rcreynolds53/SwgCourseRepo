namespace DvdLibrary.Data.Migrations
{
    using DvdLibrary.Models.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdLibrary.Data.DvdLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DvdLibrary.Data.DvdLibraryEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
           
            context.Dvds.AddOrUpdate(
                d => d.DvdId,
                new Dvd
                {
                    Title = "Braveheart",
                    ReleaseYear = 1995,
                    Rating = "R",
                    Director = "Mel Gibson",
                    Notes = "Freedddooommmm"
                },
                new Dvd
                {
                    Title = "Star Wars",
                    ReleaseYear = 1977,
                    Rating = "PG",
                    Director = "George Lucas",
                    Notes = "A long long time ago..."
                });

            context.SaveChanges();
        }
    }
}
