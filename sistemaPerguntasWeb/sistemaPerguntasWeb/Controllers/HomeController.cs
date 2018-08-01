using sistemaPerguntasWeb.Models;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Controllers
{
    //[Authorize(Roles = "")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Etapas model)
        {
            model.GetEtapas();
            return View(model);
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