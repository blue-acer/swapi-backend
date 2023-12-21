using Newtonsoft.Json;
using System.Net;
namespace swapi_backend.Client
{
    public class BaseClass:HttpClient
    {
        private enum HttpMethod
        {
            GET
        }

        private string BaseUri = "https://swapi.dev/api";

        public string getBaseUri()
        {
            return BaseUri;
        }

        public BaseClass() { }

        public async Task<HttpResponseMessage> getSpecific(string address)
        {
            try
            {
                return await this.GetAsync($"{address}");
            }
            catch (Exception)
            {
                throw new Exception("Request failed");
            }
        }
        public async Task<HttpResponseMessage> getSearch(string name)
        {
            try
            {
                return await this.GetAsync($"{BaseUri}/people/?search={name}");
            }
            catch (Exception)
            {
                throw new Exception("Request failed");
            }
        }
    }
}
