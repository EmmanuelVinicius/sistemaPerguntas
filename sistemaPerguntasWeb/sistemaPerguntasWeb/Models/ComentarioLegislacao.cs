using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
    public class ComentarioLegislacao
    {
        public int IDAulaLegislacao { get; set; }
        public string ComentarioDaAulaDeLegislacao { get; set; }
        public int NumeroDaAula { get; set; }
    }
}