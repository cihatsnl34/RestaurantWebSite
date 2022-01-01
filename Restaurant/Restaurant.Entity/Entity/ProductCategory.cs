using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class ProductCategory : SeoEntity
    {
        public ProductCategory()
        {
            this.Products = new HashSet<Product>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
        public string Slug { get; set; }
        public int Rank { get; set; }
        public string File { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
