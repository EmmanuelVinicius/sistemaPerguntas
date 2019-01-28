using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
	public class Legislacao
	{
		public int IDLegislacao { get; set; }
        public int IDAluno { get; set; }
        public string Tema { get; set; }
		public int QuantidadeAulasParaOTema { get; set; }
        public List<ComentarioLegislacao> Comentarios { get; set; }

    }
}