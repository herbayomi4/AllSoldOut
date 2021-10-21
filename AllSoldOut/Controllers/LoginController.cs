using AllSoldOut.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AllSoldOut.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logon(User user)
        {
            var userData = await _context.users.FindAsync(user.email);
            if (userData != null)
            {                
                if (PasswordHash.Verify(user.password, userData.password))
                {
                    HttpContext.Session.SetInt32("role", userData.roleId);
                }
                else
                {
                    ViewBag.errorMessage = "Kindly reconfirm you have entered your password correctly";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.errorMessage = "Email Address provided is not registered";
                return View("Index");
            }

            if (HttpContext.Session.GetInt32("role") == 1)
            {
                return RedirectToAction("Index", "Store");
            }
            return RedirectToAction("Index", "Home");
        }

        
    }
}
