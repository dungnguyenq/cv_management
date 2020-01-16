using CVManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.MailService
{
    public interface IMailService
    {
        Task<string> SendMail(MailModel mailModel);
    }
}
