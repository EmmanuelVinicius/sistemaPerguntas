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
        public ActionResult Index(int IDAluno)
        {
            List<Etapas> etapas = new List<Etapas>();
            etapas.Add(new Etapas(1, "Inscrição"));
            etapas.Add(new Etapas(2, "Exame Médico"));
            etapas.Add(new Etapas(3, "Aulas de Legislação"));
            etapas.Add(new Etapas(4, "Prova de Legislação"));
			etapas.Add(new Etapas(5, "Licensa de Aprendizagem"));
            etapas.Add(new Etapas(6, "Aulas de Direção"));
            etapas.Add(new Etapas(7, "Exame de Rua"));
            etapas.Add(new Etapas(8, "Habilitado"));
            return View(etapas);
        }
        public ActionResult MinhasAulas()
        {
			List<Legislacao> model = new List<Legislacao>();
			model.Add(new Legislacao(1, "Legislação", 15));
			model.Add(new Legislacao(2, "Direção Defensiva", 15));
			model.Add(new Legislacao(3, "Meio Ambiente", 9));
			model.Add(new Legislacao(4, "Mecânica", 6));
			
            return View(model);
        }
        public ActionResult ProgramacaoAulas()
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