using Microsoft.AspNet.Identity;
using ShiftManagementHelper.Models.PositionAssignments;
using ShiftManagementHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShiftManagementHelper.WebMVC.Controllers
{
    public class PositionAssignmentController : Controller
    {
        // GET: PositionAssignment
        // PositionAssignment/Index
        public ActionResult Index()
        {
            PositionAssignmentService service = CreatePositionAssignmentService();
            var model = service.GetPositionAssignment();
            return View(model);
        }

        private PositionAssignmentService CreatePositionAssignmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PositionAssignmentService(userId);

            return service;
        }

        // GET: Create
        // PositionAssignment/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        // PositionAssignment/Create

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(PositionAssignmentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePositionAssignmentService();

            if (service.CreatePositionAssignment(model))
            {
                TempData["SaveResult"] = "This Position Assignment has been successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Unfortunately this Position Assignment was unable to be created at this time.");

            return View(model);

        }


        // GET: Details
        // PositionAssignment/Details{id}

        public ActionResult Details(int id)
        {
            var service = CreatePositionAssignmentService();
            var model = service.GetPositionAssignmentById(id);

            return View(model);
        }

        // GET: Edit
        // PositionAssignment/Edit/{id}

        public ActionResult Edit(int id)
        {
            var service = CreatePositionAssignmentService();
            var detail = service.GetPositionAssignmentById(id);
            var model =
                new PositionAssignmentEdit
                {
                    PositionAssignmentId = detail.PositionAssignmentId,
                    PositionId = detail.PositionAssignmentId,
                    ShiftId = detail.ShiftId,
                    WorkerId = detail.WorkerId,
                    Notes = detail.Notes
                };

            return View(model);
        }

        // POST: Edit
        // PositionAssignment/Edit/{id}

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PositionAssignmentEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.PositionAssignmentId != id)
            {
                ModelState.AddModelError("", "The Id's do not match.");
                return View(model);
            }

            var service = CreatePositionAssignmentService();

            if (service.UpdatePositionAssignment(model))
            {
                TempData["SaveResult"] = "This Position Assignment was uupdated successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This Position Assignment has NOT been updated successfully.");
            return View();
        }

        // GET: Delete
        // UpdatePositionAssignment/Delete/{id}

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreatePositionAssignmentService();
            var model = service.GetPositionAssignmentById(id);

            return View(model);
        }

        // POST: Delete
        // UpdatePositionAssignment/Delete/{id}

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePositionAssignmentService();
            service.DeletePositionAssignment(id);

            TempData["SaveResult"] = "This Position Assignment has been successfully deleted.";

            return RedirectToAction("Index");
        }
    }
}