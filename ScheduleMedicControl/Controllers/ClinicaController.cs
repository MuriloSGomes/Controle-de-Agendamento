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
        private ClinicaRepositorio _repositorio = new ClinicaRepositorio();
        public ActionResult Index()
        {
            var temp = _repositorio.ObtenhaTodos();

            return View(_repositorio.ObtenhaTodos());
        }

        [HttpPost]
        public ActionResult VagasNaData(DateTime data)
        {
            var temp = _repositorio.ObtenhaTodos();

            return View(_repositorio.ObtenhaTodos());
        }

        public ActionResult Details(int id)
        {
            return View(_repositorio.ObtenhaPeloId(id));
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
                _repositorio.Insira(clinica);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(clinica);
            }
        }

        public ActionResult Edit(int id)
        {
            var clinica = _repositorio.ObtenhaPeloId(id);

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
                _repositorio.Atualiza(clinica);
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

            var clinica = _repositorio.ObtenhaPeloId(id);

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
                _repositorio.Delete(clinica);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(clinica);
            }
        }
    }
}
