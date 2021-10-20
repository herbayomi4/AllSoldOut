using AllSoldOut.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ILogger<ShoppingCartController> _logger;

        private ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context, ILogger<ShoppingCartController> logger)
        {
            _logger = logger;
            _context = context;
        }

        // GET: ShoppingCartController
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Details(int id)
        {
            return View();
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
