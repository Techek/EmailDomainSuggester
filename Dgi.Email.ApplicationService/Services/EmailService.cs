using System;
using Dgi.Email.Dal.Repositories;
using Dgi.Email.Delt.Dtoer;
using Dgi.Email.Delt.Interfaces;

namespace Dgi.Email.ApplicationService.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public QueryResultDto Lookup(QueryDto dto)
        {
            return null;
        }

        public bool Verify(string emailaddress)
        {
            return _emailRepository.HarMxRecord(emailaddress);
        }
    }
}