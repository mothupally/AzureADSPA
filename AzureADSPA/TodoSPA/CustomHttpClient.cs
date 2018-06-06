using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using TodoSPA.Controllers;

namespace TodoSPA
{
    public class CustomHttpClient
    {
        HttpClient client;
        public CustomHttpClient(string bearer)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://demo-togo-api.azurewebsites.net")
            };
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearer);
        }

        public async Task<IEnumerable<ToGo>> GetAsync()
        {
           
            var response = await client.GetAsync("/api/togolist");
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ToGo>>(content);
        }

        public async Task<IEnumerable<ToGo>> PostAsync(ToGo item)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(item));
            var response = await client.PostAsync("/api/togolist", content);
            return await GetAsync();
        }
    }

    
}