using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.Models
{
    public class CandidateLanguageInputModel
    {
        public Guid CandidateId { get; set; }
        public CandidateOutputModel Candidate { get; set; }
        public Guid LanguageId { get; set; }
        public LanguageOutputModel Language { get; set; }

    }
}
