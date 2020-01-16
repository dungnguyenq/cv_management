using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.Models
{
    public class CandidateLanguagesModel
    {
        public Guid CandidateId { get; set; }
        public List<Guid> LanguageIds { get; set; }
    }
}
