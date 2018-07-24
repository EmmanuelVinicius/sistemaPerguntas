using System.Web.Mvc;

namespace sistemaPerguntasWeb.Controllers
{
    //[Authorize(Roles = "")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MinhasAulas()
        {
            return View();
        }
        public ActionResult Programacao()
        {
            return View();
        }
        public ActionResult Perfil()
        {
            return View();
        }
        public RedirectToRouteResult Provinha()
        {
            return RedirectToAction("Legislacao", "Perguntas");
        }
    }
}