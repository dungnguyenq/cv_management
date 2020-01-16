using CVManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.MasterDataService
{
    public interface IMasterDataService
    {
        IEnumerable<StatusOutputModel> GetStatusList();
    }
}
