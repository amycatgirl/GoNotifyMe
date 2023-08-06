using Flurl;
using Flurl.Http;
using GoNotifyMe.Classes;

namespace GoNotifyMe
{
    internal class Client
    {
        private readonly string token;
        private readonly string baseURL;
        private readonly string userAgent;
        public Client(string token, string? userAgent)
        {
            this.token = token;
            this.userAgent = userAgent ?? @"GMSharp by Amy/1.0";
            baseURL = "https://gomarket.com.do/api/";
        }

        public ApiProducts GetAllProducts()
        {
            try
            {
                ApiProducts result = baseURL.AppendPathSegment("v1/products")
                                          .WithHeader("X-Spree-Token", value: token)
                                          .WithHeader("User_Agent", value: userAgent)
                                          .GetJsonAsync<ApiProducts>()
                                          .Result;
                return result;
            }
            catch (FlurlHttpException exception)
            {
                var error = exception.GetResponseJsonAsync();

                Console.WriteLine($"Found error on URL '{exception.Call.Request.Url}': \n {error}");

                throw;
            }
        }
    }
}
