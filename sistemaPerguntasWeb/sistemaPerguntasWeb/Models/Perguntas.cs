using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.Models
{
    class Perguntas
    {
		/*
        private string _ID;
        private string _corpo;
        private string _opcao1;
        private string _opcao2;
        private string _opcao3;
        private string _opcao4;
        private string _certo;
		*/
        public int ID { get; set; }
        public string corpo { get; set; }
        public string opcao1 { get; set; }
        public string opcao2 { get; set; }
        public string opcao3 { get; set; }
        public string opcao4 { get; set; }
        public char certo { get; set; }
		/*
		public Perguntas()
        {
            ID = _ID;
            corpo = _corpo;
            opcao1 = _opcao1;
            opcao2 = _opcao2;
            opcao3 = _opcao3;
            opcao4 = _opcao4;
            certo = _certo;
        }
		*/
    }
}