using Principal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Principal.Controllers
{
    public class AssignController : Controller
    {
        private ModelData database = new ModelData();

        [HttpGet]
        public ActionResult AssignList ()
        {
            return View((from a in database.Assigns select a).ToList());
        }

        [HttpGet]
        public ActionResult NewAssign ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewAssign (Assign assign)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    database.Assigns.Add(assign);
                    database.SaveChanges();
                }
                catch (Exception)
                {
                    TempData["error"] = "Hubo un Error al Agregar!";
                    return RedirectToAction("AssignList", "Assign");
                }

                TempData["success"] = "Asignación Agregada!";
                return RedirectToAction("AssignList", "Assign");
            }

            return View(assign);
        }

        [HttpGet]
        public ActionResult AssignUpdate (int? id)
        {
            return View(database.Assigns.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignUpdate (Assign assign)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    database.Entry(assign).State = EntityState.Modified;
                    database.SaveChanges();
                }
                catch (Exception)
                {
                    TempData["error"] = "Hubo un Error al Actualizar!";
                    return RedirectToAction("AssignList", "Assign");
                }

                TempData["success"] = "Asignación Actualizada!";
                return RedirectToAction("AssignList", "Assign");
            }

            return View(assign);
        }

        [HttpGet]
        public ActionResult AssignDelete (int? id)
        {
            return View(database.Assigns.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignDelete (Assign assign)
        {
            try
            {
                database.Assigns.Remove(database.Assigns.Find(assign.id));
                database.SaveChanges();
            }
            catch (Exception)
            {
                TempData["error"] = "Hubo un Error al Eliminar!";
                return RedirectToAction("AssignList", "Assign");
            }

            TempData["success"] = "Asignación Eliminada!";
            return RedirectToAction("AssignList", "Assign");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                database.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}