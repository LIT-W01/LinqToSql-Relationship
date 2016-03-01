using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MvcApplication13.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int pid)
        {
            var repo = new PersonRepository(Properties.Settings.Default.ConStr);
            return View(repo.GetPersonById(pid));
        }

    }
}
