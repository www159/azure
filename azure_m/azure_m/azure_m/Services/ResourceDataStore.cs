using azure_m.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace azure_m.Services
{
    partial class MockDataStore: IDataStore<Item>
    {
        public async Task<Resource[]> GetResourcesAsync(string filter = "", int top = -1)
        {
            return await QueryInfo.queryList.resources.listResources<Resource[]>(filter, top);
        }
    }
}
