﻿using sistemaPerguntasWeb.Models;
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
            return View(perguntas);
        }
    }
}