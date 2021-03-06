﻿using ScheduleMedicControl.Business.Models;
using ScheduleMedicControl.DATA.Repositorio;
using System.Net;
using System.Web.Mvc;

namespace ScheduleMedicControl.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepositorio repositorio = new ClienteRepositorio();

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
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                repositorio.Insira(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }

        public ActionResult Edit(int id)
        {
            var cliente = repositorio.ObtenhaPeloId(id);

            if(cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                repositorio.Atualiza(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cliente cliente = repositorio.ObtenhaPeloId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(Cliente cliente)
        {
            try
            {
                repositorio.Delete(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cliente);
            }
        }
    }
}
