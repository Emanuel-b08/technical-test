using System;
using System.Collections.Generic;
using System.Linq;

namespace technical__test
{
    public class ProductController
    {
        public List<Product> GetAll(string filtro = "")
        {
            using (var db = new MiDbContext())
            {
                var query = db.Product.AsQueryable();
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    query = query.Where(p => p.Name.Contains(filtro));
                }
               return query.ToList();
            }
        }

        public Product GetById(int id)
        {
            using (var db = new MiDbContext())
            {
                return db.Product.Find(id);
            }
        }

        public void Save(Product prod)
        {
            using (var db = new MiDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (prod.ProductID == 0)
                    {
                        prod.GuidCode = Guid.NewGuid();
                        prod.CreationDate = DateTime.Now;
                        db.Product.Add(prod);
                    }
                    else
                    {
                        prod.ModificationDate = DateTime.Now;
                        db.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                    }

                    db.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new MiDbContext())
            {
                var prod = db.Product.Find(id);
                if (prod != null)
                {
                    db.Product.Remove(prod);
                    db.SaveChanges();
                }
            }
        }
    }
}
