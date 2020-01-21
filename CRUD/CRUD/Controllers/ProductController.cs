using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CRUD.ViewModels;
using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace CRUD.Controllers
{
    public class ProductController : Controller
    {
        //connecting with database
        private readonly ProductDbContext _context;

        //constructor of productcontroller
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        //returns view to show all the products
        public IActionResult Index()
        {
            ProductIndexViewModel data = new ProductIndexViewModel
            {
                Products = _context.Products.ToList()
            };

            return View(data);
        }

        //returns form to create new product
        public IActionResult Create()
        {

            return View();
        }
    
        //creates new product
        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price
                };

                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("index", "product");
            }

            return View("~/Views/Product/Create.cshtml");
        }

        //returns form to update selected product
        public IActionResult Update(int ProductId)
        {
            if (!_context.Products.Any(p=>p.Id == ProductId))
            {
                return NotFound();
            }

            Product product = _context.Products.Find(ProductId);

            ProductViewModel data = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return View(data);

        }

        //updates selected product
        [HttpPost]
        public IActionResult Update(int ProductId, ProductViewModel model)
        {
            if (!_context.Products.Any(p => p.Id == ProductId))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Product product = _context.Products.Find(ProductId);
                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;

                _context.SaveChanges();

                return RedirectToAction("index", "product");
            }

            return View("~/Views/Product/Update.cshtml", model);

        }

        //deletes selected product
        public IActionResult Delete(int ProductId)
        {
            if (!_context.Products.Any(p => p.Id == ProductId))
            {
                return NotFound();
            }

            Product product = _context.Products.Find(ProductId);

            _context.Products.Remove(product);

            _context.SaveChanges();

            return RedirectToAction("index", "product");
        }


    }
}