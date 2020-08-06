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
    public class tatuajesController : Controller
    {
        private ciudad_tattooEntities1 db = new ciudad_tattooEntities1();

        // GET: tatuajes
        public ActionResult Index()
        {
            return View(db.tatuaje.ToList());
        }

        // GET: tatuajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tatuaje tatuaje = db.tatuaje.Find(id);
            if (tatuaje == null)
            {
                return HttpNotFound();
            }
            return View(tatuaje);
        }

        // GET: tatuajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tatuajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Descripcion,categoria,imagen,fecha,etiqueta")] tatuaje tatuaje)
        {
            if (ModelState.IsValid)
            {
                db.tatuaje.Add(tatuaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tatuaje);
        }

        // GET: tatuajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tatuaje tatuaje = db.tatuaje.Find(id);
            if (tatuaje == null)
            {
                return HttpNotFound();
            }
            return View(tatuaje);
        }

        // POST: tatuajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Descripcion,categoria,imagen,fecha,etiqueta")] tatuaje tatuaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tatuaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tatuaje);
        }

        // GET: tatuajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tatuaje tatuaje = db.tatuaje.Find(id);
            if (tatuaje == null)
            {
                return HttpNotFound();
            }
            return View(tatuaje);
        }

        // POST: tatuajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tatuaje tatuaje = db.tatuaje.Find(id);
            db.tatuaje.Remove(tatuaje);
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
