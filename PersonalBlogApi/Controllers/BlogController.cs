using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalBlogApi.Interfaces;
using PersonalBlogApi.Models;

namespace PersonalBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IDataService _dataService;
        public BlogController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<List<Post>> Get()
        {
            var list = new List<Post>();
            try
            {

                list = await _dataService.GetAllBlog();
                return list;
            }catch(Exception ex)
            {
                return list;
            }
        }

       
        [HttpPost]
        public async Task Post([FromBody] Post model)
        {
            var db = new Post();
            db.Title = model.Title;
            db.Content = model.Content;
            db.PostDate = DateTime.Now.ToShortDateString();
           await _dataService.PostBlog(db);
           
            
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
