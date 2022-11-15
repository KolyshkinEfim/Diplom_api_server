using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using test_crud.Entity;
using test_crud.Interfaces;
using test_crud.Models;
using static System.Net.Mime.MediaTypeNames;

namespace test_crud.Controllers
{
    [ApiController]
    [Route("OrderBaseController")]
    public class OrderBaseController : Controller
    {
        private ApplicationContext _context;
        private IRepository _orderrepos;

        public OrderBaseController(ApplicationContext context, IRepository orderrepos)
        {
            _context = context;
            _orderrepos = orderrepos;
        }
    

        private void SendOrderToMail(string mail, string img)
            {
            try
            {
                MailAddress from = new MailAddress("elmagbydip@gmail.com", "Адмнистрация ElectroMag");
                MailAddress to = new MailAddress(mail);
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Заказ";
                message.Body = string.Format("<div>Вы совершили заказ на сайте ElectroMag с аккаунта <b>{0}</b><br/> Скриншот:<br/> <a href={1}><a/>", mail, img);
                message.Attachments.Add(new Attachment(img));
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("elmagbydip@gmail.com", "123Alone");
                client.EnableSsl = true;
                client.Send(message);
            }
            catch (Exception ex)
            {
            }

        }


        [HttpPost("AddOrder")]
        public IActionResult AddOrderToBase([FromBody]OrderBase item) {

            _orderrepos.Create(item);
            return Ok();
        }
    }
}
