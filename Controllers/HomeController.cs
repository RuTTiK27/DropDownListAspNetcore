using DropDownListAspNetcore.Data;
using DropDownListAspNetcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DropDownListAspNetcore.Controllers
{
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly UserDbContext context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(UserDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem{Value="1",Text="Male"},
                new SelectListItem{Value="2",Text="Female"},
            };

            ViewBag.Gender = Gender;
            //---
            var users = BindDDL();
            return View(users);
            
            //var users = context.Users.ToList();
            //return View(users);
        }
        [HttpPost]
        public IActionResult Index(UserModel userModel)
        {
            var user = context.Users.Where(u=>u.Id == userModel.Id).FirstOrDefault();
            if (user != null)
            {
                ViewBag.selectedValue = user.Name;
            }
            var users = BindDDL();
            return View(users);
        }
        private UserModel BindDDL()
        {
            UserModel userModel = new UserModel();
            userModel.UsersList = new List<SelectListItem>();

            var data = context.Users.ToList();

            userModel.UsersList.Add(new SelectListItem
            {
                Text = "Select User",
                Value = ""
            });

            foreach (var item in data)
            {
                userModel.UsersList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return userModel;
        }
        public IActionResult Create()
        {
            List<SelectListItem> Age = new();
            for (int i = 18; i < 66; i++)
            {
                Age.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
            ViewBag.Age = Age;
            return View();
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
