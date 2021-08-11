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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // public HomeController(MyContext context)
        // {
        //     _context = context;
        // }

        private MyContext dbContext;
 
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

            [HttpGet("")]
        public IActionResult Index()
        {
            // Get all Users
            ViewBag.AllDishes = dbContext.Dishes.ToList();
    
            // Get Users with the LastName "Jefferson"
            // ViewBag.Jeffersons = dbContext.Dishes
            //     .Where(u => u.Name == "Jefferson");
    	    // Get the 5 most recently added Users
            ViewBag.MostRecent = dbContext.Dishes
    .OrderByDescending(u => u.CreatedAt)
    .Take(5)
    .ToList();

	return View();
    }
    [HttpPost("create")]
public IActionResult CreateUser(Dishes newDish)
{
    // We can take the User object created from a form submission
	// And pass this object to the .Add() method
    dbContext.Add(newDish);
    // OR dbContext.Users.Add(newUser);
    dbContext.SaveChanges();
    // Other code
    return View();
}

// Inside HomeController
[HttpGet("update/{userId}")]
public IActionResult UpdateUser(int chefId)
{
    // We must first Query for a single User from our Context object to track changes.
    Dishes RetrievedUser = dbContext.Dishes
        .FirstOrDefault(user => user.ChefId == chefId);
    // Then we may modify properties of this tracked model object
    RetrievedUser.Name = "New Name";
    RetrievedUser.Tastiness = 0;
    RetrievedUser.Calories = 0;
    RetrievedUser.Discription = "New Discription";
    RetrievedUser.UpdatedAt = DateTime.Now;
    RetrievedUser.CreatedAt = DateTime.Now;
    
    // Finally, .SaveChanges() will update the DB with these new values
    dbContext.SaveChanges();
    
    // Other code
    return View();
}

[HttpGet("delete/{chefId}")]
public IActionResult DeleteDish(int chefId)
{
    // Like Update, we will need to query for a single user from our Context object
    Dishes RetrievedUser = dbContext.Dishes
        .SingleOrDefault(user => user.ChefId == chefId);
    
    // Then pass the object we queried for to .Remove() on Users
    dbContext.Dishes.Remove(RetrievedUser);
    
    // Finally, .SaveChanges() will remove the corresponding row representing this User from DB 
    dbContext.SaveChanges();
    // Other code
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
}
