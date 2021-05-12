using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShiftManagementHelper.WebMVC.Controllers
{
    public class ShiftController : Controller
    {
        // GET: Shift
        public ActionResult Index()
        {
            return View();
        }
    }
}