using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult Nuovo()
        {
            return View();
        }


        public ActionResult Restituzione()
        {
            return View();
        }
    }
}