using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
    public class Direcao
    {
        public Users ID { get; set; }
        public int NumeroAula { get; set; }
        public string Comentario { get; set; }
        public int Avaliacao { get; set; }
    }
}