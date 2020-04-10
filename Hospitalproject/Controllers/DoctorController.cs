using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospitalproject.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult List()
        {
            return View();
        }
    }
}