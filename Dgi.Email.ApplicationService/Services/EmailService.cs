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

        public bool Verify(string emailadresse)
        {
            var domaene = HentDomaene(emailadresse);
            if (string.IsNullOrEmpty(domaene))
            {
                return false;
            }

            return _emailRepository.HarMxRecord(domaene);
        }

        private string HentDomaene(string emailadresse)
        {
            if (string.IsNullOrEmpty(emailadresse))
            {
                return null;
            }

            if (emailadresse.IndexOf('@') < 0)
            {
                return null;
            }

            var parts = emailadresse.Split('@');
            if (parts.Length == 2)
            {
                return parts[1];
            }

            return null;
        }
    }
}