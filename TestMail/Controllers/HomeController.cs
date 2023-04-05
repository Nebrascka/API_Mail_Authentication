using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace TestMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendMail([FromBody] Details details)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("owinodav99@gmail.com"));
            email.To.Add(new MailboxAddress("",details.ReceiverEmail));

            email.Subject = "API middle man";
            email.Body = new TextPart("plain")
            {
                Text = details.ReceiverMessage
            };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
            smtp.Authenticate("owinodav99@gmail.com", "deqlevydazfpbamn");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
    }
}
