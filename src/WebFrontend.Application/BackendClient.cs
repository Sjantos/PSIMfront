using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebFrontend.Entities;

namespace WebFrontend
{
    public class BackendClient
    {
        private RestClient Client { get; }

        public BackendClient()
        {
            Client = new RestClient
            {
                //BaseUrl = new Uri($"http://localhost:5001/api/")
                BaseUrl = new Uri($"https://limitless-sands-93657.herokuapp.com/api/")
            };
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            var request = new RestRequest("Posts", Method.GET);
            //return Client.ExecuteTaskAsync<IEnumerable<Post>>(request);//.EnsureSuccess();
            var result = await Client.ExecuteTaskAsync<IEnumerable<Post>>(request);
            return result.Data;
        }

        public Task<IRestResponse> CreateNewPost(Post post)
        {
            var request = new RestRequest("Posts", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("Application/Json", JsonConvert.SerializeObject(post), ParameterType.RequestBody);

            return Client.ExecuteTaskAsync(request);
        }

        public Task<IRestResponse> CreateComment(Comment comment)
        {
            var request = new RestRequest("Comment", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("Application/Json", JsonConvert.SerializeObject(comment), ParameterType.RequestBody);

            return Client.ExecuteTaskAsync(request);
        }

        public Task<IRestResponse> DownloadFile(int postId)
        {
            var request = new RestRequest("File/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("id", postId.ToString());

            return Client.ExecuteTaskAsync(request);
        }
    }
}
