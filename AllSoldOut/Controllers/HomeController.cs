using AllSoldOut.Models;
using AllSoldOut.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AllSoldOut.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly CartContext _contextMemory;
        private IHostingEnvironment _env;

        public HomeController(ApplicationDbContext context, CartContext contextMemory, ILogger<HomeController> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _context = context;
            _contextMemory = contextMemory;
            _env = env;
        }

        public List<Object> cartObj = new List<object>();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _context.products.Where(x => x.available == true).OrderByDescending(x => x.dateCreated).ToListAsync();

            if (HttpContext.Session.GetInt32("countCart") == null)
            {
                HttpContext.Session.SetInt32("countCart", 0);
            }
            ViewBag.countCart = HttpContext.Session.GetInt32("countCart");

            return View("index", products);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.products.Where(x => x.productId == id).FirstOrDefaultAsync();
            var spec = await _context.specifications.Where(x => x.productId == id).FirstOrDefaultAsync();

            PhoneDetailsViewModel phone = new PhoneDetailsViewModel()
            {
                products = product,
                specifications = spec,
            };
            ViewBag.path = Url.Content("~/Files/" + (product.productImageName).ToString() + ".png");

            ViewBag.countCart = HttpContext.Session.GetInt32("countCart");
            return View("Details", phone);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(IFormCollection collection)
        {
            var product = await _context.products.FindAsync(Convert.ToInt32(collection["productId"]));
            Cart cart = new Cart();
            cart.productId = product.productId;
            cart.productName = product.productName;
            cart.productImageName = product.productImageName;
            cart.productPrice = product.productPrice;
            if (collection["quantity"] != "")
            {
                cart.quantity = Convert.ToInt32(collection["quantity"]);
            }
            else
            {
                cart.quantity = 1;
            }
            cart.total = product.productPrice * cart.quantity;

            await _contextMemory.carts.AddAsync(cart);
            await _contextMemory.SaveChangesAsync();

            int countCart = await _contextMemory.carts.CountAsync();
            HttpContext.Session.SetInt32("countCart", countCart);

            ViewBag.successMessage = product.productName + " has been successfully added to your cart!";

            return RedirectToAction("Details", new { id = product.productId });
            
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var data = await _contextMemory.carts.ToListAsync();
            ViewBag.sumOfTotal = await _contextMemory.carts.Select(y => y.total).SumAsync();

            Sales sales = new Sales();
            //sales.productId = data.
            ViewBag.countCart = HttpContext.Session.GetInt32("countCart");  
            return View("Checkout", data);
        }    

        [HttpPost]
        public async Task<IActionResult> ProcessOrder(IFormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Checkout");
            }
            Customer customer = new Customer();
            customer.firstName = collection["firstName"];
            customer.lastName = collection["lastName"];
            customer.email = collection["email"];
            customer.contact = collection["contact"];
            customer.address = collection["address"];
            customer.city = collection["city"];

            if(collection["password"].Count > 0)
            {
                //ValidatePassword(collection["password"], out string ErrorMessage);

                
                if (await _context.users.AnyAsync(x => x.email == collection["email"]))
                {
                    ViewBag.errorMessage = "Email is already registered on this platform, please login into your account.";
                    var data = await _contextMemory.carts.ToListAsync();
                    return View("Checkout", data);
                }
                User user = new User();
                user.firstName = collection["firstName"];
                user.lastName = collection["lastName"];
                user.email = collection["email"];
                user.password = PasswordHash.Hash(collection["password"]);
                user.contact = collection["contact"];
                user.address = collection["address"];
                user.city = collection["city"];
                user.roleId = 2;

                await _context.users.AddAsync(user);

            }
            await _context.customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            var cartItems = await _contextMemory.carts.ToListAsync();
            foreach (var item in cartItems)
            {
                Sales sales = new Sales();
                sales.productId = item.productId;
                sales.unitPrice = item.productPrice;
                sales.quantity = item.quantity;
                sales.salesPrice = item.total;
                sales.customerId = customer.customerId;
                sales.salesDate = DateTime.Now;

                await _context.sales.AddAsync(sales);

                _contextMemory.carts.Remove(item);

                var product = await _context.products.FindAsync(item.productId);  //Where(x => x.productId == item.productId).Select(y => y.quantityAvailable).FirstOrDefaultAsync();
                int quantityAvailable = product.quantityAvailable - item.quantity;
                product.quantityAvailable = quantityAvailable;

                await _context.SaveChangesAsync();

            }
            await _contextMemory.SaveChangesAsync();

            HttpContext.Session.SetInt32("countCart", 0);

            ViewBag.successMessage = "Congratulaions! Your has been submitted, you will receive your order in 24 hours";


            return RedirectToAction("Index");
        }


        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be less than or greater than 12 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
