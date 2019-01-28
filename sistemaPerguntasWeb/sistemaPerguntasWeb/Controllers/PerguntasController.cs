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
            var command = SQL.GetDataSet("SELECT * FROM Perguntas");
            for (int i = 0; i < command.Tables[0].Rows.Count; i++)
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
            return View(perguntas);
        }
        [HttpPost]
        public ActionResult Legislacao(List<Perguntas> model)
        {
            int pontos = 0;
            model = new List<Perguntas>();
            /*
            model.Add(new Perguntas(1, "Quantas aulas é necessário para fazer o exame de direção?", "10", "20", "30", "40", "b"));
            model.Add(new Perguntas(2, "Quantas aulas é necessário para fazer a prova de legislação?", "15", "25", "35", "45", "d"));
            */
            for (int i = 0; i < model.Count; i++)
            {
                var botao = Request.Form["radio" + i];
                if (botao == model[i].Certo)
                {
                    pontos++;
                }
            }
            if (pontos > 20)
            {

            }
            return View();
        }
    }
}