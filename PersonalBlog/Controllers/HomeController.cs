using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Interfaces;
using PersonalBlog.Models;

namespace PersonalBlog.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;
        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }
    
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _dataService.GetAllBlog();
                return View(list);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
       
        [HttpGet]
        public IActionResult Blog()
        {          
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Blog(Post model)
        {
            try
            {
                await _dataService.PostBlog(model);
                return RedirectToAction("Index", model);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
