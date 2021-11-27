using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP6_2Parcial.Models;

namespace TP6_2Parcial.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            try
            {
                using (var db = new ProgramaciónVisualEntities())
                {
                    return View(db.LIBRO.ToList());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Agregar(LIBRO libro)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new ProgramaciónVisualEntities())
                {
                    db.LIBRO.Add(libro);
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al agregar el libro " + ex.Message);
                return View();
            }
        }


        public ActionResult Editar(int id)
        {
            if (!ModelState.IsValid)
                return View();
            
            try
            {
                using (var db = new ProgramaciónVisualEntities())
                {
                    LIBRO libro = db.LIBRO.Find(id);
                    return View(libro);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al editar el libro " + ex.Message);
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(LIBRO libro)
        {
            try
            {
                using (var db = new ProgramaciónVisualEntities())
                {
                    LIBRO li = db.LIBRO.Find(libro.IDLIBRO);
                    li.TITULO = libro.TITULO;
                    li.AUTOR = libro.AUTOR;
                    li.ISBN = libro.ISBN;
                    li.PAGINAS = libro.PAGINAS;
                    li.EDICION = libro.EDICION;
                    li.EDITORIAL = libro.EDITORIAL;
                    li.CIUDAD = libro.CIUDAD;
                    li.PAIS = libro.PAIS;
                    li.FECHAEDICION = libro.FECHAEDICION;
                    db.SaveChanges();

                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public ActionResult Detalles(int id)
        {
            using (var db = new ProgramaciónVisualEntities())
            {
                LIBRO libro = db.LIBRO.Find(id);
                return View(libro);
            }
        }


        public ActionResult Eliminar(int id)
        {
            using (var db = new ProgramaciónVisualEntities())
            {
                LIBRO libro = db.LIBRO.Find(id);
                db.LIBRO.Remove(libro);
                db.SaveChanges();

                return RedirectToAction("index");
            }
        }
    }
}