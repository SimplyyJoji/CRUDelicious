using System.Collections.Generic;
using System.Linq;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDelicious.Controllers
{
    public class DishForm : Controller
    {
    private MyContext dbContext;
 
        public DishForm(MyContext context)
        {
            dbContext = context;
        }

[HttpGet("/dish/new")]
public IActionResult New()
{

    return View("New");
}

    [HttpPost("/dish/create")]
public IActionResult Create(Dishes newDish)
{
    if (ModelState.IsValid == false)
    {
        return View("New");
    }
        dbContext.Dishes.Add(newDish);
            // db doesn't update until we run save changes
            // after SaveChanges, our newPost object now has it's PostId updated from db auto generated id
        dbContext.SaveChanges();
            // db doesn't update until we run save changes
            // after SaveChanges, our newPost object now has it's PostId updated from db auto generated id
        return RedirectToAction("/Home/Index");
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
        
    }
}