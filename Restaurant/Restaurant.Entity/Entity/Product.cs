using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class Product : SeoEntity
    {
        public Product()
        {
            this.ProductFiles = new HashSet<ProductFile>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public string Feature { get; set; }
        public bool HomePageIsActive { get; set; }
        public string FileAlt { get; set; }
        public string ShortDescription { get; set; }
        public string ProductIndex { get; set; }
        public string StorageCondition { get; set; }
        public string ServiceReco { get; set; }
        public string Energy { get; set; }
        public string Yag { get; set; }
        public string DoymusYag { get; set; }
        public string Karbonhidrat { get; set; }
        public string Protein { get; set; }
        public string Tuz { get; set; }
        public string Allergen { get; set; }
        public string Sugar { get; set; }
        public int Rank { get; set; }
        public string Slug { get; set; }
        public string KayıtNo { get; set; }
        public string Mensei { get; set; }
        public string NetGram { get; set; }
        public int ProductCategoryID { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
    }
}
