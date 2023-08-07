using Flurl;
using Flurl.Http;

namespace GoNotifyMe.Clients
{
    internal class ApiClient
    {
        private readonly string token;
        private readonly string baseURL;
        private readonly string userAgent;
        public ApiClient(string token, string? userAgent)
        {
            this.token = token;
            this.userAgent = userAgent ?? @"GMSharp by Amy/1.0";
            baseURL = "https://gomarket.com.do/api/";
        }
        /// <summary>
        /// Gets a list of all available products
        /// </summary>
        /// <returns>A product list</returns>
        public ProductList GetAllProducts()
        {
            try
            {
                var result = baseURL.AppendPathSegment("v1/products")
                                          .WithHeader("X-Spree-Token", value: token)
                                          .WithHeader("User_Agent", value: userAgent)
                                          .GetJsonAsync<ProductList>()
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
