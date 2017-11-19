using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataObjects.Linq2SQL.Data;
using DCMS.WEB.MVC.Models;


namespace DCMS.WEB.MVC.Controllers
{
    public class OrganizationController : BaseController
    {
        public OrganizationController()
        {
            TempData["MESSAGE"] = null;
        }
        // GET: Organization
        public ActionResult Index()
        {
            try
            {
                List<ORGANIZATION> organizations = DCService.GetAllOrganization();
                return View(organizations);
            }
            catch (Exception e)
            {
                return View("~/Views/Shared/Error.cshtml", new Message() { Description = e.Message });
            }
        }

        // GET: Organization/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ORGANIZATION organization = DCService.GetOrganization(id);
                return PartialView(organization);
            }
            catch (Exception e)
            {
                return View("~/Views/Shared/Error.cshtml", new Message() { Description = e.Message });
            }
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Organization/Create
        [HttpPost]
        public ActionResult Create(ORGANIZATION organization)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    organization.CREATED_ON = DATE;
                    organization.MODIFIED_ON = DATE;
                    organization.CREATED_USER = USER;
                    organization.MODIFIED_USER = USER;

                    DCService.SaveOrganization(organization);

                    TempData["MESSAGE"] = new Message() { Type = MessageType.Inform, Description = "Location Successfully Saved." };

                    return RedirectToAction("Index", "Organization");
                }
                catch (Exception e)
                {
                    TempData["MESSAGE"] = new Message() { Type = MessageType.Error, Description = e.Message };
                    return RedirectToAction("Index", "Organization");
                }
            }
            else
            {
                TempData["MESSAGE"] = new Message() { Type = MessageType.Error, Description = "Please fill all required fields with valid data." };
                return RedirectToAction("Index", "Organization");
            }
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ORGANIZATION organization = DCService.GetOrganization(id);
                return PartialView(organization);

            }
            catch (Exception e)
            {
                return View("~/Views/Shared/Error.cshtml", new Message() { Description = e.Message });

            }
        }

        // POST: Organization/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ORGANIZATION organization)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    organization.MODIFIED_ON = DATE;
                    organization.MODIFIED_USER = USER;

                    DCService.UpdateOrganization(organization);

                    TempData["MESSAGE"] = new Message() { Type = MessageType.Inform, Description = "Location Successfully Saved." };

                    return RedirectToAction("Index", "Organization");

                }
                catch (Exception e)
                {
                    return View("~/Views/Shared/Error.cshtml", new Message() { Description = e.Message });
                }
            }
            return RedirectToAction("Edit", id);
        }
        // POST: Organization/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                DCService.DeleteOrganization(id);


                TempData["MESSAGE"] = new Message() { Type = MessageType.Inform, Description = "Location Delete Successfully." };

                return RedirectToAction("Index", "Organization");

            }
            catch (Exception e)
            {
                return View("~/Views/Shared/Error.cshtml", new Message() { Description = e.Message });
            }
        }
    }
}
