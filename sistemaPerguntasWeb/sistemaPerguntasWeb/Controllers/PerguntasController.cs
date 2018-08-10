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
        public ActionResult Legislacao(List<Perguntas> model)
        {
            int pontos = 0;
            model = new List<Perguntas>();
            model.Add(new Perguntas(1, "Quantas aulas é necessário para fazer o exame de direção?", "10", "20", "30", "40", "b"));
            model.Add(new Perguntas(2, "Quantas aulas é necessário para fazer a prova de legislação?", "15", "25", "35", "45", "d"));

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