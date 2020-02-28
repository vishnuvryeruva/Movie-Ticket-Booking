using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieBooking.Data;
using MovieBooking.Models;

namespace MovieBooking.Controllers
{
    public class MultiplexesController : Controller
    {
        private Context db = new Context();

        // GET: Multiplexes
        public ActionResult Index(string searchstring)
        {
            var multiplices = db.Multiplices.Include(m => m.Movie);
            var multiplexes = multiplices.ToList();
            if (!String.IsNullOrEmpty(searchstring))
            {
                multiplexes = multiplexes.Where(s => s.TLoc.Contains(searchstring)).ToList();
            }
            return View(multiplexes);
        }

        // GET: Multiplexes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multiplex multiplex = db.Multiplices.Find(id);
            if (multiplex == null)
            {
                return HttpNotFound();
            }
            return View(multiplex);
        }

        // GET: Multiplexes/Create
        public ActionResult Create()
        {
            ViewBag.mid = new SelectList(db.Movies, "MId", "MName");
            return View();
        }

        // POST: Multiplexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TId,TName,mid,TLoc,TPrice,MDate")] Multiplex multiplex)
        {
            if (ModelState.IsValid)
            {
                db.Multiplices.Add(multiplex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mid = new SelectList(db.Movies, "MId", "MName", multiplex.mid);
            return View(multiplex);
        }

        // GET: Multiplexes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multiplex multiplex = db.Multiplices.Find(id);
            if (multiplex == null)
            {
                return HttpNotFound();
            }
            ViewBag.mid = new SelectList(db.Movies, "MId", "MName", multiplex.mid);
            return View(multiplex);
        }

        // POST: Multiplexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TId,TName,mid,TLoc,TPrice,MDate")] Multiplex multiplex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multiplex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mid = new SelectList(db.Movies, "MId", "MName", multiplex.mid);
            return View(multiplex);
        }

        // GET: Multiplexes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Multiplex multiplex = db.Multiplices.Find(id);
            if (multiplex == null)
            {
                return HttpNotFound();
            }
            return View(multiplex);
        }

        // POST: Multiplexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Multiplex multiplex = db.Multiplices.Find(id);
            db.Multiplices.Remove(multiplex);
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
