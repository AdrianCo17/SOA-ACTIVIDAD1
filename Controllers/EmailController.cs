using Actividad1.Data;
using Actividad1.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;

namespace Actividad1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly DataContext _context;

        public EmailController(DataContext context)
        {
            _context = context;
        }

        public List<User> ObtenerLista()
        {
            List<User> lista = new List<User>();
            lista = _context.Users.ToList();


            return lista;

        }

        [HttpPost]
        public Task<IActionResult> SendEmailAsync(string body,string subject)
        {
            foreach(string element in ObtenerLista())
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("ajce17@outlook.es"));
                email.To.Add(MailboxAddress.Parse(user.Email));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = "<h1>" + body + "</h1>" };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("ajce17@outlook.es", "contrasena2023");
                smtp.Send(email);
                smtp.Disconnect(true);

                return Task.FromResult<IActionResult>(Ok());
            }
        }
    }
}
