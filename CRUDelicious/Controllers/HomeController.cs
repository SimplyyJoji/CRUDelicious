using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;
using CRUDelicious.Migrations;
using Microsoft.EntityFrameworkCore;


namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
    //Read
        [HttpGet("")]
        public IActionResult Index()
    {
        List<Dishes> AllDishes = _context.Dishes.ToList();
            return View(AllDishes);  
    }
        
        
        [HttpGet("{chefId}")]
        public IActionResult OneDish(int ChefId)
    {
        Dishes oneDish = _context.Dishes.FirstOrDefault(id =>id.ChefId == ChefId);
        return View(oneDish); 
    }



    //Create
    [HttpGet("/dish/new")]
public IActionResult New()
{

    return View("New");
}

    [HttpPost("/dish/new")]
public IActionResult New(Dishes newDish)
{
    if (ModelState.IsValid == false)
    {
        return View("New");
    }
        _context.Dishes.Add(newDish);
            // db doesn't update until we run save changes
            // after SaveChanges, our newPost object now has it's PostId updated from db auto generated id
        _context.SaveChanges();
            // db doesn't update until we run save changes
            // after SaveChanges, our newPost object now has it's PostId updated from db auto generated id
        return RedirectToAction("Index");
        }

        //Update
[HttpGet("dishes/{chefId}/edit")]
public IActionResult Edit(int chefId)
{
    // We must first Query for a single User from our Context object to track changes.
    Dishes newDish = _context.Dishes.FirstOrDefault(user => user.ChefId == chefId);
    // Then we may modify properties of this tracked model object
            if (newDish == null)
            {
                return RedirectToAction("Index");
            }
    
    
    // Finally, .SaveChanges() will update the DB with these new values
    
    // Other code
    return View("Edit", newDish);
} 

    [HttpPost("/dishes/{chefId}/update")]
    public IActionResult Update(int chefId, Dishes editedDish)
        {
            if (ModelState.IsValid == false)
            {
                editedDish.ChefId = chefId;
                return View("Edit", editedDish);
            }
            Dishes newDish = _context.Dishes.FirstOrDefault(p => p.ChefId == chefId);

            if (newDish == null)
            {
                return RedirectToAction("Index");
            }

            newDish.Name = editedDish.Name;
            newDish.ChefName = editedDish.ChefName;
            newDish.Tastiness = editedDish.Tastiness;
            newDish.Calories = editedDish.Calories;
            newDish.Discription = editedDish.Discription;
            newDish.UpdatedAt = DateTime.Now;

            return View("Edit", editedDish);
        }

     //Delete
    [HttpGet("delete/{chefId}")]
public IActionResult Delete(int chefId)
{
    // Like Update, we will need to query for a single user from our Context object
    Dishes dish  = _context.Dishes
        .SingleOrDefault(delete => delete.ChefId == chefId);
    
    // Then pass the object we queried for to .Remove() on Users
    _context.Dishes.Remove(dish);
    
    // Finally, .SaveChanges() will remove the corresponding row representing this User from DB 
    _context.SaveChanges();
    // Other code
    return RedirectToAction("Index");
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
