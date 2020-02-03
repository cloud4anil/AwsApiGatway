

namespace PersonalBlogApi.Models
{
    using Amazon.DynamoDBv2.DataModel;
    using System;

    [DynamoDBTable(tableName:"post")]
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }

        [DynamoDBHashKey]
        public string Id { get; set; }
  
        public string PostDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
