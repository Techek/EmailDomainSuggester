using System;
using Dgi.Email.Delt.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Dgi.Host.Controllers
{
    public class EmailController
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet("api/helloworld")]
        public object HelloWorld()
        {
            return new
            {
                message = "Hello World",
                time = DateTime.Now
            };
        }

        [HttpPost("api/verify")]
        public bool Verify([FromBody]string emailadresse)
        {
            IEmailService emailService = _serviceProvider.GetRequiredService<IEmailService>();

            return emailService.Verify(emailadresse);
        }
    }
}
