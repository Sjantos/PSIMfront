using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebFrontend
{
    public class ApplicationHttpRequestException : Exception
    {
        public IRestResponse Response { get; }

        public ApplicationHttpRequestException(IRestResponse response)
        {
            Response = response;
        }
    }
}
