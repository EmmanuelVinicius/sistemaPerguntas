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
        public ActionResult Legislacao()
        {
            List<Perguntas> perguntas = new List<Perguntas>();
            perguntas.Add(new Perguntas(1, "Quantas aulas é necessário para fazer o exame de direção?", "10", "20", "30", "40", 'b'));
            perguntas.Add(new Perguntas(1, "Quantas aulas é necessário para fazer a prova de legislação?", "15", "25", "35", "45", 'd'));
            return View(perguntas);
        }
    }
}