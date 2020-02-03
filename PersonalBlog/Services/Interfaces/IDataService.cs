using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.Interfaces
{
    public interface IDataService
    {
        Task PostBlog(Post model);
        Task<List<Post>> GetAllBlog();
    }
}
