using Restaurant.Entity.Entity;
using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class HumanController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: Human
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "İnsan Kaynakları").FirstOrDefault();
            return View();
        }
        [HttpPost]
        [Route("insan-kaynaklari")]
        public ActionResult Index(HumanResources humanResources, HttpPostedFileBase File)
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "İnsan Kaynakları").FirstOrDefault();
            if (ModelState.IsValid)
            {
                try
                {
                    SmtpClient client = new SmtpClient("ni-trio-win.guzelhosting.com", 587);
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("iletisim@doybox.com.tr", "Doybox@12121314");
                    client.EnableSsl = false;
                    client.Credentials = credentials;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("iletisim@doybox.com.tr", "BİDAA - DOYBOX BİLGİ AL");
                    mailMessage.To.Add(new MailAddress("bilgi@doybox.com.tr", "BİDAA - DOYBOX BİLGİ AL"));
                    mailMessage.Subject = humanResources.Subject;
                    if (File != null)
                    {
                        string fileName = Path.GetFileName(File.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/Human/" + fileName));
                        if (fileName.EndsWith(".pdf"))
                        {
                            File.SaveAs(url);
                            humanResources.File = fileName;
                            mailMessage.Attachments.Add(new Attachment(File.InputStream, fileName));
                        }
                        else
                        {
                            ViewBag.Hata = "Sadece PDF Dosyası Ekleyiniz";
                            return View(humanResources);
                        }
                    }
                    mailMessage.Subject = humanResources.Subject;
                    mailMessage.Body = "<h3>"+Request.Url+"<br> Yukarıda belirtilen siteden size bir mail gelmişitir.<hr></h3><p>Mail içeriği aşağıda size verilen bilgiler doğrultuusnda maili kimin gönderdiği hangi mail adresi ile gönderdi bunların hepsi site tarafında mevcut olarak bulunmaktadır.</p><hr><h5><b>Mail Gönderinin Adı Soyadı : </b></h5>" + humanResources.NameSurname + "<hr><h5><b>İlgili Kişinin E-Mail Adresi : </b></h5>" + humanResources.Email + "<hr><h5><b>İlgili Kişinin Telefon Numarası :  </b></h5>" + humanResources.Phone + "<hr><h5><b>Mail Gönderenin Konusu : </b></h5>" + humanResources.Subject + "<hr><h5><b>Mail Gönderen Kişinin Mesajı : </b></h5>" + humanResources.Messages;
                    mailMessage.IsBodyHtml = true;
                    humanResources.LastDateTime = DateTime.Now;
                    humanResources.IsActive = true;
                    db.HumanResourcess.Add(humanResources);
                    db.SaveChanges();
                    client.Send(mailMessage);
                    ViewBag.Mesaj = "Mailiniz bize ulaştı, size en kısa sürede dönüş yapılacaktır.";
                }
                catch
                {
                    ViewBag.Hata = "Mail gönderilirken bir hata oluştu lütfen tekrar deneyiniz.";
                }
            }
            return View(humanResources);
        }

        #region Paçalı Sayfaları
        public ActionResult PartialHumanResources()
        {
            return PartialView(db.Abouts.Where(x => x.IsActive == true && x.Title == "İnsan Kaynakları").FirstOrDefault());
        }
        public ActionResult PartialBannerHumanResourcers()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "İnsan Kaynakları|Banner").FirstOrDefault();
            return PartialView(a);
        }
        #endregion
    }
}