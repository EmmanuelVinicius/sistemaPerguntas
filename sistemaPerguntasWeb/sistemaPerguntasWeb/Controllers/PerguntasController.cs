using sistemaPerguntasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Controllers
{
    public class PerguntasController : Controller
    {
        // GET: Perguntas
        [HttpGet]
        public ActionResult Legislacao()
        {
            List<Perguntas> perguntas = new List<Perguntas>();
            perguntas.Add(new Perguntas(1, "Quantas aulas é necessário para fazer o exame de direção?", "10", "20", "30", "40", "b"));
            perguntas.Add(new Perguntas(2, "Quantas aulas é necessário para fazer a prova de legislação?", "15", "25", "35", "45", "d"));
            return View(perguntas);
        }
        [HttpPost]
        public ActionResult Legislacao(List<string> model)
        {
            model = new List<string>();

            int pontos = 0;
            List<Perguntas> perguntas = new List<Perguntas>();
            perguntas.Add(new Perguntas(1, "Quantas aulas é necessário para fazer o exame de direção?", "10", "20", "30", "40", "b"));
            perguntas.Add(new Perguntas(2, "Quantas aulas é necessário para fazer a prova de legislação?", "15", "25", "35", "45", "d"));

            for (int i = 1; i <= Request.Form.Count; i++)
            {
                model.Add(Request.Form["radio" + i].ToString());
                string certa = perguntas[i - 1].Certo.ToString();
                if (model.ToString() == certa)
                    pontos++;
            }
            string resultado = (pontos > 1) ? "Parabéns" + pontos : "Desculpe" + pontos;
            return Json(resultado);
        }
    }
}