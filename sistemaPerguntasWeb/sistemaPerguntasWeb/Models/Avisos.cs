using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
    public class Avisos
    {
        public int IDAviso { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Corpo { get; set; }
        public string Fonte { get; set; }
    }
}