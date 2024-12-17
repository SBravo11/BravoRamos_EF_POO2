using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Dominio.Entidad.Herramientas.Entidad;
using Infraestructura.Data.Herramienta;

namespace BravoRamos_EF_POO2.Controllers
{
    public class HerramientaController : Controller
    {
        HerramientaDAL _herramienta = new HerramientaDAL();
        CategoriaDAL _categoria = new CategoriaDAL();

        public ActionResult Index(int p = 0)
        {
            int c = _herramienta.GetAll().Count(); //total insumos del listado
            int r = 8; //numero registros por pagina en el listado
            int npag = c % r == 0 ? c / r : c / r + 1;

            ViewBag.p = p;
            ViewBag.npag = npag;
            return View(_herramienta.GetAll().Skip(r * p).Take(r));
        }

        public ActionResult Agregar()
        {
            ViewBag.categoria = new SelectList(_categoria.GetAll(), "idcategoria", "nombre");
            return View(new Herramientas());
        }

        [HttpPost]
        public ActionResult Agregar(Herramientas reg)
        {
            ViewBag.mensaje = _herramienta.Add(reg);
            ViewBag.categoria = new SelectList(_categoria.GetAll(), "idcategoria", "nombre", reg.idcategoria);
            return View(reg);
        }

        public ActionResult Editar(String id)
        {
            Herramientas reg = _herramienta.find(id);
            ViewBag.categoria = new SelectList(_categoria.GetAll(), "idcategoria", "nombre", reg.idcategoria);
            return View(reg);
        }

        [HttpPost]
        public ActionResult Editar(Herramientas reg)
        {
            ViewBag.mensaje = _herramienta.Update(reg);
            ViewBag.categoria = new SelectList(_categoria.GetAll(), "idcategoria", "nombre", reg.idcategoria);
            return View(reg);
        }

        public ActionResult Eliminar(string id)
        {
            ViewBag.mensaje = _herramienta.Delete(id);
            return RedirectToAction("Index");
        }
    }
}