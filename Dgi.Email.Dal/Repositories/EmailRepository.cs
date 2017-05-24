using System;
using System.Collections.Generic;
using System.Linq;

namespace Dgi.Email.Dal.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public bool HarMxRecord(string domaene)
        {
            var domaener = new List<string>()
            {
                "dgi.dk",
                "gmail.com"
            };

            return domaener.Any(d => domaene.Equals(d, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}