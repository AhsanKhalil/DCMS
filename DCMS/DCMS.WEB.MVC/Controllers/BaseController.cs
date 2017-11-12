using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCMS.WEB.MVC.Controllers
{
    public class BaseController : Controller
    {
        public string USER;
        public DateTime DATE;
        public BaseController()
        {
            USER = "AHSAN";
            DATE = DateTime.Now;
        }
    }
}