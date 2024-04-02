using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using System.Linq;
using System.Collections.Generic;

namespace dotnetapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("View");
                //  return RedirectToAction(nameof(View));
            }
            return View(product);
        }

        // GET: Product/View
        public IActionResult View()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

    }
}