using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace ApiTestFramework.Base
{
    public class RestLibrary
    {
        public RestClient Client { get; private set; }
        public RestLibrary()
        {
            Client = new RestClient("https://petstore.swagger.io");

        }

        public async Task<RestResponse> GetMethod(RestRequest request)
        {
            var response = await Client.GetAsync(request);
            return response;
        }

        public async Task<RestResponse> PostMethod(RestRequest request)
        {
            var response = await Client.PostAsync(request);
            return response;
        }

        public async Task<RestResponse> PutMethod(RestRequest request)
        {
            var response = await Client.PutAsync(request);
            return response;
        }

        public async Task<RestResponse> DeleteMethod(RestRequest request)
        {
            var response = await Client.DeleteAsync(request);
            return response;
        }

        public T ReturnMethod<T>(RestResponse response)
        {
            var resres = JsonConvert.DeserializeObject<T>(response.Content);
            return resres;
        }

        //public string SetClient()
        //{
        //    Client = new RestClient("https://petstore.swagger.io");
        //    return Client;
        //}
    }
}
