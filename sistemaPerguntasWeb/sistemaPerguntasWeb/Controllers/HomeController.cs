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
    }
}