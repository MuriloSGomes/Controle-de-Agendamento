using ScheduleMedicControl.Business.Models;
using ScheduleMedicControl.DATA.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ScheduleMedicControl.Controllers
{
    public class ClinicaController : Controller
    {
        private ClinicaRepositorio repositorio = new ClinicaRepositorio();
        public ActionResult Index()
        {
            return View(repositorio.ObtenhaTodos());
        }

        public ActionResult Details(int id)
        {
            return View(repositorio.ObtenhaPeloId(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Clinica clinica)
        {
            try
            {
                repositorio.Insira(clinica);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(clinica);
            }
        }

        public ActionResult Edit(int id)
        {
            var clinica = repositorio.ObtenhaPeloId(id);

            if (clinica == null)
            {
                return HttpNotFound();
            }

            return View(clinica);
        }

        [HttpPost]
        public ActionResult Edit(Clinica clinica)
        {
            try
            {
                repositorio.Atualiza(clinica);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(clinica);
            }
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clinica = repositorio.ObtenhaPeloId(id);

            if(clinica == null)
            {
                return HttpNotFound();
            }

            return View(clinica);
        }

        [HttpPost]
        public ActionResult Delete(Clinica clinica)
        {
            try
            {
                repositorio.Delete(clinica);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(clinica);
            }
        }
    }
}
