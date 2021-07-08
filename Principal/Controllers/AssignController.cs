using Principal.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Principal.Controllers
{
    public class AssignController : Controller
    {
        private ModelData database = new ModelData();

        [HttpGet]
        public ActionResult AssignList()
        {
            return View(database.Assignments.Include(w => w.Worker).Include(t => t.Tool).ToList());
        }

        [HttpGet]
        public ActionResult NewAssign()
        {
            ViewBag.worker_id = new SelectList((from w in database.Workers select w).ToList(), "id", "name");
            ViewBag.tool_id = new SelectList((from t in database.Tools select t).ToList(), "id", "name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewAssign(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    database.Assignments.Add(assignment);
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

            ViewBag.worker_id = new SelectList((from w in database.Workers select w).ToList(), "id", "name", assignment.worker_id);
            ViewBag.tool_id = new SelectList((from t in database.Tools select t).ToList(), "id", "name", assignment.tool_id);

            return View(assignment);
        }

        [HttpGet]
        public ActionResult AssignUpdate(int? id)
        {
            var assignment = database.Assignments.Find(id);

            ViewBag.worker_id = new SelectList((from w in database.Workers select w).ToList(), "id", "name", assignment.worker_id);
            ViewBag.tool_id = new SelectList((from t in database.Tools select t).ToList(), "id", "name", assignment.tool_id);

            return View(assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignUpdate(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    database.Entry(assignment).State = EntityState.Modified;
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

            ViewBag.worker_id = new SelectList((from w in database.Workers select w).ToList(), "id", "name", assignment.worker_id);
            ViewBag.tool_id = new SelectList((from t in database.Tools select t).ToList(), "id", "name", assignment.tool_id);

            return View(assignment);
        }

        [HttpGet]
        public ActionResult AssignDelete(int? id)
        {
            return View(database.Assignments.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignDelete(Assignment assignment)
        {
            try
            {
                database.Assignments.Remove(database.Assignments.Find(assignment.id));
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