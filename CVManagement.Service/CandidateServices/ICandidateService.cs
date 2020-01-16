using CVManagement.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.CandidateServices
{
    public interface ICandidateService
    {
        Task<CandidateOutputModel> GetCandidate(Guid id);
        IEnumerable<CandidateOutputModel> GetCandidates();
        Task AddCandidate(IFormFile image, IFormFile cv, CandidateInputModel inputCandidate, string currentUsername);
        Task PutCandidate(Guid id, IFormFile image, IFormFile cv, CandidateInputModel inputCandidate, string currentUsername);
        Task DeleteCandidate(Guid id, string currentUsername);
        Task<string> Sendmail(MailModel mailModel);
    }
}
