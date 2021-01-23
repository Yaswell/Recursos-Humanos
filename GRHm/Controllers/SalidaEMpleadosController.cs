using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GRHm.Models;

namespace GRHm.Controllers
{
    public class SalidaEMpleadosController : Controller
    {
        private EmplModelContainer db = new EmplModelContainer();

        // GET: SalidaEMpleados
        public ActionResult Index()
        {
            return View(db.SalidaEMpleadosSet.ToList());
        }

        // GET: SalidaEMpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEMpleados salidaEMpleados = db.SalidaEMpleadosSet.Find(id);
            if (salidaEMpleados == null)
            {
                return HttpNotFound();
            }
            return View(salidaEMpleados);
        }

        // GET: SalidaEMpleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalidaEMpleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Empleado,TipoSalida,Motivo,FechaSalida")] SalidaEMpleados salidaEMpleados)
        {
            if (ModelState.IsValid)
            {
                db.SalidaEMpleadosSet.Add(salidaEMpleados);
                db.SaveChanges();
                return RedirectToAction("/Empleadoes");
            }

            return View(salidaEMpleados);
        }

        // GET: SalidaEMpleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEMpleados salidaEMpleados = db.SalidaEMpleadosSet.Find(id);
            if (salidaEMpleados == null)
            {
                return HttpNotFound();
            }
            return View(salidaEMpleados);
        }

        // POST: SalidaEMpleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Empleado,TipoSalida,Motivo,FechaSalida")] SalidaEMpleados salidaEMpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaEMpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salidaEMpleados);
        }

        // GET: SalidaEMpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEMpleados salidaEMpleados = db.SalidaEMpleadosSet.Find(id);
            if (salidaEMpleados == null)
            {
                return HttpNotFound();
            }
            return View(salidaEMpleados);
        }

        // POST: SalidaEMpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalidaEMpleados salidaEMpleados = db.SalidaEMpleadosSet.Find(id);
            db.SalidaEMpleadosSet.Remove(salidaEMpleados);
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
