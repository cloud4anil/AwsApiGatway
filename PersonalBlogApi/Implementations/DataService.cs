using Amazon.DynamoDBv2.DataModel;
using PersonalBlogApi.Interfaces;
using PersonalBlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlogApi.Implementations
{
    public class DataService : IDataService
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        public DataService(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDBContext = dynamoDbContext;
        }
        public async Task<List<Post>> GetAllBlog()
        {
            return await _dynamoDBContext.ScanAsync<Post>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task PostBlog(Post model)
        {
             await _dynamoDBContext.SaveAsync<Post>(model);
        }
    }
}
