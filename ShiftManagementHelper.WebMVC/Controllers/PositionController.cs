using Microsoft.AspNet.Identity;
using ShiftManagementHelper.Models.Positions;
using ShiftManagementHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShiftManagementHelper.WebMVC.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        // Position/Index

        public ActionResult Index()
        {
            PositionService service = CreatePositionService();
            var model = service.GetPositions();
            return View(model);
        }

        private PositionService CreatePositionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PositionService(userId);
            return service;
        }

        // GET: Create
        // Position/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        // Position/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(PositionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePositionService();

            if (service.CreatePosition(model))
            {
                TempData["SaveResult"] = $"{model.PositionName} has been created.";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This position was unable to be created.");
            return View(model);

        }

        // GET: Details
        // Position/Details/{id}

        public ActionResult Details(int id)
        {
            var service = CreatePositionService();
            var model = service.GetPositionById(id);

            return View(model);
        }

        // GET: Edit
        // Position/Edit/{id}

        public ActionResult Edit(int id)
        {
            var service = CreatePositionService();
            var detail = service.GetPositionById(id);

            var model =
                new PositionEdit
                {
                    PositionId = detail.PositionId,
                    PositionName = detail.PositionName,
                    Notes = detail.Notes
                };

            return View(model);
        }

        // POST: Edit
        // Position/Edit/{id}

        [HttpPost, ValidateAntiForgeryToken]

        public ActionResult Edit(int id, PositionEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.PositionId != id)
            {
                ModelState.AddModelError("", "The Id's do not match.");
                return View(model);
            }

            var service = CreatePositionService();
            if (service.UpdatePosition(model))
            {
                TempData["SaveResult"] = $"{model.PositionName} has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This position has not been updated successfully.");
            return View();
        }


        // GET: Delete
        // Position/Delete/{id}

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreatePositionService();
            var model = service.GetPositionById(id);

            return View(model);
        }


        // POST: Delete
        // Position/Delete/{id}

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePositionService();
            service.DeletePosition(id);

            TempData["SaveResult"] = "This position has been successfully deleted.";

            return RedirectToAction("Index");
        }

    }
}