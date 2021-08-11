using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MyContext dbContext;
 
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

            [HttpGet("")]
            
        public IActionResult Index()
        {
    //         // Get all Users
    //         ViewBag.AllDishes = dbContext.Dishes.ToList();
    
    //         ViewBag.MostRecent = dbContext.Dishes
    // .OrderByDescending(u => u.CreatedAt)
    // .Take(5)
    // .ToList();

	return View();
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

// Inside HomeController
// [HttpGet("update/{userId}")]
// public IActionResult UpdateUser(int chefId)
// {
//     // We must first Query for a single User from our Context object to track changes.
//     Dishes RetrievedUser = dbContext.Dishes
//         .FirstOrDefault(user => user.ChefId == chefId);
//     // Then we may modify properties of this tracked model object
//     RetrievedUser.Name = "New Name";
//     RetrievedUser.ChefName = "New Chef Name";
//     RetrievedUser.Tastiness = 0;
//     RetrievedUser.Calories = 0;
//     RetrievedUser.Discription = "New Discription";
//     RetrievedUser.UpdatedAt = DateTime.Now;
//     RetrievedUser.CreatedAt = DateTime.Now;
    
//     // Finally, .SaveChanges() will update the DB with these new values
//     dbContext.SaveChanges();
    
//     // Other code
//     return View();
// }


        
       
    }
