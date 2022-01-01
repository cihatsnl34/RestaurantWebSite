using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class Video : LittleEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public string Url { get; set; }
    }
}
