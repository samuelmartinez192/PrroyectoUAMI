using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrroyectoUAMI.Repository
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }
        public string URI { get; set; }

        public ServiceRepository()
        {
            Client = new HttpClient();
            URI = "http://localhost:52664/";
            Client.BaseAddress = new Uri(URI);
        }

        public ServiceRepository(string uri)
        {
            Client = new HttpClient();
            URI = uri;
            Client.BaseAddress = new Uri(URI);
        }

        public HttpResponseMessage GetReponse(string url)
        {
            return Client.GetAsync(url).Result;
        }

        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }

        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}
