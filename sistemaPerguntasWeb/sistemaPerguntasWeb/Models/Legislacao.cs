using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
	public class Legislacao
	{
		//public Legislacao(int _IDLegislacao, int _IDAluno, string _Descricao, int _QuantidadeAulas)
		//{
  //          IDLegislacao = _IDLegislacao;
  //          IDAluno = _IDAluno;
  //          Descricao = _Descricao;
		//	QuantidadeAulas = _QuantidadeAulas;
		//}
		public int IDLegislacao { get; set; }
        public int IDAluno { get; set; }
        public string Descricao { get; set; }
		public int QuantidadeAulas { get; set; }
	}
}