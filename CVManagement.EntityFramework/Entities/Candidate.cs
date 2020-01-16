using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.EntityFramework.Entities
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Note { get; set; }
        public DateTime DOB { get; set; }
        public string University { get; set; }
        public string Avatar { get; set; }
        public string CV { get; set; }
        public int Status { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IList<CandidateLanguage> CandidateLanguages { get; private set; } = new List<CandidateLanguage>();
        public IList<CandidateFramework> CandidateFrameworks { get; private set; } = new List<CandidateFramework>();
    }
}
