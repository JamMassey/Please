﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication.Models;

//Windows Migration
namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        
        private DataContext db;
        private UserListViewModel userListVM = null;
        private PostListViewModel postListVM = null;

        public HomeController(DataContext _db )
        {
            db = _db;
             
            UserListViewModel _userListVM = new UserListViewModel();
            _userListVM.Users = db.Users.ToList<User>(); //Get user list from database
            userListVM = _userListVM;

            PostListViewModel _postListVM = new PostListViewModel();
            _postListVM.Posts = db.Posts.ToList<Post>(); //Get post list from database
            postListVM = _postListVM;
        }

        //Returns Index View
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Returns UserList View, passing it the list of users.
        [HttpGet]
        public IActionResult UserList()
        {
            return View(userListVM);    //Give user list to view
        }

        //Returns Login View.
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        //Returns Register View.
        [HttpGet]
        public IActionResult Register()
        {          
            return View("Register");
        }

        //Returns Home View.
        [HttpGet]
        public IActionResult Home()
        { 
            return View(postListVM);        //Give post list to view
        }

        [HttpGet]
        public IActionResult Signout()
        {
            HttpContext.Session.Remove("CurrentUser");   //Clear session data
            return View("Index");        //Give post list to view
        }

        
        //Handles a submitted login attempt
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            foreach (WebApplication.Models.User u in userListVM.Users)
            {
                if (userName == u.UserName)    //Checks if username entered matches a username in thedb.
                {
                    if (password == u.Password)     //Then checks if correspondingpasswords match.
                    {                       
                        HttpContext.Session.SetString("CurrentUser", userName); //Set username for this session.
                        return RedirectToAction("Home");    //Open Home
                    }
                }
            }
                
            return View("Login");   //On fail return to login.
        }

        //Handles post submissions.
        [HttpPost]
        public IActionResult Home(string postMessage)
        {
            Post post = new Post();            //Create a new post.
            post.PostMessage = postMessage;     //Given string from input box on Home View.           
            post.UserName = HttpContext.Session.GetString("CurrentUser");    //Assigns username from session data.
            db.Posts.Add(post);
            db.SaveChanges();   //Updates db.
            postListVM.Posts = db.Posts.ToList<Post>(); //Update post list. Prevents delay.
            return View(postListVM);    //Returns the view with list.
        }

        //Handles a registration attempt.
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid) 
            {
                foreach (WebApplication.Models.User u in userListVM.Users)  
                {
                    if (user.UserName == u.UserName)    //Checks if Username matches any in db.
                    {
                       
                        return View("Register");    //If so return register again.
                    }
                }
                db.Users.Add(user);     //Else updates db with the user.
                db.SaveChanges();
                   
                return RedirectToAction("UserList");    //And returns a list of users
            }

            return View("Register");    //Returns to register if invalid model.
        }

    }
}