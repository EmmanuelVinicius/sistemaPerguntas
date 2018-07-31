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
		public ActionResult Login(Login model)
		{
            if (model.Conex(model.Usuario, model.Senha))
            {
                var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Country, "Brasil")//,
                    //new Claim(ClaimTypes.Name, model.Usuario),
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);
                //string scripto = @"$form.find('[type=submit]').addClass('success').html(options['btn-success']);
                //$form.find('.login-form-main-message').addClass('show success').html(options['msg-success']);";
                //return Json("{'Entrou':'passou'}", JsonRequestBehavior.AllowGet);
                //return JavaScript($"<script>{scripto}</script>");
                return Redirect(GetRedirectUrl(model.ReturnUrl));

            }
            ModelState.AddModelError("", "Usuário ou senha inválidos");
            //string script = @"$form.find('[type=submit]').addClass('error').html(options['btn-error']);
            //$form.find('.login-form-main-message').addClass('show error').html(options['msg-error']);";
                //return Json("{'Entrou':'nao existe'}");
                //return JavaScript($"<script>{script}</script>");
            return View();
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