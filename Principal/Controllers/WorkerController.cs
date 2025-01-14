﻿using Principal.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Principal.Controllers
{
    public class WorkerController : Controller
    {
        private ModelData database = new ModelData();

        [HttpGet]
        public ActionResult WorkerList ()
        {
            return View((from w in database.Workers select w).ToList());
        }

        [HttpGet]
        public ActionResult NewWorker ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewWorker (Worker worker)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    database.Workers.Add(worker);
                    database.SaveChanges();
                }
                catch (Exception)
                {
                    TempData["error"] = "Hubo un Error al Agregar!";
                    return RedirectToAction("WorkerList", "Worker");
                }

                TempData["success"] = "Trabajador Agregado!";
                return RedirectToAction("WorkerList", "Worker");
            }

            return View(worker);
        }

        [HttpGet]
        public ActionResult WorkerUpdate (int? id)
        {
            return View(database.Workers.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkerUpdate (Worker worker)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    database.Entry(worker).State = EntityState.Modified;
                    database.SaveChanges();
                }
                catch (Exception)
                {
                    TempData["error"] = "Hubo un Error al Actualizar!";
                    return RedirectToAction("WorkerList", "Worker");
                }

                TempData["success"] = "Trabajador Actualizado!";
                return RedirectToAction("WorkerList", "Worker");
            }

            return View(worker);
        }

        [HttpGet]
        public ActionResult WorkerDelete (int? id)
        {
            return View(database.Workers.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkerDelete (Worker worker)
        {
            try
            {
                database.Workers.Remove(database.Workers.Find(worker.id));
                database.SaveChanges();
            }
            catch (Exception)
            {
                TempData["error"] = "Hubo un Error al Eliminar!";
                return RedirectToAction("WorkerList", "Worker");
            }

            TempData["success"] = "Trabajador Eliminado!";
            return RedirectToAction("WorkerList", "Worker");
        }

        protected override void Dispose (bool disposing)
        {
            if (disposing)
            {
                database.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}