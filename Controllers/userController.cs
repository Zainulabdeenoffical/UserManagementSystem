
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using UserManagementSystem.data;
using UserManagementSystem.Models;
using UserManagementSystem.Models.Entites;

namespace UserManagementSystem.Controllers
{
    public class userController : Controller
     
    {
        private readonly ApplicationDbContext dbContext;

        public userController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.MessageSucces = "User Add Successfully";
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Add(Adduserviewmodel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Frist_name = viewModel.Frist_name,
                    last_name = viewModel.last_name,
                    Email = viewModel.Email
                };
                await dbContext.User.AddAsync(user);
                await dbContext.SaveChangesAsync();
                //TempData["Message Succes"] = "User Add Successfully";
                ViewBag.MessageSucces = "User Add Successfully";
                return RedirectToAction("Add");
            }
            return View(viewModel);
        }
        [HttpGet]
        public async Task <IActionResult> list()
        {
           var user = await dbContext.User.ToListAsync();
            return View(user);
        }
        [HttpGet]
        public async Task <IActionResult> Edit(Guid Id)
        {
            var user = await dbContext.User.FindAsync(Id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User viewmodel)
        {
            var user = await dbContext.User.FindAsync(viewmodel.Id);
            if (user is not null)
            {
                user.Frist_name = viewmodel.Frist_name;
                user.last_name = viewmodel.last_name;
                user.Email = viewmodel.Email;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("list", "User");  
        }
        [HttpPost]
        public async Task<IActionResult> Delete(User viewmodel)
        {
            var user = await dbContext.User
            .AsNoTracking()    
            .FirstOrDefaultAsync(x => x.Id == viewmodel.Id);
            if (user is not null)
            {
                dbContext.User.Remove(viewmodel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("list", "User");
        }


    }
} 


