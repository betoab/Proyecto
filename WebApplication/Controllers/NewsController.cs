using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using NewsDataAccess;
using NewsModel;
using NewsMockDataAccess;
using System.IO;

namespace WebApplication.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [HttpGet]
        public ActionResult Index()
        {

            var notas = NewsRepository.GetNews();
            return View(notas);
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            var nota = NewsRepository.GetNew(id);
            return View(nota);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View(new Nota());
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create(Nota nota, HttpPostedFileBase file)
        {
            try
            {
                if( file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string server_path = Path.Combine(Server.MapPath("~/Images"), filename);
                    file.SaveAs(server_path);
                    nota.Archivo = "~/Images"+nota.Fecha.ToShortDateString()+filename;
                }                
                bool success = NewsRepository.InsertNota(nota);
                if (success)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch(SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View();
            }
        }

        
        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: News/Edit/5
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

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: News/Delete/5
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
