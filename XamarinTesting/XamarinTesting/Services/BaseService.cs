
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
 

namespace XamarinTesting.Services
{
    public class BaseService<T> where T:class
    {
        private readonly string BaseURL = "http://10.0.2.2:8005/api";
        public IEnumerable<T> GetRequest(string url)
        {

            var client = new RestClient(BaseURL);
            var request = new RestRequest(url, Method.Get);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IEnumerable<T>>(response.Content);
            }
            return default;

        }
        public T GetByIdRequest(string url)
        {

            var client = new RestClient(BaseURL);
            var request = new RestRequest(url, Method.Get);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            return default;

        }

        public string PostRequest()
        {
            return "";
        }
    }
}
