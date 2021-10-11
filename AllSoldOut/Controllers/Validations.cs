using AllSoldOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.Controllers
{
    public class Validations : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly ILogger _logger;

        public Validations(ApplicationDbContext db, ILogger logger)
        {
            _db = db;
            _logger = logger;
        }

        //public IActionResult VerifyEmail(string email)
        //{
        //    var data = _db.sales.FirstOrDefault(x => x.email == email);
        //    if(data != null)
        //    {
        //        return Json($"Email {email} is already in use.");
        //    }

        //    return Json(true);
        //}
    }
}
