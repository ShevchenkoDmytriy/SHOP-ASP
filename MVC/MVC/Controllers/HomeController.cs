
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
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> Registration()
        {
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
        [HttpPost]
        public IActionResult Login(Users user)
        {
            var existingUser = db.users.FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password);

            if (existingUser != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }
    }
}
