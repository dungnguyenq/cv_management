using CVManagement.EntityFramework.Data;
using CVManagement.EntityFramework.Entities;
using CVManagement.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.LanguageServices
{
    public class LanguageService : ILanguageService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LanguageService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<LanguageOutputModel> GetLanguage(Guid id)
        {
            var language = await _applicationDbContext.Languages.FindAsync(id);
            if (language == null)
            {
                return null;
            }
            else
            {
                var result = new LanguageOutputModel
                {
                    Id = language.Id,
                    Name = language.Name,
                    Description = language.Description
                };
                return result;
            }
        }
        public IEnumerable<LanguageOutputModel> GetLanguages()
        {
            var result = _applicationDbContext.Languages.Where(l => l.IsActive).Select(l => new LanguageOutputModel 
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                IsActive = l.IsActive
            }).OrderBy(r => r.Name);

            return result;
        }
        public async Task AddLanguage(LanguageInputModel inputModel, string currentUsername)
        {
            var language = new Language
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                IsActive = true,
                CreatedBy = currentUsername,
                CreatedDate = DateTime.Now,
                ModifiedBy = currentUsername,
                ModifiedDate = DateTime.Now
            };
            _applicationDbContext.Languages.Add(language);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task PutLanguage(Guid id, LanguageInputModel inputModel, string currentUsername)
        {
            var language = await _applicationDbContext.Languages.FindAsync(id);
            language.Name = inputModel.Name;
            language.Description = inputModel.Description;
            language.ModifiedBy = currentUsername;
            language.ModifiedDate = DateTime.Now;

            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task DeleteLanguage(Guid id, string currentUsername)
        {
            var language = await _applicationDbContext.Languages.FirstOrDefaultAsync(c => c.Id == id);
            language.IsActive = false;
            language.ModifiedBy = currentUsername;
            language.ModifiedDate = DateTime.Now;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
