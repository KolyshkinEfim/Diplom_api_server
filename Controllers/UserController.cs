using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using test_crud.Models;
using test_crud.Interfaces;
using test_crud.Entity;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System;

namespace test_crud.Controllers
{
    [ApiController]
    [Route("UserController")]
    public class UserController : ControllerBase
    {
        private IRepository _userRepos;
        private ApplicationContext _context;

        public UserController(IRepository userRepository, ApplicationContext context)
        {
            _userRepos = userRepository;
            _context = context;
        }

        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _context.UsersTable.ToList();
        }

        [HttpGet("FindUserByID/{id}")]
        public User Get([FromRoute] int id)
        {
            return _userRepos.FindById<User>(id);
        }

        [HttpPost("AddUser")]
        public ActionResult Add([FromBody] User item)
        {
            if (_context.UsersTable.FirstOrDefault((x) => x.Mail == item.Mail) == null)
            {
                _userRepos.Create(item);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("UpdateUser")]
        public ActionResult Update([FromBody] PersonalAreaModel item)
        {
            var user = _context.UsersTable.FirstOrDefault((x) => x.ID == item.ID);
            if (user != null)
            {
                user.Name = item.Name ?? user.Name;
                user.Surname = item.Surname ?? user.Surname;
                user.LastName = item.LastName ?? user.LastName;
                user.Adress = item.Adress ?? user.Adress;
                _userRepos.Update(user);
                return Ok();
            }
            return BadRequest();
        }

        private string GenerateRandomWord()
        {
            Random rand = new Random();
            int length = 8;
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqstuvwxy0123456789".ToCharArray();

            string word = string.Empty;

            for (int i = 0; i < length; i++)
            {
                int letter = rand.Next(0, letters.Length - 1);
                word += letters[letter];
            }

            return word;

        }

        private void SendPasswordToMail(string mail, string interimPassword)
        {
            try
            {
                MailAddress from = new MailAddress("elmagbydip@gmail.com", "Адмнистрация ElectroMag");
                MailAddress to = new MailAddress(mail);
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Восстановление пароля";
                message.Body = string.Format("<div>Ваш новый пароль от аккаунта <b>{0}</b>: {1}</div> <br/> После авторизации с помощью вашего нового пароля вы можете поменять его в вашем личном кабинете.", mail, interimPassword);
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

        [HttpPost("ForgivePassword")]
        public ActionResult PasswordRespawn([FromBody] string mail)
        {
                var user = _context.UsersTable.FirstOrDefault(x => x.Mail == mail);
                if (user != null)
                {
                    user.Password =  GenerateRandomWord() ?? user.Password;
                    _userRepos.Update(user);
                    SendPasswordToMail(user.Mail, user.Password);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
        }


        [HttpPost("UpdateUserPassword")]
        public ActionResult UpdateUserPassword([FromBody] UpdateUserPassword item)
        {
            var user = _context.UsersTable.FirstOrDefault((x) => x.Mail == item.Mail);
            if (user.Password == item.NewPassword)
            {
                return BadRequest( new {type = "error", message = "TheSamePasswords" });
            }
            if (user.Password == item.OldPassword)
            {
                user.Password = item.NewPassword ?? user.Password;
                _userRepos.Update(user);
                return Ok();
            }
            return BadRequest(new { type = "error", message = "OldPasswordError" });
        }

        [HttpPost("RemoveUser")]
        public void Remove(int id)
        {
            _userRepos.Remove<User>(_userRepos.FindById<User>(id));
        }

    }
}
