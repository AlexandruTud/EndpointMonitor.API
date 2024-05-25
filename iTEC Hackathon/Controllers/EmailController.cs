using iTEC_Hackathon.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iTEC_Hackathon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail(string to, string subject, string body)
        {
            var result = _emailService.SendEmail(to, subject, body);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
