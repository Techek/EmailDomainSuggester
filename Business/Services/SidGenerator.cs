using System;
using Business.Interfaces;

namespace Business.Services
{
    public class SidGenerator : ISidGenerator
    {
        public string Generate()
        {
            //var rand = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
            //var sid = rand.Next(1000000, 9999999).ToString();
            //return sid;

            return Guid.NewGuid().ToString();
        }
    }
}