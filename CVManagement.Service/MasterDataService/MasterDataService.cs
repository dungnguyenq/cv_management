using CVManagement.Service.Extensions;
using CVManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.Service.MasterDataService
{
    public class MasterDataService : IMasterDataService
    {
        public IEnumerable<StatusOutputModel> GetStatusList()
        {
            //will build function to get data from database
            var statusList = new List<StatusOutputModel>();
            statusList.Add(new StatusOutputModel { Id = Constants.StatusInt.Close, Name = Constants.StatusString.Close });
            statusList.Add(new StatusOutputModel { Id = Constants.StatusInt.Open, Name = Constants.StatusString.Open });
            statusList.Add(new StatusOutputModel { Id = Constants.StatusInt.Process, Name = Constants.StatusString.Process });
            return statusList;
        }
    }
}
