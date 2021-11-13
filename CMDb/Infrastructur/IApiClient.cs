using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMDb.Infrastructur
{
   public interface IApiClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}
