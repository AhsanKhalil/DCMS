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
            TempData["MESSAGE"] = null;
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
                return View("Error", new Message() { Description = e.Message });
            }

        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            try
            {

                LOCATION location = DCService.GetLocation(id);
                return PartialView(location);
                
            }
            catch (Exception e)
            {
                return View("Error", new Message() { Description = e.Message });
            }
        }

        // GET: Location/Create
        public ActionResult Create(string msg=null)
        {
            return PartialView();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(LOCATION location)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    location.CREATED_ON = DATE;
                    location.MODIFIED_ON = DATE;
                    location.CREATED_USER = USER;
                    location.MODIFIED_USER = USER;

                    DCService.SaveLocation(location);
                    // TODO: Add insert logic here

                    //TempData["MESSAGE"] = new Message() { Type = MessageType.Inform, Description = "Location Successfully Saved." };

                    TempData["Message"] = "Data has been saved successfully!";

                    return RedirectToAction("Index", "Location");
                }
                catch (Exception e)
                {
                    TempData["MESSAGE"] = new Message() {Type=MessageType.Error,Description=e.Message };
                    return View(location);
                }
            }
            else
            {
                TempData["MESSAGE"] = new Message() { Type = MessageType.Error, Description = "Please fill all required fields with valid data." };
                return View(location);
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {

                LOCATION location = DCService.GetLocation(id);
                return PartialView(location);
                
            }
            catch (Exception e)
            {
                return View("Error", new Message() { Description = e.Message });

            }
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LOCATION location)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    location.MODIFIED_ON = DATE;
                    location.MODIFIED_USER = USER;

                    DCService.UpdateLocation(location);

                    //TempData["MESSAGE"] = new Message() { Type = MessageType.Inform, Description = "Location Successfully Saved." };

                    TempData["Message"] = "Data has been updated successfully!";

                    return RedirectToAction("Index", "Location");

                }
                catch (Exception e)
                {
                    return View("Error", new Message() { Description = e.Message });
                }
            }
            return RedirectToAction("Edit", id);
        }

        // GET: Location/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        LOCATION location = DCService.GetLocation(id);
        //        return View(location);
                
        //    }
        //    catch (Exception e)
        //    {
        //        return View("Error", new Message() { Description = e.Message });
        //    }

        //}

        // POST: Location/Delete/5
  
        public ActionResult Delete(int id)//, LOCATION location)
        {
            try
            {
                DCService.DeleteLocation(id);
                

                //TempData["MESSAGE"] = new Message() { Type = MessageType.Inform, Description = "Location Delete Successfully." };

                TempData["Message"] = "Data has been deleted successfully!";

                return RedirectToAction("Index", "Location");

            }
            catch (Exception e)
            {
                return View("Error", new Message() { Description = e.Message });
            }
        }
    }
}
