using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
	public class Users
	{
		public int id { get; set; }
		public string usuario { get; set; }
		public string senha { get; set; }
		public string email { get; set; }
		public string nomeCompleto { get; set; }
		public bool sexo { get; set; }
		public bool termos { get; set; }

		private int _id;
		private string _usuario;
		private string _senha;
		private string _email;
		private string _nomeCompleto;
		public bool _sexo;
		public bool _termos;

		public Users()
		{
			id = _id;
			usuario = _usuario;
			senha = _senha;
			email = _email;
			nomeCompleto = _nomeCompleto;
			sexo = _sexo;
			termos = _termos;
		}
	}
}