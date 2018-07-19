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
                return View();
            }
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            Users users = new Users();
            //Retirar
            if (model.Usuario == users.usuario && model.Senha == users.senha)
            {
                var identity = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name, users.usuario),
                    new Claim(ClaimTypes.Email, users.email),
                    new Claim(ClaimTypes.Country, "Brasil")
                },
                "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));

            }
            //Até aqui
            ModelState.AddModelError("", "Digite os dados corretamente");
			return View();
		}
        [HttpPost]
		public ActionResult Register(/*int _id,*/ string _usuario,string _senha,string _email,string _nomeCom,bool _sexo,bool _termos
)
        {
			Users users = new Users
            {
                usuario = _usuario,
                senha = _senha,
                email = _email,
                nomeCompleto = _nomeCom,
                sexo = _sexo,
                termos = _termos
            };
			return View(users);
		}
		public ActionResult ForgPass()
		{
			return View();
		}
		public string Retorno()
		{
			return "Passou, cara";
		}
	}
}