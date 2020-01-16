using CVManagement.EntityFramework.Data;
using CVManagement.EntityFramework.Entities;
using CVManagement.Service.CandidateServices;
using CVManagement.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.CandidateLanguageServices
{
    public class CandidateLanguageService : ICandidateLanguageService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        //private readonly ICandidateService _candidateService;
        public CandidateLanguageService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            //_candidateService = candidateService;
        }

        //public async Task<CandidateLanguageOutputModel> GetCandidateLanguage(Guid id)
        //{
        //    var candidateLanguage = await _applicationDbContext.CandidateLanguages.FindAsync(id);
        //    if (candidateLanguage == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        var result = new CandidateLanguageOutputModel
        //        {
        //            Id = candidateLanguage.Id,
        //            CandidateId = candidateLanguage.CandidateId,
        //            LanguageId = candidateLanguage.LanguageId
        //        };
        //        return result;
        //    }
        //}
        //public async Task AddCandidateLanguage(CandidateLanguageInputModel inputModel, string currentUsername)
        //{
        //    var candidateLanguage = new CandidateLanguage
        //    {
        //        CandidateId = inputModel.CandidateId,
        //        LanguageId = inputModel.LanguageId,
        //        IsActive = true,
        //        CreatedBy = currentUsername,
        //        CreatedDate = DateTime.Now,
        //        ModifiedBy = currentUsername,
        //        ModifiedDate = DateTime.Now
        //    };
        //    _applicationDbContext.CandidateLanguages.Add(candidateLanguage);
        //    await _applicationDbContext.SaveChangesAsync();
        //}
        //public async Task PutCandidateLanguage(Guid id, CandidateLanguageInputModel inputModel, string currentUsername)
        //{
        //    var candidateLanguage = await _applicationDbContext.CandidateLanguages.FindAsync(id);
        //    candidateLanguage.CandidateId = inputModel.CandidateId;
        //    candidateLanguage.LanguageId = inputModel.LanguageId;
        //    candidateLanguage.ModifiedBy = currentUsername;
        //    candidateLanguage.ModifiedDate = DateTime.Now;

        //    await _applicationDbContext.SaveChangesAsync();
        //}

        //public async Task AddCandidateLanguages(Guid candidateId, CandidateLanguagesModel candidateLanguagesModel, string currentUsername)
        //{
        //    //var candidate = _candidateService.GetCandidate(candidateId);
        //    //if (candidate != null)
        //    //{
        //        foreach (var item in candidateLanguagesModel.LanguageIds)
        //        {
        //            var candidateLanguage = new CandidateLanguage
        //            {
        //                CandidateId = candidateId,
        //                LanguageId = item,
        //                IsActive = true,
        //                CreatedBy = currentUsername,
        //                CreatedDate = DateTime.Now,
        //                ModifiedBy = currentUsername,
        //                ModifiedDate = DateTime.Now
        //            };
        //            await _applicationDbContext.AddAsync(candidateLanguage);
        //        }
        //        await _applicationDbContext.SaveChangesAsync();
        //    //}
        //}

        //public async Task<CandidateLanguagesModel> GetCandidateLanguageByCandidateId(Guid candidateId)
        //{
        //    var candidateLanguages = await _applicationDbContext.CandidateLanguages.Where(c => c.CandidateId == candidateId).ToListAsync();
        //    var result = new CandidateLanguagesModel
        //    {
        //        CandidateId = candidateId,
        //        LanguageIds = candidateLanguages.Select(c => c.LanguageId).ToList()
        //    };
        //    return result;
        //}
    }
}
