using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        // Constructor to inject the dbContext
        public OrderController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
