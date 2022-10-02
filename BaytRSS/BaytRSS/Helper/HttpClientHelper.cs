using System;
using System.Net.Http.Headers;
using System.Net.Http;

namespace BaytRSS.Helper
{
    public static class HttpClientHelper
    {
        public static string HttpGet(string baseAddress, string endPoint)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.
                    Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var response = client.GetAsync(endPoint).Result;
                if (response.IsSuccessStatusCode)
                {
                    var payload = response.Content.ReadAsStringAsync().Result;
                    return payload;
                }
                else
                {
                    throw new HttpRequestException("The targeted Api is not working");
                }
            }
        }
    }
}