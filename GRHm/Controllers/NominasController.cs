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
    public class NominasController : Controller
    {
        private EmplModelContainer db = new EmplModelContainer();

        // GET: Nominas
        public ActionResult Index()
        {
            return View(db.NominaSet.ToList());
        }

        public ActionResult Totalizar()
        {
            var Sueldo = db.EmpleadoSet.ToList();
            var valor = db.EmpleadoSet.Sum(a => a.Salario);
            

                 ViewBag.TotalSalario = db.NominaSet.Sum(a => a.MontoTotal);
            ViewBag.TotalEmpleados = db.NominaSet.Count();

            //var query = (from a in db.NominaSet
            //             where a.nombre == "Juan"
            //             select a).First();

            //query.salario = 5;

            //var listaEmpleados = new SelectList(empleados, "Id", "Salario");
            //ViewBag.Empleados = listaEmpleados;
            //db.SaveChanges();
            return View();
        }


        // GET: Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.NominaSet.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nominas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Año,Mes,MontoTotal")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                nomina.Mes = db.EmpleadoSet.Sum(a=> a.Salario);
                db.NominaSet.Add(nomina);
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
               
                return RedirectToAction("/SalidaEMpleados/Create");
            }

            return View(nomina);
        }

        // GET: Nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.NominaSet.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Año,Mes,MontoTotal")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nomina);
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.NominaSet.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nomina nomina = db.NominaSet.Find(id);
            db.NominaSet.Remove(nomina);
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
