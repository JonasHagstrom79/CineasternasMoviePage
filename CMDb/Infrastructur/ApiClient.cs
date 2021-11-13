using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CMDb.Infrastructur
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            try
            {
                using var response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<T>(responseJson);
                    return data;
                }

                #region Http Error codes
                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    throw new Exception("429:To many requests to api");
                }
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception("400: The request could not be understood by the api-server");
                }
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("401: The request could not be authorized by the api-server");
                }
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new Exception("403: The request was refused by the api-server");
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("404: The requested resource dos not exist on the api-server");
                }
                if (response.StatusCode == HttpStatusCode.RequestTimeout)
                {
                    throw new Exception("408: The request was not sent within the expected time");
                }
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new Exception("500: A generic error has occured on the api-server");
                }
                if (response.StatusCode == HttpStatusCode.BadGateway)
                {
                    throw new Exception("502: Bad response from proxy or the api-server");
                }
                if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    throw new Exception("503: The api-server is temporally unavailable");
                }
                if (response.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    throw new Exception("504: An intermediate proxy server timed out while waiting for response by the api-server");
                }

                throw new Exception("Bad api request"); 
                #endregion


            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
