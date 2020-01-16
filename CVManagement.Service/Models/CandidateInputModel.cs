using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.Models
{
    public class CandidateInputModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
        public string University { get; set; }
        public int StatusId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Note { get; set; }
        public List<Guid> LanguageIds { get; set; }
        public List<Guid> FrameworkIds { get; set; }

    }
}
