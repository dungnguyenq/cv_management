using CVManagement.EntityFramework.Data;
using CVManagement.EntityFramework.Entities;
using CVManagement.Service.CandidateLanguageServices;
using CVManagement.Service.Extensions;
using CVManagement.Service.MailService;
using CVManagement.Service.Models;
using CVManagement.Service.StorageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CVManagement.Service.CandidateServices
{
    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ICandidateLanguageService _candidateLanguageService;
        private readonly IStorageService _storageService;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public CandidateService(ApplicationDbContext applicationDbContext, ICandidateLanguageService candidateLanguageService,
            IStorageService storageService, IMailService mailService, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _candidateLanguageService = candidateLanguageService;
            _storageService = storageService;
            _mailService = mailService;
            _configuration = configuration;

        }

        public async Task<CandidateOutputModel> GetCandidate(Guid id)
        {
            var candidate = await _applicationDbContext.Candidates.Include(c => c.CandidateLanguages).ThenInclude(c => c.Language).Include(c => c.CandidateFrameworks).ThenInclude(c => c.Framework).FirstOrDefaultAsync(c => c.Id == id && c.IsActive);
            if (candidate == null)
            {
                return null;
            }
            else
            {
                var result = new CandidateOutputModel
                {
                    Id = candidate.Id,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    University = candidate.University,
                    DOB = candidate.DOB,
                    AvatarUrl = _storageService.GetMediaUrl(candidate.Avatar),
                    CvUrl = _storageService.GetMediaUrl(candidate.CV),
                    StatusId = candidate.Status,
                    Email = candidate.Email,
                    PhoneNumber = candidate.PhoneNumber,
                    LinkedIn = candidate.LinkedIn,
                    Facebook = candidate.Facebook,
                    Note = candidate.Note,
                    Languages = candidate.CandidateLanguages.Where(c => c.IsActive).Select(c => c.Language.Name).ToList(),
                    Frameworks = candidate.CandidateFrameworks.Where(c => c.IsActive).Select(c => c.Framework.Name).ToList(),
                    LanguageIds = candidate.CandidateLanguages.Where(c => c.IsActive).Select(l => l.LanguageId).ToList(),
                    FrameworkIds = candidate.CandidateFrameworks.Where(c => c.IsActive).Select(f => f.FrameworkId).ToList()
                };
                return result;
            }
        }
        public IEnumerable<CandidateOutputModel> GetCandidates()
        {
            var candidates = _applicationDbContext.Candidates.OrderByDescending(c=>c.ModifiedDate).Where(c => c.IsActive).Include(c => c.CandidateLanguages).ThenInclude(c => c.Language).Include(c => c.CandidateFrameworks).ThenInclude(c => c.Framework)
                .Select(c => new CandidateOutputModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    University = c.University,
                    DOB = c.DOB,
                    AvatarUrl = _storageService.GetMediaUrl(c.Avatar),
                    CvUrl = _storageService.GetMediaUrl(c.CV),
                    StatusId = c.Status,
                    Status = c.Status == Constants.StatusInt.Close ? Constants.StatusString.Close:
                             c.Status == Constants.StatusInt.Open ? Constants.StatusString.Open:
                             c.Status == Constants.StatusInt.Process ? Constants.StatusString.Process : Constants.StatusString.NoStatus
                    ,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    LinkedIn = c.LinkedIn,
                    Facebook = c.Facebook,
                    Note = c.Note,
                    Languages = c.CandidateLanguages.Where(cd => cd.IsActive && cd.Language.IsActive).Select(cd => cd.Language.Name).ToList(),
                    Frameworks = c.CandidateFrameworks.Where(cd => cd.IsActive && cd.Framework.IsActive).Select(cd => cd.Framework.Name).ToList(),
                });
            return candidates;
        }
        public async Task AddCandidate(IFormFile image, IFormFile cv, CandidateInputModel inputCandidate, string currentUsername)
        {
            Guid id = Guid.NewGuid();
            var candidate = new Candidate
            {
                Id = id,
                FirstName = inputCandidate.FirstName,
                LastName = inputCandidate.LastName,
                University = inputCandidate.University,
                DOB = inputCandidate.DOB,
                Status = inputCandidate.StatusId,
                Email = inputCandidate.Email,
                PhoneNumber = inputCandidate.PhoneNumber,
                LinkedIn = inputCandidate.LinkedIn,
                Facebook = inputCandidate.Facebook,
                Note = inputCandidate.Note,
                IsActive = true,
                CreatedBy = currentUsername,
                CreatedDate = DateTime.Now,
                ModifiedBy = currentUsername,
                ModifiedDate = DateTime.Now,
            };
            if(image != null)
            {
                candidate.Avatar = await SaveFile(image);
            }
            if(cv != null)
            {
                candidate.CV = await SaveFile(cv);
            }
            await _applicationDbContext.AddAsync(candidate);
            foreach (var item in inputCandidate.LanguageIds)
            {
                var candidateLanguage = new CandidateLanguage
                {
                    Id = Guid.NewGuid(),
                    CandidateId = id,
                    LanguageId = item,
                    IsActive = true,
                    CreatedBy = currentUsername,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = currentUsername,
                    ModifiedDate = DateTime.Now
                };
                await _applicationDbContext.AddAsync(candidateLanguage);
            }
            foreach (var item in inputCandidate.FrameworkIds)
            {
                var candidateFramwork = new CandidateFramework
                {
                    Id = Guid.NewGuid(),
                    CandidateId = id,
                    FrameworkId = item,
                    IsActive = true,
                    CreatedBy = currentUsername,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = currentUsername,
                    ModifiedDate = DateTime.Now
                };
                await _applicationDbContext.AddAsync(candidateFramwork);
            }
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task PutCandidate(Guid id, IFormFile image, IFormFile cv, CandidateInputModel inputCandidate, string currentUsername)
        {
            var candidate = await _applicationDbContext.Candidates.Include(c => c.CandidateLanguages).Include(c => c.CandidateFrameworks).FirstOrDefaultAsync(c => c.Id == id);
            if (candidate != null)
            {
                candidate.FirstName = inputCandidate.FirstName;
                candidate.LastName = inputCandidate.LastName;
                candidate.University = inputCandidate.University;
                candidate.DOB = inputCandidate.DOB;
                candidate.Email = inputCandidate.Email;
                candidate.PhoneNumber = inputCandidate.PhoneNumber;
                candidate.LinkedIn = inputCandidate.LinkedIn;
                candidate.Facebook = inputCandidate.Facebook;
                candidate.Status = inputCandidate.StatusId;
                candidate.Note = inputCandidate.Note;
                candidate.ModifiedBy = currentUsername;
                candidate.ModifiedDate = DateTime.Now;

                if (image != null)
                {
                    candidate.Avatar = await SaveFile(image);
                }
                if (cv != null)
                {
                    candidate.CV = await SaveFile(cv);
                }
                var candidateLanguages = candidate.CandidateLanguages;
                foreach (var item in candidateLanguages)
                {
                    item.IsActive = false;
                    item.ModifiedBy = currentUsername;
                    item.ModifiedDate = DateTime.Now;
                }
                foreach (var item in inputCandidate.LanguageIds)
                {
                    if (candidateLanguages.Select(c => c.LanguageId).Contains(item))
                    {
                        var cd = candidateLanguages.FirstOrDefault(c => c.LanguageId == item);
                        cd.IsActive = true;
                        cd.ModifiedBy = currentUsername;
                        cd.ModifiedDate = DateTime.Now;
                    }
                    else if (!candidateLanguages.Select(c => c.LanguageId).Contains(item))
                    {
                        var candidateLanguage = new CandidateLanguage
                        {
                            Id = Guid.NewGuid(),
                            CandidateId = id,
                            LanguageId = item,
                            IsActive = true,
                            CreatedBy = currentUsername,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = currentUsername,
                            ModifiedDate = DateTime.Now
                        };
                        await _applicationDbContext.AddAsync(candidateLanguage);
                    }

                }

                var candidateFrameworks = candidate.CandidateFrameworks;
                foreach (var item in candidateFrameworks)
                {
                    item.IsActive = false;
                    item.ModifiedBy = currentUsername;
                    item.ModifiedDate = DateTime.Now;
                }
                foreach (var item in inputCandidate.FrameworkIds)
                {
                    if (candidateFrameworks.Select(c => c.FrameworkId).Contains(item))
                    {
                        var cd = candidateFrameworks.FirstOrDefault(c => c.FrameworkId == item);
                        cd.IsActive = true;
                        cd.ModifiedBy = currentUsername;
                        cd.ModifiedDate = DateTime.Now;
                    }
                    else if (!candidateFrameworks.Select(c => c.FrameworkId).Contains(item))
                    {
                        var candidateFramework = new CandidateFramework
                        {
                            Id = Guid.NewGuid(),
                            CandidateId = id,
                            FrameworkId = item,
                            IsActive = true,
                            CreatedBy = currentUsername,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = currentUsername,
                            ModifiedDate = DateTime.Now
                        };
                        await _applicationDbContext.AddAsync(candidateFramework);
                    }

                }
            }
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task DeleteCandidate(Guid id, string currentUsername)
        {
           var candidate = await _applicationDbContext.Candidates.FirstOrDefaultAsync(c => c.Id == id);
            candidate.IsActive = false;
            candidate.ModifiedBy = currentUsername;
            candidate.ModifiedDate = DateTime.Now;
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<string> Sendmail(MailModel mailModel)
        {
            var result = await _mailService.SendMail(mailModel);
            return result;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}
