using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class HumanResources :LittleEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //<a href="dosyayolu/File"><img src="/Content/Site/pdf.png" width="120"></a>
        public string File { get; set; }
        public string Subject { get; set; }
        public string Messages { get; set; }
    }
}
