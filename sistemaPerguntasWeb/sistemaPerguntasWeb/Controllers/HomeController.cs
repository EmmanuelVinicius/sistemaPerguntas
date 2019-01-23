using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Mvc;
using sistemaPerguntasWeb.Models;
using sistemaPerguntasWeb.App_Start;
using System.Net;
using System.IO;

namespace sistemaPerguntasWeb.Controllers
{
    //setar o id de todas as paginas com o id que vem do login, quando o usuario digita o email e a senha é verificada.(Retornar o IDAluno de lá)
    //[Authorize(Roles = "")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Etapas> etapas = new List<Etapas>();
            var comando = SQL.GetDataSet("SELECT * FROM Etapas");
            int cont = 0;
            for (int i = 0; i < comando.Tables[0].Rows.Count; i++)
            {
                etapas.Add(new Etapas());
                etapas[cont].IDEtapa = (int)comando.Tables[0].Rows[i]["IDEtapa"];
                etapas[cont].Descricao = comando.Tables[0].Rows[i]["Descricao"].ToString();

                cont++;
            }
            Session["id"] = Request.QueryString["IDAluno"].ToString();
            StringBuilder dsAluno = new StringBuilder();
            dsAluno.Append(" SELECT Etapa FROM Alunos WHERE IDAluno = @IDAluno");

            Dictionary<string, Object> parametros = new Dictionary<string, Object>();
            parametros.Add("@IDAluno", Session["id"]);

            ViewBag.ID = SQL.ExecuteScalar(dsAluno.ToString(), CommandType.Text, parametros);
            return View(etapas);
        }
        public ActionResult MinhasAulas(string IDAluno)
        {

            List<Legislacao> model = new List<Legislacao>();
            /*
            model.Add(new Legislacao(1, 1, "Legislação", 15));
            model.Add(new Legislacao(2, 1, "Direção Defensiva", 15));
            model.Add(new Legislacao(3, 1, "Meio Ambiente", 9));
            model.Add(new Legislacao(4, 1, "Mecânica", 6));

            */

            var comando = SQL.GetDataSet("SELECT * FROM AulasLegislacao");
            int cont = 0;
            for (int i = 0; i < comando.Tables[0].Rows.Count; i++)
            {
                model.Add(new Legislacao());
                model[cont].IDLegislacao = (int)comando.Tables[0].Rows[i]["IDAulaLegislacao"];
                model[cont].Descricao = comando.Tables[0].Rows[i]["Descricao"].ToString();
                model[cont].QuantidadeAulas = (int)comando.Tables[0].Rows[i]["Quantidade"];
                cont++;
            }
            IDAluno = Session["id"].ToString();
            var AulasFeitas = ("SELECT AulasFeitas FROM Direcao WHERE IDAluno = @IDAluno");

            Dictionary<string, Object> parametros = new Dictionary<string, Object>();
            parametros.Add("@IDAluno", IDAluno);
            var consulta = SQL.GetDataSet(AulasFeitas, CommandType.Text, parametros);
            ViewBag.AulasFeitas = int.Parse(consulta.Tables[0].Rows[0]["AulasFeitas"].ToString());
            return View(model);
        }
        [HttpPost]
        public ActionResult LegislacaoPartial(string[] caixasMarcadas, string[] comentarios)
        {
            int condicao = Request.Form.Count;
            caixasMarcadas = new string[condicao];
            comentarios = new string[condicao];
            for (int i = 0; i < condicao; i++)
            {
                caixasMarcadas[i] = Request.Form["check-" + (i + 1)];
                comentarios[i] = Request.Form["comentario-" + (i + 1)];
            }
            return RedirectToAction("MinhasAulas");
        }
        //public PartialViewResult DirecaoPartial()
        //{
        //    var comando = ("SELECT AulasFeitas FROM Direcao WHERE IDAluno = @IDAluno");
        //    ViewBag.AulasFeitas = SQL.GetDataSet(comando);

        //    return PartialView();
        //}
        [HttpPost]
        public ActionResult DirecaoPartial()
        {
            var url = Request.Form["aulas"];
            var caixasMarcadas = url.Split(',').Length;
            Dictionary<string, Object> parametros = new Dictionary<string, Object>();
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("UPDATE Direcao SET AulasFeitas = @AulasFeitas WHERE IDAluno = @IDAluno");


            parametros.Add("@IDAluno", Session["id"]);
            parametros.Add("@AulasFeitas", caixasMarcadas);

            SQL.ExecutarQuery(sbQuery.ToString(), CommandType.Text, parametros);

            return RedirectToAction("MinhasAulas");
        }
        public ActionResult ProgramacaoAulas()
        {
            return View();
        }
        public ActionResult ProgramacaoDiversas()
        {
            List<Programacoes> model = new List<Programacoes>();
            model.Add(new Programacoes("Arroz, batata e cenoura!"));
            return View(model);
        }
        public RedirectToRouteResult Provinha()
        {
            return RedirectToAction("Legislacao", "Perguntas");
        }
        public ActionResult Funcionarios()
        {
            return View();
        }
    }
}