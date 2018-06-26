using System;
using System.Linq;
using DAL;
using System.Text.RegularExpressions;

namespace Business
{
    public class MxService : IMxService
    {
        private readonly IMxRepository _mxRepository;

        public MxService(IMxRepository mxRepository)
        {
            _mxRepository = mxRepository;
        }

        public bool HasMxRecord(string domain)
        {
            var nslookupResult = _mxRepository.GetMxRecords(domain);

            if (string.IsNullOrEmpty(nslookupResult))
            {
                return false;
            }

            string[] lines = nslookupResult.Split("\r\n");

            var rx = new Regex(@"^(.*[^\s])\s+mx preference = ([0-9]+), mail exchanger = (.+)$", RegexOptions.IgnoreCase);

            return lines.Any(line =>
            {
                if (string.IsNullOrEmpty(line))
                    return false;

                var m = rx.Match(line);
                return (m.Success && m.Groups.Count > 0 && m.Groups[1].Value == domain);
            });
        }
    }
}