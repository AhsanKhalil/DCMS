using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects.Linq2SQL.Data;
using DCMS.WEB.MVC.Models;

namespace DCMS.WEB.MVC.Controllers
{
    public class LocationController : BaseController
    {
        
        public LocationController()
        {
        }

        // GET: Location
        public ActionResult Index()
        {
            try
            {
                List<LOCATION> locations = DCService.GetAllLocation();
                 return View(locations);
                
            }
            catch (Exception e)
            {
                return View("Error", new Error() { Message = e.Message });
            }

        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                LOCATION location = DCService.GetLocation(id);
                return View(location);
                
            }
            catch (Exception e)
            {
                return View("Error", new Error() { Message = e.Message });
            }
}

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(LOCATION location)
        {
            try
            {
                
                    
                location.CREATED_ON = DATE;
                location.MODIFIED_ON = DATE;
                location.CREATED_USER = USER;
                location.MODIFIED_USER = USER;

                DCService.SaveLocation(location);
                    // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("Error", new Error() { Message = e.Message });
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {

                LOCATION location = DCService.GetLocation(id);
                return View(location);
                
            }
            catch (Exception e)
            {
                return View("Error", new Error() { Message = e.Message });
            }
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LOCATION location)
        {
            try
            {
                
                location.MODIFIED_ON = DATE;
                location.MODIFIED_USER = USER;

                DCService.UpdateLocation(location);

                return RedirectToAction("Index");
                
            }
            catch (Exception e)
            {
                return View("Error", new Error() { Message = e.Message });
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                LOCATION location = DCService.GetLocation(id);
                return View(location);
                
            }
            catch (Exception e)
            {
                return View("Error", new Error() { Message = e.Message });
            }

        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LOCATION location)
        {
            try
            {
                DCService.DeleteLocation(id);

                return RedirectToAction("Index");
                   
            }
            catch (Exception e)
            {
                return View("Error", new Error() { Message = e.Message });
            }
        }
    }
}
