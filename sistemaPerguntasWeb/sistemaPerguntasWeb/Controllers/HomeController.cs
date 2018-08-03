using sistemaPerguntasWeb.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Controllers
{
    //[Authorize(Roles = "")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Etapas> etapas = new List<Etapas>();
            etapas.Add(new Etapas(1, "Inscrição"));
            etapas.Add(new Etapas(2, "Exame Médico"));
            etapas.Add(new Etapas(3, "Aulas de Legislação"));
            etapas.Add(new Etapas(4, "Prova de Legislação"));
            etapas.Add(new Etapas(5, "Aulas de Diração"));
            etapas.Add(new Etapas(6, "Exame de Rua"));
            etapas.Add(new Etapas(7, "Habilitado"));
            return View(etapas);
        }
        public ActionResult MinhasAulas()
        {
            return View();
        }
        public ActionResult Programacao()
        {
            return View();
        }
        public ActionResult Direcao()
        {
            return View();
        }
        public RedirectToRouteResult Provinha()
        {
            return RedirectToAction("Legislacao", "Perguntas");
        }
    }
}