using Microsoft.AspNet.Identity;
using ShiftManagementHelper.Models.Shifts;
using ShiftManagementHelper.Services;
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
        // Shift/Index

        public ActionResult Index()
        {
            ShiftService service = CreateShiftService();
            var model = service.GetShifts();
            return View(model);
        }

        private ShiftService CreateShiftService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShiftService(userId);

            return service;
        }

        // GET: Create
        // Shift/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST Create
        // Shift/Create

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ShiftCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateShiftService();

            if (service.CreateShift(model))
            {
                TempData["SaveResult"] = $"You have successfully created {model.ShiftName}.";

                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Unfortunately this shift was unable to be created.");
            return View(model);

        }

        // GET: Details
        // Shift/Details/{id}

        public ActionResult Details(int id)
        {
            var service = CreateShiftService();
            var model = service.GetShiftById(id);

            return View(model);
        }

        // GET: Edit
        // Shift/Edit/{id}

        public ActionResult Edit(int id)
        {
            var service = CreateShiftService();
            var detail = service.GetShiftById(id);

            var model =
                new ShiftEdit
                {
                    ShiftId = detail.ShiftId,
                    ShiftName = detail.ShiftName,
                    Date = detail.Date,
                    Notes = detail.Notes
                };

            return View(model);
        }

        // POST: Edit
        // Shift/Edit/{id}

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShiftEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ShiftId != id)
            {
                ModelState.AddModelError("", "The Id's do not match.");
                return View(model);
            }

            var service = CreateShiftService();

            if (service.UpdateShift(model))
            {
                TempData["SaveResult"] = $"{model.ShiftName} has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This Shift was NOT updated successfully.");
            return View();
        }

        // GET: Delete
        // Shift/Delete/{id}

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateShiftService();
            var model = service.GetShiftById(id);

            return View(model);
        }

        // POST: Delete
        // Shift/Delete/{id}

        [HttpPost, ActionName("Delete") , ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateShiftService();
            service.DeleteShift(id);

            TempData["SaveResult"] = "This Shift was successfully deleted.";
            return RedirectToAction("Index");
        }



    }
}