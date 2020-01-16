using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.Models
{
    public class CandidateOutputModel
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
        public string University { get; set; }
        public string AvatarUrl { get; set; }
        public string CvUrl { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Note { get; set; }
        public IList<string> Languages { get; set; }
        public IList<string> Frameworks { get; set; }
        public IList<Guid> LanguageIds { get; set; }
        public IList<Guid> FrameworkIds { get; set; }
    }
}
