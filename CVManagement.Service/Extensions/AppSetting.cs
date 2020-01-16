using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.Extensions
{
    public class AppSetting
    {
        public class SmtpServer
        {
            public string Host { get; set; }
            public string Port { get; set; }
            public string Username { get; set; }
            public string Passwork { get; set; }
            public string EnableSSL { get; set; }
        }
    }
}
