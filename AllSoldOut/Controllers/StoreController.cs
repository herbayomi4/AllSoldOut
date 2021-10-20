using AllSoldOut.Models;
using AllSoldOut.ViewModel;
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
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private  ApplicationDbContext _context;
        private IHostingEnvironment _env;
        public StoreController(ApplicationDbContext context, ILogger<StoreController> logger, IHostingEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }


        //Returns a list of available products in the products
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.products.Where(x => x.available == true).OrderByDescending(x =>x.dateCreated) .ToListAsync();

            return View("index", products);
        }

        //Returns the Create project page 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Create the product and calls a method "SaveImage" that saves the upploaded image in the www root folder 
        [HttpPost]
        public async Task<IActionResult> OnCreate (Product products, Specifications specifications, IFormFile productImage)
        {
            products.quantityAvailable = products.inStock;
            
            await _context.products.AddAsync(products);
            //Adding Date 
            products.dateCreated = DateTime.Now;

            //Saving the filename to db & the file to folder
            if (productImage != null)
            {
                string fileName = products.productName + "_" + RandomString(4);
                this.SaveImage(productImage, fileName);
                products.productImageName = fileName;
            }

            await _context.specifications.AddAsync(specifications);
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
                var product = await _context.products.Where(x => x.productId == id).FirstOrDefaultAsync();
                var spec = await _context.specifications.Where(x => x.productId == id).FirstOrDefaultAsync();

                PhoneDetailsViewModel phone = new PhoneDetailsViewModel()
                {
                    products = product,
                    specifications = spec,
                };
                ViewBag.path = Url.Content("~/Files/"+(phone.products.productImageName).ToString()+".png");
                return View("Details", phone);
                //return Json(phone);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpGet]
        //public IActionResult SalesDetails(int id)
        //{
        //    var data = from products in _context.Set<Phone>()
        //               join sales in _context.Set<Sales>()
        //               on products.salesId equals sales.salesId
        //               select new { products, sales };
        //    return View("Details", data);
        //}

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.products.Where(x => x.productId == id).FirstOrDefaultAsync();
            var spec = await _context.specifications.Where(x => x.productId == id).FirstOrDefaultAsync();

            var phoneCategory = await _context.phoneMakers.Select(x => new { x.makerName }).AnyAsync();

            PhoneCreateViewModel phone = new PhoneCreateViewModel()
            {
                products = product,
                specifications = spec,
                //phoneMakers = phoneCategory,
            };
            ViewBag.path = Url.Content("~/Files/" + (phone.products.productImageName).ToString() + ".png");
            ViewBag.fileName = (phone.products.productImageName).ToString() + ".png";

            //Getting the Phone Categories.
            
            return View("Edit", phone);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product products, Specifications specifications, IFormFile productImage)
        {
            if (ModelState.IsValid)
            {
                var data = await _context.products.Where(x => x.productId == products.productId).FirstOrDefaultAsync(); 
                data.productName = products.productName;
                data.productCategory = products.productCategory;
                data.productDescription = products.productDescription;
                data.productPrice = products.productPrice;
                data.productColor = products.productColor;

                products.dateCreated = DateTime.Now;

                //Saving the filename to db & the file to folder
                if (productImage != null)
                {
                    string fileName = products.productName + "_" + RandomString(4);
                    this.SaveImage(productImage, fileName);
                    data.productImageName = fileName;
                }


                //Updating the Specifications
                var spec = await _context.specifications.Where(x => x.productId == products.productId).FirstOrDefaultAsync();
                spec.launchDate = specifications.launchDate;
                spec.bodyDimension = specifications.bodyDimension;
                spec.bodyWeight = specifications.bodyWeight;
                spec.displayResolution = specifications.displayResolution;
                spec.displaySize = specifications.displaySize;
                spec.platformOS = specifications.platformOS;
                spec.ram = specifications.ram;
                spec.internalMemory = specifications.internalMemory;
                spec.camera = specifications.camera;
                spec.batteryStandbyTime = specifications.batteryStandbyTime;


                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Details", new { id = products.productId });

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var phone = await _context.products.Where(x => x.productId == id).FirstOrDefaultAsync();
             _context.products.Remove(phone);

            var spec = await _context.specifications.Where(x => x.productId == id).FirstOrDefaultAsync();
            _context.specifications.Remove(spec);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
