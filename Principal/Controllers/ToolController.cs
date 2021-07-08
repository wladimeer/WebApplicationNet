using Principal.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Principal.Controllers
{
    public class ToolController : Controller
    {
        private ModelData database = new ModelData();
        
        [HttpGet]
        public ActionResult ToolList ()
        {
            return View((from t in database.Tools select t).ToList());
        }

        [HttpGet]
        public ActionResult NewTool ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewTool (Tool tool)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    database.Tools.Add(tool);
                    database.SaveChanges();
                }
                catch (Exception)
                {
                    TempData["error"] = "Hubo un Error al Agregar!";
                    return RedirectToAction("ToolList", "Tool");
                }

                TempData["success"] = "Herramienta Agregada!";
                return RedirectToAction("ToolList", "Tool");
            }

            return View(tool);
        }

        [HttpGet]
        public ActionResult ToolUpdate (int? id)
        {
            return View(database.Tools.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToolUpdate (Tool tool)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    database.Entry(tool).State = EntityState.Modified;
                    database.SaveChanges();
                }
                catch (Exception)
                {
                    TempData["error"] = "Hubo un Error al Actualizar!";
                    return RedirectToAction("ToolList", "Tool");
                }

                TempData["success"] = "Herramienta Actualizada!";
                return RedirectToAction("ToolList", "Tool");
            }

            return View(tool);
        }

        [HttpGet]
        public ActionResult ToolDelete (int? id)
        {
            return View(database.Tools.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ToolDelete (Tool tool)
        {
            try
            {
                database.Tools.Remove(database.Tools.Find(tool.id));
                database.SaveChanges();
            }
            catch (Exception)
            {
                TempData["error"] = "Hubo un Error al Eliminar!";
                return RedirectToAction("ToolList", "Tool");
            }

            TempData["success"] = "Herramienta Eliminada!";
            return RedirectToAction("ToolList", "Tool");
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