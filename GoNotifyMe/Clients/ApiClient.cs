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
        public ApiProductList GetAllProducts(int MaxItemsPerPage = 25)
        {
            try
            {
                var result = baseURL.AppendPathSegment("v1/products")
                                          .WithHeader("X-Spree-Token", value: token)
                                          .WithHeader("User_Agent", value: userAgent)
                                          .SetQueryParam("per_page", MaxItemsPerPage)
                                          .GetJsonAsync<ApiProductList>()
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

        /// <summary>
        /// Gets a singular product
        /// </summary>
        /// <returns>A product</returns>
        public ApiProduct GetProduct(int ProductId)
        {
            try
            {
                var result = baseURL.AppendPathSegment($"v1/products/{ProductId}")
                                          .WithHeader("X-Spree-Token", value: token)
                                          .WithHeader("User_Agent", value: userAgent)
                                          .GetJsonAsync<ApiProduct>()
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

        /// <summary>
        /// Gets a Variant
        /// </summary>
        /// <returns>A Variant</returns>
        public ApiProductVariant GetVariant(int VariantId)
        {
            try
            {
                var result = baseURL.AppendPathSegment($"v1/variants/{VariantId}")
                                    .WithHeader("X-Spree-Token", value: token)
                                    .WithHeader("User_Agent", value: userAgent)
                                    .GetJsonAsync<ApiProductVariant>()
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
