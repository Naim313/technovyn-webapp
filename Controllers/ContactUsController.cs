using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace YourApp.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ContactUsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: ContactUs
        public IActionResult Index()
        {
            return View();
        }

        // POST: ContactUs/SendEmail
        [HttpPost]
        public async Task<IActionResult> SendEmail(string name, string email, string subject, string message)
        {
            try
            {
                // Retrieve SMTP settings from appsettings.json
                var smtpServer = _configuration["EmailSettings:SmtpServer"];
                var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
                var senderEmail = _configuration["EmailSettings:SenderEmail"];
                var senderPassword = _configuration["EmailSettings:SenderPassword"];

                // Set up the SMTP client
                var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                };

                // Create the email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail, "YourApp Contact Us"),
                    Subject = subject,
                    Body = $"Name: {name}\nEmail: {email}\nMessage: {message}",
                    IsBodyHtml = false,
                };

                mailMessage.To.Add("your-receiving-email@example.com");

                // Send the email asynchronously
                await smtpClient.SendMailAsync(mailMessage);

                TempData["SuccessMessage"] = "Your message has been sent successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"There was an error sending your message: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
