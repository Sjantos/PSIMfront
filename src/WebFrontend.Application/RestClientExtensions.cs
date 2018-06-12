using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebFrontend
{
    public static class RestClientExtensions
    {
        public static async Task<T> EnsureSuccess<T>(this Task<IRestResponse<T>> requestTask)
        {
            var response = await requestTask;
            if (!response.IsSuccessful)
                throw new ApplicationHttpRequestException(response);

            return response.Data;
        }
    }
}
