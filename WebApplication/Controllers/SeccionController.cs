using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsDataAccess;
using NewsModel;
using System.Data.SqlClient;

namespace WebApplication.Controllers
{
    public class SeccionController : Controller
    {
        // GET: Seccion
        public ActionResult Index()
        {
            var secciones = SeccionRepository.GetSecciones();
            return View(secciones);
        }

        // GET: Seccion/Details/5
        public ActionResult Details(int id)
        {
            var secciones = SeccionRepository.GetSeccion(id);
            return View(secciones);
        }

        // GET: Seccion/Create
        public ActionResult Create()
        {
            return View(new Seccion());
        }

        // POST: Seccion/Create
        [HttpPost]
        public ActionResult Create(Seccion seccion)
        {
            try
            {
                // TODO: Add insert logic here
                bool success = SeccionRepository.InsertSeccion(seccion);
                if (success)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View();
            }
        }

        // GET: Seccion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Seccion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Seccion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Seccion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
