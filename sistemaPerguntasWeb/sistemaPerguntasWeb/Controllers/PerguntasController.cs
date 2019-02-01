using sistemaPerguntasWeb.App_Start;
using sistemaPerguntasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Controllers
{
    public class PerguntasController : Controller
    {
        // GET: Perguntas
        public ActionResult Legislacao()
        {
            return View(TrazAsPerguntas());
        }
        [HttpPost]
        public JsonResult Legislacao(string inputs)
        {
            int pontos = 0;

            var valorLimpo = inputs.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Replace(',', ' ').Replace(" ", "");
            var respostas = TrazAsPerguntas();
            for (int i = 0; i < valorLimpo.Length; i++)
            {
                var selecao = valorLimpo.Substring(i, 1);
                if (respostas[i].Certo == selecao.ToString())
                {
                    pontos ++;
                }
            }
            var resultado = (pontos >= 21) ? true : false;
            return Json(resultado);
        }
        public List<Perguntas> TrazAsPerguntas()
        {
            List<Perguntas> perguntas = new List<Perguntas>();
            var command = SQL.GetDataSet("SELECT * FROM Perguntas");
            for (int i = 0; i < 30; i++)
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