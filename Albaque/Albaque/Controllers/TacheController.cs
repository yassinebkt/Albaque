using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Albaque.Models;
using Albaque.ViewModels;

namespace Albaque.Controllers
{
    public class TacheController : Controller
    {
        private ChiffrageDBContext db = new ChiffrageDBContext();

        // GET: /Tache/
        public ActionResult Index()
        {
            return View(db.Taches.Include(com => com.complexite).Include(cat => cat.categorie).Include(tec => tec.technologie).ToList());
        }

        // GET: /Tache/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache tache = db.Taches.Find(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            return View(tache);
        }

        // GET: /Tache/Create
        public ActionResult Create()
        {
            var categories = db.Categories.ToList();
            var complexites = db.Complexites.ToList();
            var technologies = db.Technologies.ToList();

            var viewModel = new TacheInformationViewModel
            {
                tache = new Tache(),
                categories = categories,
                complexites = complexites,
                technologies = technologies
            };
            return View(viewModel);
        }

        // POST: /Tache/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,nom,description,charge")] Tache tache)
        public ActionResult Create(TacheInformationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Taches.Add(viewModel.tache);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var errors = ModelState
               .Where(x => x.Value.Errors.Count > 0)
               .Select(x => new { x.Key, x.Value.Errors })
               .ToArray();

            return View(viewModel.tache);
        }

        // GET: /Tache/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache tache = db.Taches.Find(id);           

            if (tache == null)
            {
                return HttpNotFound();
            }
            else
            {

                var categories = db.Categories.ToList();
                var complexites = db.Complexites.ToList();
                var technologies = db.Technologies.ToList();
                var viewModel = new TacheInformationViewModel
                {
                    tache = tache,
                    categories = categories,
                    complexites = complexites,
                    technologies = technologies
                };
                return View(viewModel);
            }
           // return View("Index");
        }

        // POST: /Tache/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="Id,nom,description,charge")] Tache tache)
        public ActionResult Edit(TacheInformationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewModel.tache).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel.tache);
        }

        // GET: /Tache/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tache tache = db.Taches.Find(id);
            if (tache == null)
            {
                return HttpNotFound();
            }
            db.Taches.Remove(tache);
            db.SaveChanges();
            return View(tache);
        }

        // POST: /Tache/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tache tache = db.Taches.Find(id);
            db.Taches.Remove(tache);
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
