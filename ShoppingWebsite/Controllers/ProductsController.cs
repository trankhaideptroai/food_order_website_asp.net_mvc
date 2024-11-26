using Microsoft.AspNetCore.Mvc;
using ShoppingWebsite.Interfaces;

namespace ShoppingWebsite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(string searchString, string sortOrder)
        {
            var products = _productService.GetAllProducts(searchString, sortOrder);
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
    