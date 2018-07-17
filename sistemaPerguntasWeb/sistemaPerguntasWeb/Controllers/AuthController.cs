using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sistemaPerguntasWeb.Models;

namespace sistemaPerguntasWeb.Controllers
{
	public class AuthController : Controller
	{
		// GET: Auth
		public ActionResult Login()
		{
			var users = new Users();
			return View(users);
		}
		[HttpPost]
		public ActionResult Login(Users name, Users pass)
		{
			List<Users> users = new List<Users>();
			users.Add(new Users('1', ))
			name = users.usuario;
			return View("Retorno");
		}
		public ActionResult Register()
		{
			Users users = new Users();
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