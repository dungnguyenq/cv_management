using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.EntityFramework.Entities
{
    public class LanguageFramework
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
        public Guid FrameworkId { get; set; }
        public Framework Framework { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
