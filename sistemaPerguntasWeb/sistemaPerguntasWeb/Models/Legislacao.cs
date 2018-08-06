using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
	public class Legislacao
	{
		public Legislacao(int _IDLegislacao, string _Descricao, int _QuantidadeAulas)
		{
			IDLegislacao = _IDLegislacao;
			Descricao = _Descricao;
			QuantidadeAulas = _QuantidadeAulas;
		}
		public int IDLegislacao { get; set; }
		public string Descricao { get; set; }
		public int QuantidadeAulas { get; set; }
	}
}