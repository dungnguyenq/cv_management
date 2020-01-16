﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.EntityFramework.Entities
{
    public class Framework
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IList<CandidateFramework> CandidateFrameworks { get; private set; } = new List<CandidateFramework>();
        public IList<LanguageFramework> LanguageFrameworks { get; private set; } = new List<LanguageFramework>();
    }
}
