using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace technical__test
{
    public class MiDbContext : DbContext
    {
        public MiDbContext() : base("name=MiConexion")
        {
        }


        public DbSet<Product> Product { get; set; }

        // Sobrescribimos SaveChanges para actualizar fechas automáticamente
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Product &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((Product)entityEntry.Entity).ModificationDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((Product)entityEntry.Entity).CreationDate = DateTime.Now;
                }
            }

            return base.SaveChanges();

           
        }
    }
}

