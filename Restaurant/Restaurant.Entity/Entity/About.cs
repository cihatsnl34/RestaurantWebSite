using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class About : LittleEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public string FileAlt { get; set; }
        public string ShortDescription { get; set; }
    }
}
