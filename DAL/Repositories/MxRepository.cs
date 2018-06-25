using System;
using System.Diagnostics;
using System.IO;

namespace DAL
{
    public class MxRepository : IMxRepository
    {
        public string GetMxRecords(string domain)
        {
            var p = new ProcessStartInfo();
            p.FileName = @"nslookup";
            //p.Arguments = "-q=mx";
            p.UseShellExecute = false;
            p.CreateNoWindow = true;
            p.RedirectStandardOutput = true;
            p.RedirectStandardInput = true;

            try
            {
                using (Process process = Process.Start(p))
                {
                    StreamWriter writer = process.StandardInput;
                    writer.WriteLine("set type=mx\n");
                    //writer.WriteLine("set retry=5\n");
                    //writer.WriteLine("set timeout=5\n");
                    writer.WriteLine(domain + "\n");
                    writer.WriteLine("exit\n");

                    using (StreamReader reader = process.StandardOutput)
                    {
                        var result = reader.ReadToEnd();
                        process.Close();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}