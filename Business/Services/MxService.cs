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

            bool found = false;

            string[] lines = nslookupResult.Split('\n');

            #region Version 1 - Pattern match

            var rx = new Regex(@"^(" + domain.Replace(".", @"\.") + @")\s+mx preference = ([0-9]+), mail exchanger = (.+)$", RegexOptions.IgnoreCase);

            return lines.Any(line => rx.IsMatch(line));

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string line = lines[i];
            //    var m = rx.Match(line);
            //    if (m.Success && m.Groups.Count > 0 && m.Groups[1].Value == domain)
            //    {
            //        return true;
            //    }
            //}
            //return false;

            #endregion

            #region Version 2 - Loop and match

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string line = lines[i];
            //    if (line.Contains("MX preference = "))
            //    {
            //        found = true;
            //        break;
            //    }
            //}
            //return false;

            #endregion

            #region Version 3 - LINQ

            return lines.Any(l => l.Contains("MX preference = "));

            #endregion
        }
    }
}