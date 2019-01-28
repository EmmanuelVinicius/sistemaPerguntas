    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
    public class Perguntas
    {
        public int ID { get; set; }
        public string Corpo { get; set; }
        public string OpcaoA { get; set; }
        public string OpcaoB { get; set; }
        public string OpcaoC { get; set; }
        public string OpcaoD { get; set; }
        public string Certo { get; set; }
    }
}