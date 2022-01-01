using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class SocialMedia : LittleEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }



    }
}
