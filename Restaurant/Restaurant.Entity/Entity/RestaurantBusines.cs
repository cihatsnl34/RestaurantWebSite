using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class RestaurantBusines:LittleEntity
    {
        public string Tittle { get; set; }
        public string Content { get; set; }
        public int Rank { get; set; }
    }
}
