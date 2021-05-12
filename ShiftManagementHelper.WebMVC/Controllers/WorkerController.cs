using Microsoft.AspNet.Identity;
using ShiftManagementHelper.Models.Workers;
using ShiftManagementHelper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShiftManagementHelper.WebMVC.Controllers
{
    public class WorkerController : Controller
    {
        // GET: Worker
        // Worker/Index

        public ActionResult Index()
        {
            WorkerService service = CreateWorkerService();
            var model = service.GetWorkers();
            return View(model);
        }

        private WorkerService CreateWorkerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkerService(userId);

            return service;
        }

        // GET: Create
        // Worker/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        // Worker/Create

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(WorkerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateWorkerService();

            if (service.CreateWorker(model))
            {
                TempData["SaveResult"] = $"You have successfully created worker {model.WorkerFirstName} {model.WorkerLastName}.";

                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Unfortunately this worker was unable to be created.");
            return View(model);
        }

        // GET: Details
        // Worker/Details/{id}

        public ActionResult Details(int id)
        {
            var service = CreateWorkerService();
            var model = service.GetWorkerById(id);

            return View(model);
        }

        // GET: Edit
        // Worker/Edit/{id}

        public ActionResult Edit(int id)
        {
            var service = CreateWorkerService();
            var detail = service.GetWorkerById(id);
            var model =
                new WorkerEdit
                {
                    WorkerId = detail.WorkerId,
                    WorkerFirstName = detail.WorkerFirstName,
                    WorkerLastName = detail.WorkerLastName,
                    EmploymentStartDate = detail.EmploymentStartDate,
                    Role = detail.Role,
                    Notes = detail.Notes
                };

            return View(model);
        }


        // POST: Edit
        // Worker/Edit/{id}

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkerEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.WorkerId != id)
            {
                ModelState.AddModelError("", "The Id's do not match.");
                return View(model);
            }

            var service = CreateWorkerService();

            if (service.UpdateWorker(model))
            {
                TempData["SaveResult"] = $"{model.WorkerFirstName}'s file has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "This Worker has not been updated successfully.");
            return View();

        }

        // GET: Delete
        // Worker/Delete/{id}

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateWorkerService();
            var model = service.GetWorkerById(id);

            return View(model);
        }


        // POST: Delete
        // Worker/Delete/{id}

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateWorkerService();
            service.DeleteWorker(id);

            TempData["SaveResult"] = "This Worker has been successfully deleted.";

            return RedirectToAction("Index");
        }

    }
}