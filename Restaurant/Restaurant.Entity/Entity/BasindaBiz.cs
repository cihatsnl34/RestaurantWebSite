using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class BasindaBiz : SeoEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public string Slug { get; set; }
        public string ShortDescription { get; set; }
    }
}
