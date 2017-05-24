using System;
using System.Collections.Generic;
using System.Text;
using Dgi.Email.Delt.Interfaces;
using Dgi.Host.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Dgi.Email.WebApi.Controllers
{
    public class EmailController
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        //private readonly IServiceProvider _serviceProvider;

        //public EmailController(IServiceProvider serviceProvider)
        //{
        //    _serviceProvider = serviceProvider;
        //}

        [HttpGet("api/helloworld")]
        public DgiResponse<object> HelloWorld()
        {
            return new DgiResponse<object>(new
            {
                message = "Hello World",
                time = DateTime.Now
            });
        }

        [HttpPost("api/verify")]
        public DgiResponse<bool> Verify([FromBody] string emailadresse)
        {
            //IEmailService emailService = _serviceProvider.GetRequiredService<IEmailService>();

            return new DgiResponse<bool>(_emailService.Verify(emailadresse));
        }
    }
}
