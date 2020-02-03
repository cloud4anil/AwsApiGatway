using PersonalBlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlogApi.Interfaces
{
    public interface IDataService
    {
        Task PostBlog(Post model);
        Task<List<Post>> GetAllBlog();
    }
}
