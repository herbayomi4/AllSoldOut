using AllSoldOut.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AllSoldOut.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        public ApplicationDbContext _context;
        private IHostingEnvironment _env;
        public AdminController(ApplicationDbContext context, ILogger<AdminController> logger, IHostingEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }


        //Returns a list of available products in the store
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var store = await _context.phones.Where(x => x.available == true).ToListAsync();
            return View("index", store);
        }

        //Returns the Create project page 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Create the product and calls a method "SaveImage" that saves the upploaded image in the www root folder 
        [HttpPost]
        public async Task<IActionResult> Store (Phone store, IFormFile productImage)
        {
            if (productImage !=null)
            {
                string fileName = store.productName + "_" + RandomString(4);
                this.SaveImage(productImage, fileName);
                store.productImageName = fileName;
            }
            await _context.phones.AddAsync(store);
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Get RandomString for the File Name
        public string RandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uBuffer);
                    uint num = BitConverter.ToUInt32(uBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }

        //Save Image
        public void SaveImage(IFormFile formFile, string fileName)
        {
            string wwwPath = this._env.WebRootPath;
            //string contentPath = this._env.ContentRootPath;

            string path = Path.Combine(wwwPath, "Files");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string picName = Path.GetFileName(fileName+".png");
            using (FileStream stream = new FileStream(Path.Combine(path, picName), FileMode.Create))
            {
                formFile.CopyTo(stream);
                //ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }
        }



        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var data = await _context.phones.Where(x => x.productId == id).FirstOrDefaultAsync();
                ViewBag.path = Url.Content("~/Files/"+(data.productImageName).ToString()+".png");
                return View("Details", data);
                //return Json(data);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpGet]
        //public IActionResult SalesDetails(int id)
        //{
        //    var data = from phones in _context.Set<Phone>()
        //               join sales in _context.Set<Sales>()
        //               on phones.salesId equals sales.salesId
        //               select new { phones, sales };
        //    return View("Details", data);
        //}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _context.phones.Where(x => x.productId == id).FirstOrDefaultAsync();
            return View("Edit", data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Phone store)
        {
            if (ModelState.IsValid)
            {
                var data = await _context.phones.FindAsync(store.productId);
                data.productName = store.productName;
                data.productCategory = store.productCategory;
                data.productDescription = store.productDescription;
                data.productPrice = store.productPrice;

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", new { id = store.productId });

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.phones.Where(x => x.productId == id).FirstOrDefaultAsync();
             _context.phones.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
