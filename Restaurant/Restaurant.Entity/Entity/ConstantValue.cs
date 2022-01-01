using Restaurant.Entity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.Entity
{
    public class ConstantValue : LittleEntity
    {
        //Zorunlu Alan
        public string ImageUrl { get; set; }
        //Zorunlu Alan
        public string ImageAlt { get; set; }
        //Zorunlu Alan Değil
        public string Title { get; set; }
        //Zorunlu Alan Değil
        public string Content { get; set; }
        //Zorunlu Alan Dropdown list yapcaksın bunun örneği seo kısmında vardır 
        //seçmeli liste koyacaksın
        /*
         Anasayfa|Alan1
         Anasyafa|Alan2
         Anasyafa|Alan3
         Hakkımızda|Banner
         Kategori|Banner
         Urunler|Banner
         Restaurant|Banner
         SSS|Banner
         Sağlıklı Beslen|Banner
         UrunDetay|Banner
         KategoriDetay|Banner
         */
        public string Code { get; set; }
        //Zorunlu Alanın
        public string url { get; set; }
    }
}
