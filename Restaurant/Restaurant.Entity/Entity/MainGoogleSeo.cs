using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class MainGoogleSeo : SeoEntity
    {
        public string PageName { get; set; }
        public string PageUrl { get; set; }
        public bool LargeDropDown { get; set; }
        public bool SmallDropDown { get; set; }
        public int Rank { get; set; }
        public string File { get; set; }
    }
}
