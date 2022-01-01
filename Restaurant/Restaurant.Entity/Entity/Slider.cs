using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class Slider : LittleEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public string FileAlt { get; set; }
        public string PageUrl { get; set; }
        public string ProductUrl { get; set; }
        public bool Left { get; set; }
        public bool Center { get; set; }
        public bool Right { get; set; }
        public string LezzetUrl { get; set; }
        public string Slug { get; set; }
    }
}
