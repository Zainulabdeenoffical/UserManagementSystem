
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using UserManagementSystem.data;
using UserManagementSystem.Models;
using UserManagementSystem.Models.Entites;
using UserManagementSystem.Models.Requests;

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
        public async Task<IActionResult> Add(Adduserviewmodel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    First_name = viewModel.First_name,
                    Last_name = viewModel.Last_name,
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


        [HttpPost]
        public JsonResult AddUser([FromBody] AddUserReq userReq)
        {
            if (userReq == null)
            {
                return Json(new { success = false, message = "please Enter User Information" });
            }

            var user = new User()
            {
                First_name = userReq.FirstName,
                Last_name = userReq.LastName,
                Email = userReq.Email
            };
            dbContext.User.Add(user);
            dbContext.SaveChanges();
            return new JsonResult("user Added Successfully");
        }

        [HttpGet]
        public async Task<IActionResult> list()
        {
            var usersList = await dbContext.User.ToListAsync();
            //  ViewBag.Users = usersList;
            return View(usersList);
        }
        public async Task<IActionResult> List()
        {

            return View();
        }

        public IActionResult GetUserList()
        {
            var data = dbContext.User.ToList();
            return new JsonResult(data);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
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
                user.First_name = viewmodel.First_name;
                user.Last_name = viewmodel.Last_name;
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
         [HttpPost]
        public async Task<IActionResult> DeleteAll(Guid[] ids)
        {
            string result = string.Empty;
            try
            {
                if (ids.Length > 0)
                {
                    foreach (Guid id in ids)
                    {
                        var data = dbContext.User.Where(e => e.Id == id).FirstOrDefault();
                        if (data != null)
                        {
                            dbContext.User.Remove(data);
                        }
                    }
                    await dbContext.SaveChangesAsync();
                    TempData["Success"] = "Data Deleted Successfully";
                    result = "Success";
                }
            }
            catch (Exception ex)
            {

                result = "Error: " + ex.Message;
            }
            return new JsonResult(result);
        }
       // [HttpDelete("Delete/{id}")]

        public JsonResult Delete_btn(Guid id)
        {

             var data = dbContext.User.Where(e => e.Id == id).SingleOrDefault();
           // var data = dbContext.User.Find(id);
          //  var data = dbContext.User.SingleOrDefault(e => e.Id == id);
            if (data != null)
            {
                dbContext.User.Remove(data);
                dbContext.SaveChanges();
                return new JsonResult("Data Deleted");
            }
            return new JsonResult("Data not found");
        }
        public JsonResult update(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new JsonResult("Invalid ID provided.");
            }

            var data = dbContext.User.Where(e => e.Id == id).SingleOrDefault();
            if (data != null)
            {
                var result = new
                {
                    success = true,
                    userid = data.Id,
                    fname = data.First_name,
                    lname = data.Last_name,
                     em = data.Email,
                };
                dbContext.SaveChanges();
                return new JsonResult(result);
               
            }
            else
            {
                return new JsonResult("No user found with the provided ID.");
            }
           
            

        }
        [HttpPost]

        public JsonResult update_meth([FromBody] User user)
        {
            if (user == null)
            {
                return new JsonResult("Invalid user data") { StatusCode = 400 };
            }
            dbContext.User.Update(user);
            dbContext.SaveChanges();
            return new JsonResult("Record updated");
        }





    }
}
       

