using CVManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.LanguageServices
{
    public interface ILanguageService
    {
        Task<LanguageOutputModel> GetLanguage(Guid id);
        IEnumerable<LanguageOutputModel> GetLanguages();
        Task AddLanguage(LanguageInputModel inputModel, string currentUsername);
        Task PutLanguage(Guid id, LanguageInputModel inputModel, string currentUsername);
        Task DeleteLanguage(Guid id, string currentUsername);

    }
}
