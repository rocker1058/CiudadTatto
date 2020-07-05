using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CiudadTatto.Models;

namespace CiudadTatto.Controllers
{
    public class CalificacionesController : Controller
    {
        private CalificacionesEntities db = new CalificacionesEntities();

        // GET: Calificaciones
        public ActionResult Index()
        {
            return View(db.Calificaciones.ToList());
        }

        // GET: Calificaciones/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificaciones calificaciones = db.Calificaciones.Find(id);
            if (calificaciones == null)
            {
                return HttpNotFound();
            }
            return View(calificaciones);
        }

        // GET: Calificaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calificaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tatuador,Opinion,Estrellas")] Calificaciones calificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Calificaciones.Add(calificaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calificaciones);
        }

        // GET: Calificaciones/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificaciones calificaciones = db.Calificaciones.Find(id);
            if (calificaciones == null)
            {
                return HttpNotFound();
            }
            return View(calificaciones);
        }

        // POST: Calificaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tatuador,Opinion,Estrellas")] Calificaciones calificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calificaciones);
        }

        // GET: Calificaciones/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificaciones calificaciones = db.Calificaciones.Find(id);
            if (calificaciones == null)
            {
                return HttpNotFound();
            }
            return View(calificaciones);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Calificaciones calificaciones = db.Calificaciones.Find(id);
            db.Calificaciones.Remove(calificaciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
