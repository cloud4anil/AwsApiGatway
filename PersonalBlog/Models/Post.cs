

namespace PersonalBlog.Models
{
    using Amazon.DynamoDBv2.DataModel;
    using System;

    
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
            PostDate = DateTime.Now.ToShortDateString();
        }

      
        public string Id { get; private set; }  
        public string PostDate { get; private set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
