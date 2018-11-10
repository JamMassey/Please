using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

//Windows Migration
namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db;
        private UserListViewModel userListVM = null;

        public HomeController(DataContext _db )
        {
            db = _db;
            UserListViewModel _userListVM = new UserListViewModel();
            _userListVM.Users = db.Users.ToList<User>(); //Get list from database
            userListVM = _userListVM;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserList()
        {

            return View(userListVM);    //Give list to view
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            
            return View("Register");
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View("Home");
        }

        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {
            foreach (WebApplication.Models.User u in userListVM.Users)
            {
                if (UserName == u.UserName)    //Checks if Username is unique
                {
                    if (Password == u.Password)
                    {
                        return View("Home");
                    }
                }               
            }

            return View("Login");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                foreach (WebApplication.Models.User u in userListVM.Users)
                {
                    if (user.UserName == u.UserName)    //Checks if Username is unique
                    {
                       
                        return View("Register");
                    }
                }
                db.Users.Add(user);
                db.SaveChanges();
                   
                return RedirectToAction("UserList");
            }

            return View("Register");
        }

    }
}