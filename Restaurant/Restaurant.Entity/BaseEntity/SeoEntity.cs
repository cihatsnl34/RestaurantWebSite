using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity.BaseEntity
{
    public class SeoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastDateTime { get; set; }

        [StringLength(70,ErrorMessage ="Lütfen 70 Karekteri Geçmeyiniz")]
        public string seoTitle { get; set; }

        [Required, StringLength(110, ErrorMessage = "Lütfen 110 Karekteri Geçmeyiniz")]
        public string seoKeywords { get; set; }

        [Required, StringLength(170, ErrorMessage = "Lütfen 170 Karekteri Geçmeyiniz")]
        public string seoKDescription { get; set; }

        [StringLength(50, ErrorMessage = "Lütfen 50 Karekteri Geçmeyiniz")]
        public string seoAuthor { get; set; }

        [StringLength(90, ErrorMessage = "Lütfen 90 Karekteri Geçmeyiniz")]
        public string seoCopyright { get; set; }

        [StringLength(50, ErrorMessage = "Lütfen 50 Karekteri Geçmeyiniz")]
        public string seoDesigner { get; set; }

        [StringLength(40, ErrorMessage = "Lütfen 40 Karekteri Geçmeyiniz")]
        public string seoReply { get; set; }

        [Required, StringLength(110, ErrorMessage = "Lütfen 110 Karekteri Geçmeyiniz")]
        public string seoSubject { get; set; }

        [Required, StringLength(110, ErrorMessage = "Lütfen 110 Karekteri Geçmeyiniz")]
        public string seoTwitterTitle { get; set; }

        [Required, StringLength(170, ErrorMessage = "Lütfen 170 Karekteri Geçmeyiniz")]
        public string seoTwitterDescription { get; set; }

        [Required, StringLength(60, ErrorMessage = "Lütfen 60 Karekteri Geçmeyiniz")]
        public string seoTwitterUrl { get; set; }

        [Required, StringLength(110, ErrorMessage = "Lütfen 110 Karekteri Geçmeyiniz")]
        public string seoFacebookTitle { get; set; }

        [Required, StringLength(170, ErrorMessage = "Lütfen 170 Karekteri Geçmeyiniz")]
        public string seoFacebookDescription { get; set; }

        [Required, StringLength(60, ErrorMessage = "Lütfen 60 Karekteri Geçmeyiniz")]
        public string seoFacebookUrl { get; set; }

        [Required, StringLength(60, ErrorMessage = "Lütfen 60 Karekteri Geçmeyiniz")]
        public string seoPublisher { get; set; }

        [Required, StringLength(75, ErrorMessage = "Lütfen 75 Karekteri Geçmeyiniz")]
        public string seoClassification { get; set; }
    }
}
