using ScheduleMedicControl.Business;
using ScheduleMedicControl.Business.Models;
using ScheduleMedicControl.Business.Validadores;
using ScheduleMedicControl.DATA.Repositorio;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ScheduleMedicControl.Controllers
{
    public class AgendamentoController : Controller
    {

        private AgendamentoRepositorio _agendamento = new AgendamentoRepositorio();
        private ValidacaoAgendamento _validacao = new ValidacaoAgendamento();
        private ClienteRepositorio _cliente = new ClienteRepositorio();
        private ClinicaRepositorio _clinica = new ClinicaRepositorio();
        public ActionResult Index()
        {
            return View(_agendamento.ObtenhaTodos());
        }

        public ActionResult Details(int id)
        {
            return View(_agendamento.ObtenhaPeloId(id));
        }

        public ActionResult Create()
        {
            MonteViewBag();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Agendamento agendamento)
        {
            try
            {
                agendamento.Agendamentos = _agendamento.ObtenhaTodos();
                _validacao.AssineRegrasInclusao(agendamento);
                _validacao.Valide(agendamento);
                _agendamento.Insira(agendamento);
                return RedirectToAction("Index");
            }
            catch (ValidacaoException ex)
            {
                MonteViewBag();
                ViewBag.Message = ex.Errors.FirstOrDefault().ErrorMessage;
                return View();
            }
        }

        private void MonteViewBag()
        {
            ViewBag.Situacao = EnumeradorSituacaoAgendamento.ObtenhaTodos<EnumeradorSituacaoAgendamento>().ToList();
            ViewBag.data = _cliente.ObtenhaTodos();
            ViewBag.TotalClinicas = _clinica.ObtenhaTodos();
        }

        public ActionResult Edit(int id)
        {
            var agendamento = _agendamento.ObtenhaPeloId(id);
            ViewBag.Situacao = EnumeradorSituacaoAgendamento.ObtenhaTodos<EnumeradorSituacaoAgendamento>().ToList();
            ViewBag.data = _cliente.ObtenhaTodos();
            ViewBag.TotalClinicas = _clinica.ObtenhaTodos();

            if (agendamento == null) return HttpNotFound();

            return View(agendamento);
        }

        [HttpPost]
        public ActionResult Edit(Agendamento agendamento)
        {
            ViewBag.Situacao = EnumeradorSituacaoAgendamento.ObtenhaTodos<EnumeradorSituacaoAgendamento>().ToList();
            ViewBag.data = _cliente.ObtenhaTodos();
            ViewBag.TotalClinicas = _clinica.ObtenhaTodos();

            try
            {
                _agendamento.Atualiza(agendamento);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(agendamento);
            }
        }

        public ActionResult Delete(int id)
        {
            var t = _agendamento.ObtenhaPeloId(id);

            if (id == 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(t);
        }

        [HttpPost]
        public ActionResult Delete(Agendamento agendamento)
        {
            try
            {
                _agendamento.Delete(agendamento);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(agendamento);
            }
        }
    }
}
