using ScheduleMedicControl.Business.Models;
using ScheduleMedicControl.DATA.Repositorio;
using System.Web.Mvc;

namespace ScheduleMedicControl.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepositorio repositorio = new ClienteRepositorio();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(repositorio.ObtenhaTodos());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View(repositorio.ObtenhaPeloId(id));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
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

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = repositorio.ObtenhaPeloId(id);

            if(cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            repositorio.DeletePorId(id);

            return Json(repositorio.ObtenhaTodos());
        }

        // POST: Cliente/Delete/5
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
