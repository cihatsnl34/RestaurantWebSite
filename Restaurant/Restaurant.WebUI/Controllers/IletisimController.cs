using Restaurant.Entity.Entity;
using Restaurant.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.WebUI.Controllers
{
    public class IletisimController : Controller
    {
        RestaurantDBContext db = new RestaurantDBContext();
        // GET: Iletisim
        public ActionResult Index()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "İletişim").FirstOrDefault();
            return View();
        }
        [HttpPost]
        [Route("iletisim")]
        public ActionResult Index(ContactMail contactMail)
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageUrl == "İletişim").FirstOrDefault();
            if (ModelState.IsValid)
            {
                SmtpClient client = new SmtpClient("ni-trio-win.guzelhosting.com", 587);
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("iletisim@doybox.com.tr", "Doybox@12121314");
                client.EnableSsl = false;
                client.Credentials = credentials;
                try
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("iletisim@doybox.com.tr", "BİDAA - DOYBOX BİLGİ AL");
                    mailMessage.To.Add(new MailAddress("bilgi@doybox.com.tr", "BİDAA - DOYBOX BİLGİ AL"));
                    mailMessage.Subject = contactMail.Subject;
                    mailMessage.Body = "<h3>" + Request.Url + "<br> Yukarıda belirtilen siteden size bir mail gelmişitir.<hr></h3><p>Mail içeriği aşağıda size verilen bilgiler doğrultuusnda maili kimin gönderdiği hangi mail adresi ile gönderdi bunların hepsi site tarafında mevcut olarak bulunmaktadır.</p><hr><h5><b>Mail Gönderinin Adı Soyadı : </b></h5>" + contactMail.NameSurname + "<hr><h5><b>Mail Gönderenin Mail Adresi : </b></h5>" + contactMail.Email + "<hr><h5><b>Mail Gönderenin Telefon Bilgisi :  </b></h5>" + contactMail.Phone + "<hr><h5><b>Mail Gönderenin Konusu : </b></h5>" + contactMail.Subject + "<hr><h5><b>Mail Gönderen Kişinin Mesajı : </b></h5>" + contactMail.Messages;
                    mailMessage.IsBodyHtml = true;
                    contactMail.LastDateTime = DateTime.Now;
                    contactMail.IsActive = true;
                    db.ContactMails.Add(contactMail);
                    db.SaveChanges();
                    client.Send(mailMessage);
                    ViewBag.Mesaj = "Mailiniz bize ulaştı en yakın zamanda size geri dönüş sağlanacaktır.";
                }
                catch
                {
                    ViewBag.Hata = "Mail gönderirken bir hata oluştu";
                }

            }
            return View(contactMail);
        }
        #region ParcalıSayfalar
        public ActionResult PartialContactConstantValue()
        {
            var a = db.ConstantValues.Where(x => x.IsActive == true && x.Code == "İletişim|Banner").FirstOrDefault();
            return PartialView(a);
        }
        public ActionResult PartialContactLayout()
        {
            return PartialView(db.ContactInformations.Where(x => x.IsActive == true).ToList());
        }
        public ActionResult PartialContactBanner()
        {
            return PartialView(db.ContactInformations.Where(x => x.IsActive == true).ToList());
        }
        public ActionResult PartialContact()
        {
            return PartialView(db.ContactInformations.Where(x => x.IsActive == true).ToList());
        }
        #endregion
    }
}