using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using R4CloThes.Client.Models;

namespace R4CloThes.Client.Helpers
{
    public class APIHelper : IAPIHelper
    {
        public IConfiguration _config;

        public APIHelper(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetRequestAsync(string url, string token)
        {
            var urlapi = _config.GetSection("API")["APIUrl"].ToString();
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage res = await client.GetAsync(urlapi + url);
                    if (res.IsSuccessStatusCode)
                    {
                        return res.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return "-1";
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        public async Task<string> PostRequestAsync(string url, object postData, string token)
        {
            var urlapi = _config.GetSection("API")["APIUrl"].ToString();
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
                    HttpResponseMessage res = await client.PostAsync(urlapi + url, content);
                    if (res.IsSuccessStatusCode)
                    {
                        return res.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return "-1";
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
        }

        public async Task<string> PutRequestAsync(string url, object postData, string token)
        {
            var urlapi = _config.GetSection("API")["APIUrl"].ToString();
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    StringContent content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
                    HttpResponseMessage res = await client.PutAsync(urlapi + url, content);
                    if (res.IsSuccessStatusCode)
                    {
                        return res.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return "-1";
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
    }
}
