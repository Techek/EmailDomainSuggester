using System;
using System.Linq;
using DAL;

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

            //Regex rx = new Regex(@"^([\.\-0-9a-zöäüé]+)\tmx preference = ([0-9]+), mail exchanger = ([\.\-0-9a-zöäüé]+)$", RegexOptions.IgnoreCase);
            //Regex rx = new Regex(@"^(.+)\tmx preference = ([0-9]+), mail exchanger = (.+)$", RegexOptions.IgnoreCase);

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string line = lines[i];
            //    Match m = rx.Match(line);
            //    if (m.Success)
            //    {
            //        GroupCollection g = m.Groups;
            //        if (g.Count > 1)
            //        {
            //            for (int j = 1; j < g.Count; j++)
            //            {
            //                Console.Write("[" + g[j] + "]");
            //            }
            //            Console.Write("\n");
            //        }
            //    }
            //}

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

            #endregion

            #region Version 3 - LINQ

            found = lines.Any(l => l.Contains("MX preference = "));

            #endregion

            return found;
        }
    }
}