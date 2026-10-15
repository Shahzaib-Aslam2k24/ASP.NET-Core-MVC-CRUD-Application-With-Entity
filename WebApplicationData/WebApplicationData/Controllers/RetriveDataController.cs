using Microsoft.AspNetCore.Mvc;
using WebApplicationData.Datacontext;
using WebApplicationData.Models;

namespace WebApplicationData.Controllers
{
    public class RetriveDataController : Controller
    {
        private readonly datacontext context;
        
        public RetriveDataController(datacontext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var alldata=context.Allstudent.ToList();
            return View(alldata);
        }
    }
}
