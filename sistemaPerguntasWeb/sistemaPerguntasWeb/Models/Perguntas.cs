    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
    public class Perguntas
    {
		public Perguntas(int _ID, string _corpo, string _opcao1, string _opcao2, string _opcao3, string _opcao4, string _certo)
        {
            ID = _ID;
            Corpo = _corpo;
            Opcao1 = _opcao1;
            Opcao2 = _opcao2;
            Opcao3 = _opcao3;
            Opcao4 = _opcao4;
            Certo = _certo;
        }
        public int ID { get; set; }
        public string Corpo { get; set; }
        public string Opcao1 { get; set; }
        public string Opcao2 { get; set; }
        public string Opcao3 { get; set; }
        public string Opcao4 { get; set; }
        public string Certo { get; set; }
    }
}