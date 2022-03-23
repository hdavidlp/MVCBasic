using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploMVC.Models;
using EjemploMVC.Models.ViewModels;

namespace EjemploMVC.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {

            List<ListClientesViewModel> lst;
            using (dbPruebaEntities db = new dbPruebaEntities())
            {
                lst = (from d in db.Clientes
                           select new ListClientesViewModel
                           {
                               idCliente = d.idCliente,
                               nombre = d.nombre,
                               apellidos = d.apellidos,
                               correo = d.correo
                           }).ToList();
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaClientes model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbPruebaEntities db= new dbPruebaEntities())
                    {
                        var newCliente = new Clientes();
                        newCliente.idCliente = model.idCliente;
                        newCliente.nombre = model.nombre;
                        newCliente.apellidos = model.apellidos;
                        newCliente.correo = model.correo;

                        db.Clientes.Add(newCliente);
                        db.SaveChanges();
                    }
                }

                return Redirect("~/Clientes/");
                
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        public ActionResult Edit(long id)
        {
            TablaClientes model = new TablaClientes();

            using (dbPruebaEntities db = new dbPruebaEntities())
            {
                var objCliente = db.Clientes.Find(id);
                model.idCliente = objCliente.idCliente;
                model.nombre = objCliente.nombre;
                model.apellidos = objCliente.apellidos;
                model.correo = objCliente.correo;
            }


                return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TablaClientes model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbPruebaEntities db = new dbPruebaEntities())
                    {
                        var objCliente = db.Clientes.Find(model.idCliente);
                        objCliente.idCliente = model.idCliente;
                        objCliente.nombre = model.nombre;
                        objCliente.apellidos = model.apellidos;
                        objCliente.correo = model.correo;

                        db.Entry(objCliente).State = System.Data.Entity.EntityState.Modified;

                        //db.Clientes.Add(objCliente);
                        db.SaveChanges();
                    }
                }

                return Redirect("~/Clientes/");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            using (dbPruebaEntities db = new dbPruebaEntities())
            {
                var objCliente = db.Clientes.Find(id);
                db.Clientes.Remove(objCliente);

                db.SaveChanges();
            }


            return Redirect("~/Clientes/");
        }
    }
}