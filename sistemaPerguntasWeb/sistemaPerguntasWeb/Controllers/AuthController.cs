using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using sistemaPerguntasWeb.Models;

namespace sistemaPerguntasWeb.Controllers
{
    [AllowAnonymous]
	public class AuthController : Controller
	{
		public ActionResult Login(string returnUrl)
		{
            var model = new Login
            {
                ReturnUrl = returnUrl
            };
			return View(model);
		}

		public ActionResult Ajax(Login model)
		{
            if (model.Conex(model.Email, model.Senha))
            {
                var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Country, "Brasil")
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);
                return Json(Redirect(GetRedirectUrl(model.ReturnUrl) + "?IDAluno=" + model.ID),JsonRequestBehavior.AllowGet);

            }
                return Json("Invalido");
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

		public ActionResult ForgPass()
		{
			return View();
		}
	}
}