using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Simple.Utility
    {
        public class BusinessFlowDAO
        {
            private NorthwindDbContext _db = null;

            public BusinessFlowDAO()
            {
                if (this._db == null)
                {
                    this._db = new NorthwindDbContext();
                }
            }
            public IEnumerable<Product> GetAllProducts()
            {
                return this._db.Products.ToList();
            }
            public IEnumerable<Product> GetLikeProducts(string productName)
            {
                return this._db.Products.Where(p => p.ProductName.Contains(productName)).ToList();
            }
            public Product Insert(Product product)
            {
                return this._db.Products.Add(product);
            }
            public IEnumerable<Product> Insert(IEnumerable<Product> products)
            {
                return this._db.Products.AddRange(products);
            }

            public Product Delete(Product product)
            {
                return this._db.Products.Remove(product);
            }

            public Product Update(Product product)
            {
                var query = this._db.Products.FirstOrDefault(p => p.ProductID == p.ProductID);
                if (query == null)
                {
                    return null;
                }
                this._db.Entry(query).CurrentValues.SetValues(product);
                return query;
            }

            public int? Commit()
            {
                try
                {
                    return this._db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }

}
