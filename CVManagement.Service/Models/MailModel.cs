using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.Models
{
    public class MailModel
    {
        public string EmailTo { get; set; }
        public string EmailCc { get; set; }
        public string EmailFrom { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
