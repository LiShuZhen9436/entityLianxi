namespace entityLianXi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<entityLianXi.Models.ProductEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "entityLianXi.Models.ProductEntity";
        }

        protected override void Seed(entityLianXi.Models.ProductEntity context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
