using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace ApiFetcher
{
    public class Fetcher
    {
        private static readonly HttpClient client = new HttpClient();
        private static string Data { get; set; }
        public static async Task<string> FetchDataAsync(string url)
        {
            if (!string.IsNullOrEmpty(url))
                try
                {
                    // string URL = "https://jsonplaceholder.typicode.com/posts";
                    string FormatedUrl = string.Format(url);
                    WebRequest RequestObject = WebRequest.Create(FormatedUrl);
                    RequestObject.Method = "GET";
                    string Result;
                    using (client)
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {

                            Result = await response.Content.ReadAsStringAsync();
                            Data = Result;
                            return Data;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            return Data;
        }
    }
}