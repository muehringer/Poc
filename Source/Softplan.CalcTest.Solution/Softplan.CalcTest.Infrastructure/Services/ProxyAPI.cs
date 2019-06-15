using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Softplan.CalcTest.Infrastructure.Services
{
    public static class ProxyAPI
    {
        private static HttpClient httpClient;
        private static Uri uri;
        private static Task<string> result;
        
        public static double GetTaxesServices(string token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:52367");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = httpClient.GetAsync("api/taxajuros").Result;           

            if (response.IsSuccessStatusCode)
                result = response.Content.ReadAsStringAsync();

            return Convert.ToDouble(result.Result);
        }
    }
}
