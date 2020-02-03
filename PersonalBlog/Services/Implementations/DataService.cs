using Amazon.DynamoDBv2.DataModel;
using Newtonsoft.Json;
using PersonalBlog.Interfaces;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AwsSignatureVersion4;
using System.Text;
using Aws.Core.Interface;

namespace PersonalBlog.Implementations
{
    public class DataService : IDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAwsRequestSigner _awsRequestSigner;

        //private readonly IDynamoDBContext _dynamoDBContext;
        //public DataService(IDynamoDBContext dynamoDbContext)
        //{
        //    _dynamoDBContext = dynamoDbContext;
        //}
        //public async Task<List<Post>> GetAllBlog()
        //{
        //    return await _dynamoDBContext.ScanAsync<Post>(new List<ScanCondition>()).GetRemainingAsync();
        //}

        //public async Task PostBlog(Post model)
        //{
        //     await _dynamoDBContext.SaveAsync<Post>(model);
        //}

        public DataService(IHttpClientFactory httpClientFactory, IAwsRequestSigner awsRequestSigner)
        {
            _httpClientFactory = httpClientFactory;
            _awsRequestSigner = awsRequestSigner;
        }
        public async Task<List<Post>> GetAllBlog()
        {



            var client = _httpClientFactory.CreateClient("Blog");
            
            var _json = "";
            var _service = "execute-api";
            var _region = "us-east-1";
            var content = new StringContent(_json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress.ToString()+"prod"),
                Content = content
            };
            request = await _awsRequestSigner.Sign(request, _service, _region);
            var responseMessage= await client.SendAsync(request).Result.Content.ReadAsAsync<List<Post>>();           
            return responseMessage;
        }

        public async Task PostBlog(Post model)
        {
            var client = _httpClientFactory.CreateClient("Blog");            
            await client.PostAsJsonAsync("/prod", model);
        }
    }
}
