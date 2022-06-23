using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using azure_m.Models;
using azure_m.Services;

namespace azure_m.Services
{
    /// <summary>
    /// 所有资源的动作
    /// </summary>
    /// <typeparam name="T">泛型是虚拟资源类，规定所有资源都有相对应的类型</typeparam>
    class resourcesdatastore
    {
        public async Task<Resources[]> GetItemsAsync(string filter = "", Nullable<int> top = null)
        {
            return await QueryInfo.queryList.resources.listResources<Resources[]>(filter, top);
        }

    }
}
