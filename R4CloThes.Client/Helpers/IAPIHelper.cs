using R4CloThes.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4CloThes.Client.Helpers
{
    public interface IAPIHelper
    {
        public Task<string> PostRequestAsync(string url, object postData, string token);
        public Task<string> GetRequestAsync(string url, string token);
        public Task<string> PutRequestAsync(string url, object postData, string token);
    }
}
