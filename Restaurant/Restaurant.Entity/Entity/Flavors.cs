using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class Flavors:LittleEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public int Rank { get; set; }
        public string pageUrl { get; set; }
        public string haberUrl { get; set; }
        public string basinUrl { get; set; }
        public string kategoriUrl { get; set; }
        public string urunUrl { get; set; }
    }
}
