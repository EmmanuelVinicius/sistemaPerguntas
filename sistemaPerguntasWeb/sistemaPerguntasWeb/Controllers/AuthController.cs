using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using sistemaPerguntasWeb.Models;

namespace sistemaPerguntasWeb.Controllers
{
    [AllowAnonymous]
	public class AuthController : Controller
	{
		// GET: Auth
        [HttpGet]
		public ActionResult Login(string returnUrl)
		{
            var model = new Login
            {
                ReturnUrl = returnUrl
            };
			return View(model);
		}

		[HttpPost]
		public JsonResult Login(Login model)
		{
            if (model.Conex(model.Usuario, model.Senha))
            {
                var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Country, "Brasil")
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);
                return Json("passou", JsonRequestBehavior.AllowGet);
                //return Redirect(GetRedirectUrl(model.ReturnUrl));

            }
                return Json("Invalido",JsonRequestBehavior.AllowGet);
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }
        [HttpPost]
		public ActionResult Register(Users model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Digite os dados corretamente");
                return View();
            }
            Users users = new Users();
			return Redirect("");
		}
		public ActionResult ForgPass()
		{
			return View();
		}
	}
}