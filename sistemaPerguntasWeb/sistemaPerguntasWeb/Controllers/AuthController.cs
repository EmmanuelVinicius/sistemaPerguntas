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
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Digite os dados corretamente");
                return View();
            }
            var users = new Login();
            //Retirar
            if (users.ConexBanco(model.Usuario, model.Senha))
            {
                var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Country, "Brasil")//,
                    //new Claim(ClaimTypes.Name, model.Usuario),
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect("Home/Index");

            }
            //Até aqui
            ModelState.AddModelError("", "Usuário não cadastrado!");
            return View();
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
			return Redirect("google.com");
		}
		public ActionResult ForgPass()
		{
			return View();
		}
	}
}