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
    public class ProjetController : Controller
    {
        private ChiffrageDBContext db = new ChiffrageDBContext();

        // GET: /Projet/
        public ActionResult Index()
        {
            return View(db.Projets.Include(c => c.client).ToList());
        }

        // GET: /Projet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // GET: /Projet/Create
        public ActionResult Create()
        {
            var clients = db.Clients.ToList();

            var viewModel = new ProjetClientViewModel
            {
                projet = new Projet(),
                clients = clients
            };
           
            return View(viewModel);
           
        }

        // POST: /Projet/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,Nom,Duree,Delai,Date_Debut,Date_Fin")] Projet projet)
        public ActionResult Create(Projet projet)
        {
            
            if (ModelState.IsValid)
            {
                db.Projets.Add(projet);
                
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
            return View(projet);
        }

        // GET: /Projet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            else
            {
                var clients = db.Clients.ToList();

                var viewModel = new ProjetClientViewModel
                {
                    projet = projet,
                    clients = clients
                };
                return View(viewModel);
            }

        }

        // POST: /Projet/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="Id,Nom,Duree,Delai,Date_Debut,Date_Fin")] Projet projet)
        public ActionResult Edit(ProjetClientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewModel.projet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel.projet);
        }

        // GET: /Projet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projet projet = db.Projets.Find(id);
            if (projet == null)
            {
                return HttpNotFound();
            }
            return View(projet);
        }

        // POST: /Projet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projet projet = db.Projets.Find(id);
            db.Projets.Remove(projet);
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
