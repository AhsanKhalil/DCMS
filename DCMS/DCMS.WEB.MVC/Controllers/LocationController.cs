using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects.Linq2SQL;
using DCMS.WEB.MVC.Models;

namespace DCMS.WEB.MVC.Controllers
{
    public class LocationController : BaseController
    {
        DCMS_DATA_1DataContext dataContext;

        public LocationController()
        {
        }

        // GET: Location
        public ActionResult Index()
        {
            try
            {
                using (dataContext = new DCMS_DATA_1DataContext())
                {
                    dataContext.DeferredLoadingEnabled = false;
                    List<LOCATION> locations = dataContext.LOCATIONs.ToList();
                    return View(locations);
                }
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
                using (dataContext = new DCMS_DATA_1DataContext())
                {
                    LOCATION location = dataContext.LOCATIONs.FirstOrDefault(m => m.ID == id);
                    return View(location);
                }
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
                using (dataContext = new DCMS_DATA_1DataContext())
                {

                    if (dataContext.LOCATIONs.Count() != 0)
                        location.ID = dataContext.LOCATIONs.Select(m => m.ID).Max() + 1;
                    else
                        location.ID = 1;
                    
                    location.CREATED_ON = DATE;
                    location.MODIFIED_ON = DATE;
                    location.CREATED_USER = USER;
                    location.MODIFIED_USER = USER;

                    dataContext.LOCATIONs.InsertOnSubmit(location);
                    dataContext.SubmitChanges();
                }
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
                using (dataContext = new DCMS_DATA_1DataContext())
                {
                    LOCATION location = dataContext.LOCATIONs.FirstOrDefault(m=>m.ID==id);
                    return View(location);
                }
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
                using (dataContext = new DCMS_DATA_1DataContext())
                {
                    LOCATION orignalLoca = dataContext.LOCATIONs.FirstOrDefault(m => m.ID == location.ID);


                    orignalLoca.ADDRESS = location.ADDRESS;
                    orignalLoca.CITY = location.CITY;
                    orignalLoca.CONTACT_1 = location.CONTACT_1;
                    orignalLoca.CONTACT_2 = location.CONTACT_2;
                    orignalLoca.CONTACT_3 = location.CONTACT_3;
                    orignalLoca.EMAIL = location.EMAIL;
                    orignalLoca.FAX_NO = location.FAX_NO;
                    orignalLoca.MODIFIED_ON = DATE;
                    orignalLoca.MODIFIED_USER = USER;
                    orignalLoca.NAME = location.NAME;

                    dataContext.SubmitChanges();

                    return RedirectToAction("Index");
                }
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
                using (dataContext = new DCMS_DATA_1DataContext())
                {
                    LOCATION location = (from LOCATIONs in dataContext.LOCATIONs
                                         where LOCATIONs.ID == id
                                         select LOCATIONs).FirstOrDefault();
                    return View(location);
                }
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
                using (dataContext = new DCMS_DATA_1DataContext())
                {
                    LOCATION getlocation = dataContext.LOCATIONs.FirstOrDefault(m => m.ID == id);

                    dataContext.LOCATIONs.DeleteOnSubmit(getlocation);
                    dataContext.SubmitChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return View("Error", new Error() { Message = e.Message });
            }
        }
    }
}
