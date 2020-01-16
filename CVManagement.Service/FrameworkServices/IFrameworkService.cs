using CVManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.FrameworkService
{
    public interface IFrameworkService
    {
        Task<FrameworkOutputModel> GetFramework(Guid id);
        IEnumerable<FrameworkOutputModel> GetFrameworks();
        Task AddFramework(FrameworkInputModel inputModel, string currentUsername);
        Task PutFramework(Guid id, FrameworkInputModel inputModel, string currentUsername);
        Task DeleteFramework(Guid id, string currentUsername);

    }
}
