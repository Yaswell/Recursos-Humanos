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
    public class EmpleadoesController : Controller
    {
        private EmplModelContainer db = new EmplModelContainer();

        // GET: Empleadoes
        public ActionResult Index(string search)
        {
            if (search == null)
            {
                return View(db.EmpleadoSet.ToList());
            }
            else
            {
                return View(db.EmpleadoSet.Where(x => x.Nombre.StartsWith(search)).ToList());
            }

            

        }
        [HttpPost]
        public ActionResult EmpleadoEstado(string search)
        {
            if (search=="Todos")
            {
                return View(db.EmpleadoSet.ToList());
            }
            else if (search == "Activos")
            {
                return View(db.EmpleadoSet.Where(x => x.Estatus.StartsWith("A")).ToList());
            }
            else if (search == "Inactivo")
            {
                return View(db.EmpleadoSet.Where(x => x.Estatus.StartsWith("In")).ToList());
            }
            else
            {
                return View(db.EmpleadoSet.ToList());
            }


        }


        public ActionResult EmpleadoActivos()
        {
           
                return View(db.EmpleadoSet.Where(x => x.Estatus.StartsWith("Ac")).ToList());
         }

        public ActionResult EmpleadoInactivos(string inactivo)
        {
         return View(db.EmpleadoSet.Where(x => x.Estatus.StartsWith("I")).ToList());
        }

        public ActionResult LlenarCombo()
        {
            var Nombre = db.DepartamentoSet.ToList();

            var listaDepartamentos = new SelectList(Nombre, "Id", "Nombre");
            ViewBag.Departamentos = listaDepartamentos;

            return View();
        }

        public ActionResult LosCargos()
        {
            var NomCargos = db.CargoSet.ToList();
            var listadeCargos = new SelectList(NomCargos, "id", "NomCargos");
            ViewBag.Cargos = listadeCargos;

            return View();
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.EmpleadoSet.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoEmpleado,Nombre,Apellido,Telefono,Departamento,Cargo,FechadeNac,Salario,Estatus")] Empleado empleado)
        {
            empleado.Estatus = "Activo";
            if (ModelState.IsValid)
            {
                db.EmpleadoSet.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.EmpleadoSet.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoEmpleado,Nombre,Apellido,Telefono,Departamento,Cargo,FechadeNac,Salario,Estatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            db.SaveChanges();
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.EmpleadoSet.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.EmpleadoSet.Find(id);

            empleado.Estatus = "Inactivo";
            db.SaveChanges();
            return RedirectToAction("/SalidaEMpleadoes");
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
