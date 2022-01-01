using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class ContactInformation : LittleEntity
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
