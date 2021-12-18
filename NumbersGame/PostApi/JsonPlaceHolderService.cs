using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NumbersGame.PostApi
{
    public class JsonPlaceHolderService
    {
        public async Task<IEnumerable<JsonPlaceHolderResponse>> GetData()
        {
            string jsonUrl = ConfigurationManager.AppSettings["JsonPlaceholderUrl"].ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(jsonUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("posts");
            var result = await response.Content.ReadAsAsync<IEnumerable<JsonPlaceHolderResponse>>();
            return result;
        }
    }
}
