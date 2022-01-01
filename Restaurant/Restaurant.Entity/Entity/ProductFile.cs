using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class ProductFile : LittleEntity
    {
        public string File { get; set; }
        public string FileAlt { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
