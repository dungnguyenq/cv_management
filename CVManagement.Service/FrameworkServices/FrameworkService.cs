using CVManagement.EntityFramework.Data;
using CVManagement.EntityFramework.Entities;
using CVManagement.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.FrameworkService
{
    public class FrameworkService : IFrameworkService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FrameworkService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<FrameworkOutputModel> GetFramework(Guid id)
        {
            var framework = await _applicationDbContext.Frameworks.FindAsync(id);
            if (framework == null)
            {
                return null;
            }
            else
            {
                var result = new FrameworkOutputModel
                {
                    Id = framework.Id,
                    Name = framework.Name,
                    Description = framework.Description,
                    IsActive = framework.IsActive
                };
                return result;
            }
        }
        public IEnumerable<FrameworkOutputModel> GetFrameworks()
        {
            var result = _applicationDbContext.Frameworks.Where(f => f.IsActive).Select(l => new FrameworkOutputModel
            {
                Id = l.Id,
                Name = l.Name,
                Description = l.Description,
                IsActive = l.IsActive
            }).OrderBy(r => r.Name);

            return result;
        }
        public async Task AddFramework(FrameworkInputModel inputModel, string currentUsername)
        {
            var framework = new Framework
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                IsActive = true,
                CreatedBy = currentUsername,
                CreatedDate = DateTime.Now,
                ModifiedBy = currentUsername,
                ModifiedDate = DateTime.Now
            };
            _applicationDbContext.Add(framework);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task PutFramework(Guid id, FrameworkInputModel inputModel, string currentUsername)
        {
            var framework = await _applicationDbContext.Frameworks.FindAsync(id);
            framework.Name = inputModel.Name;
            framework.Description = inputModel.Description;
            framework.ModifiedBy = currentUsername;
            framework.ModifiedDate = DateTime.Now;

            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task DeleteFramework(Guid id, string currentUsername)
        {
            var framework = await _applicationDbContext.Frameworks.FirstOrDefaultAsync(c => c.Id == id);
            framework.IsActive = false;
            framework.ModifiedBy = currentUsername;
            framework.ModifiedDate = DateTime.Now;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
