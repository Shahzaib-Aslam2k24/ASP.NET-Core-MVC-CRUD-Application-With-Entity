using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationData.Datacontext;
using WebApplicationData.Models;

namespace WebApplicationData.Controllers
{      
    public class HomeController : Controller
    {
        private readonly datacontext context;
        public HomeController(datacontext _context)
        {
            this.context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Registration")]
        [HttpPost]
        public IActionResult insert(Studentdata obj)
        {
            if (ModelState.IsValid)
            {
                
                context.Allstudent.Add(obj);
                context.SaveChanges();
                TempData["Message"] = "Data added Successfully...";
                return RedirectToAction("Index", "RetriveData");
            }
            else
            {
                return View("index");
            }
        }
        //Dedatils Controller 
        public IActionResult details(int id)
        {
            var data =context.Allstudent.FirstOrDefault(a=>a.id==id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                TempData["Message"] = "Data is not found...";
                return RedirectToAction("Index", "RetriveData");                
            }
        }
        //For Edit Form data
        public IActionResult edit(int id)
        {
            var data = context.Allstudent.FirstOrDefault(a => a.id == id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                TempData["Message"] = "Record not found...";
                return RedirectToAction("Index", "RetriveData");
            }
        }
        //For Update data
        public IActionResult update(Studentdata obj)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Data is Successfully Updated...";
                context.Allstudent.Update(obj);
                context.SaveChanges();
                return RedirectToAction("Index", "RetriveData");
            }
            return View("edit");
        }
        //for confirmation delete data
        public IActionResult confirm(int id)
        {
            var data = context.Allstudent.FirstOrDefault(a => a.id == id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                TempData["Message"] = "Record not found...";
                return RedirectToAction("Index", "RetriveData");
            }
        }
        public IActionResult delete(int id)
        {
            var data = context.Allstudent.FirstOrDefault(a => a.id == id);
            if (data != null)
            {
                TempData["Message"] = "Your record is deleted...";
                context.Allstudent.Remove(data);
                context.SaveChanges();
                return RedirectToAction("Index", "RetriveData");
            }
            else
            {
                TempData["Message"] = "Record not found...";
                return RedirectToAction("Index", "RetriveData");
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
