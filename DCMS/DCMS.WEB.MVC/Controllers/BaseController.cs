using DCMS.SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCMS.WEB.MVC.Controllers
{
    public class BaseController : Controller
    {
        public IDCService DCService { get;private set; }

        public string USER;
        public DateTime DATE;

        public BaseController(): this(new DCService())
        {
            USER = "AHSAN";
            DATE = DateTime.Now;
        }
        public BaseController(IDCService dcService): base()
        {
            this.DCService = dcService;
        }
    }
}