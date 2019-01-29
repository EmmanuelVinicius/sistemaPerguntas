using sistemaPerguntasWeb.App_Start;
using sistemaPerguntasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Controllers
{
    public class PerguntasController : Controller
    {
        // GET: Perguntas
        public ActionResult Legislacao()
        {
            List<Perguntas> perguntas = new List<Perguntas>();
            return View(TrazAsPerguntas(perguntas));
        }
        [HttpPost]
        public ActionResult Submit(List<Perguntas> model)
        {
            var lista = TrazAsPerguntas(model);

            int pontos = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                var selecao = Request.Form["radio-" + i];
                if (selecao == lista[i].Certo)
                    pontos++;
            }
            var resultado = (pontos >= 2) ? true : false;
            return Json(resultado);
        }
        public List<Perguntas> TrazAsPerguntas(List<Perguntas> perguntas)
        {
            perguntas = new List<Perguntas>();
            var command = SQL.GetDataSet("SELECT * FROM Perguntas");
            for (int i = 0; i < /*command.Tables[0].Rows.Count*/2; i++)
            {
                perguntas.Add(new Perguntas());
                perguntas[i].ID = (int)command.Tables[0].Rows[i]["ID"];
                perguntas[i].Corpo = command.Tables[0].Rows[i]["Corpo"].ToString();
                perguntas[i].OpcaoA = command.Tables[0].Rows[i]["OpcaoA"].ToString();
                perguntas[i].OpcaoB = command.Tables[0].Rows[i]["OpcaoB"].ToString();
                perguntas[i].OpcaoC = command.Tables[0].Rows[i]["OpcaoC"].ToString();
                perguntas[i].OpcaoD = command.Tables[0].Rows[i]["OpcaoD"].ToString();
                perguntas[i].Certo = command.Tables[0].Rows[i]["RespostaCerta"].ToString();
            }
            return perguntas;
        }
    }
}