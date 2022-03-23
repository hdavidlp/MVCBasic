using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EjemploMVC.Models;
using EjemploMVC.Models.ViewModels;
using EjemploMVC.Models.viewPhones;

namespace EjemploMVC.Controllers
{
    public class PhonesController : Controller
    {
        // GET: Phones
        public ActionResult Index()
        {
            List<listPhones> lst;

            using (dbPruebaEntities db = new dbPruebaEntities())
            {
                lst = (from p in db.phones
                       select new listPhones
                       {
                           idPhone = p.idPhone,
                           phone_Number = p.phone_Number,
                           company = p.company,
                           creationDate = (DateTime)p.creationDate,
                           assign = (Boolean)p.assign
                       }).ToList();
            }

            return View(lst);
        }

        public ActionResult newPhone()
        {

            phone futurePhone = new phone();
            futurePhone.creation_Date = (DateTime)System.DateTime.Today;
            futurePhone.phone_Numer = "999999";


            return View(futurePhone);
        }

        [HttpPost]
        public ActionResult newPhone(phone model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbPruebaEntities db = new dbPruebaEntities())
                    {
                        var currPhone = new phones();
                        currPhone.phone_Number = model.phone_Numer;
                        currPhone.company = model.company;
                        currPhone.creationDate = model.creation_Date;
                        currPhone.assign = false; // cause the Phone is New. Also (model.assign);

                        db.phones.Add(currPhone);
                        db.SaveChanges();
                    }
                }
                return Redirect("~/phones/");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult assignRequest(int id)
        {
            phoneAssign assignRequestModel = new phoneAssign();

            using (dbPruebaEntities db = new dbPruebaEntities())
            {
                var selectedPhone = db.phones.Find(id);

                assignRequestModel.selectedPhone = new phone
                {
                    idPhone = selectedPhone.idPhone,
                    phone_Numer = selectedPhone.phone_Number,
                    company = selectedPhone.company,
                    assign = false
                };
            }

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

                foreach (var posibleCliente in lst)
                {
                    assignRequestModel.clients.Add(new ListClientesViewModel
                    {
                        idCliente = posibleCliente.idCliente,
                        nombre = posibleCliente.nombre,
                        apellidos = posibleCliente.apellidos,
                        correo = posibleCliente.correo
                    });
                }
            }

            return View(assignRequestModel);
        }

        [HttpPost]
        public ActionResult assignRequest(phoneAssign model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbPruebaEntities db = new dbPruebaEntities())
                    {
                        var objPhone = db.phones.Find(model.selectedPhone.idPhone);
                        objPhone.idPhone = model.selectedPhone.idPhone;
                        objPhone.assign = true;
                        db.Entry(objPhone).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                return Redirect("~/phones/");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}