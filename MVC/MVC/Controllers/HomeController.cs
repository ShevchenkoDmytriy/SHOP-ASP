﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Model;
namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            //var users = await db.users.ToListAsync();
            return View();
        }
        public async Task<IActionResult> Login()
        {
            //var users = await db.users.ToListAsync();
            return View();
        }
        public async Task<IActionResult> Registration()
        {
            //var users = await db.users.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(/*string Name,int Age*/Users user)
        {
            //var newUser = new Users { Name = Name, Age = Age };
            db.users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
