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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Etapas> etapas = new List<Etapas>();
            var comando = SQL.GetDataSet("SELECT * FROM Etapas");
            for (int i = 0; i < comando.Tables[0].Rows.Count; i++)
            {
                etapas.Add(new Etapas());
                etapas[i].IDEtapa = (int)comando.Tables[0].Rows[i]["IDEtapa"];
                etapas[i].Descricao = comando.Tables[0].Rows[i]["Descricao"].ToString();
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
            IDAluno = Session["id"].ToString();
            var model = TrazONomeDasAulasDeLegislacao();
            ViewBag.AulasFeitas = TrazAsAulasFeitasDeDirecao(IDAluno);
            
            return View(model);
        }
        public List<ComentarioLegislacao> ListaDeComentarios()
        {
            List<ComentarioLegislacao> model = new List<ComentarioLegislacao>();
            var command = SQL.GetDataSet("SELECT * FROM AlunosEmLegislacao");
            for (int i = 0; i < command.Tables[0].Rows.Count; i++)
            {
                model.Add(new ComentarioLegislacao());
                model[i].NumeroDaAula = (int)command.Tables[0].Rows[i]["NumeroAulaLegislacao"];
                model[i].ComentarioDaAulaDeLegislacao = command.Tables[0].Rows[i]["ComentarioLegislacao"].ToString();
            }
            return model;
        }
        public List<Legislacao> TrazONomeDasAulasDeLegislacao()
        {
            List<Legislacao> model = new List<Legislacao>();
            var comando = SQL.GetDataSet("SELECT * FROM AulasLegislacao");
            for (int i = 0; i < comando.Tables[0].Rows.Count; i++)
            {
                model.Add(new Legislacao());
                model[i].IDLegislacao = (int)comando.Tables[0].Rows[i]["IDAulaLegislacao"];
                model[i].Tema = comando.Tables[0].Rows[i]["Descricao"].ToString();
                model[i].QuantidadeAulasParaOTema = (int)comando.Tables[0].Rows[i]["Quantidade"];
                model[i].Comentarios = TrazOsComentariosDasAulasDeLegislacao(Session["id"].ToString());
            }
            return model;
        }
        public List<ComentarioLegislacao> TrazOsComentariosDasAulasDeLegislacao(string IDAluno)
        {
            List<ComentarioLegislacao> modelo = new List<ComentarioLegislacao>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT NumeroAulaLegislacao, ComentarioLegislacao, AulasLegislacao.IDAulalegislacao FROM AlunosEmLegislacao");
            sql.Append(" INNER JOIN Alunos ON Alunos.IDAluno = AlunosEmLegislacao.IDAluno");
            sql.Append(" INNER JOIN AulasLegislacao ON AulasLegislacao.IDAulaLegislacao = AlunosEmLegislacao.IDAulalegislacao");
            sql.Append(" WHERE Alunos.IDAluno = @IDAluno");

            Dictionary<string, Object> parametros = new Dictionary<string, Object>();
            parametros.Add("@IDAluno", IDAluno);
            var comando = SQL.GetDataSet(sql.ToString(), CommandType.Text, parametros);
            for (int i = 0; i < comando.Tables[0].Rows.Count; i++)
            {
                modelo.Add(new ComentarioLegislacao());
                modelo[i].IDAulaLegislacao = (int)comando.Tables[0].Rows[i]["IDAulaLegislacao"];
                modelo[i].NumeroDaAula = (int)comando.Tables[0].Rows[i]["NumeroAulaLegislacao"];
                modelo[i].ComentarioDaAulaDeLegislacao = comando.Tables[0].Rows[i]["ComentarioLegislacao"].ToString();
            }
            return modelo;
        }

            public int TrazAsAulasFeitasDeDirecao(string IDAluno)
        {
            var AulasFeitas = $"SELECT AulasFeitas FROM Direcao WHERE IDAluno = {IDAluno};";

            var consulta = SQL.GetDataSet(AulasFeitas);
            var NumeroDeAulasFeitas = int.Parse(consulta.Tables[0].Rows[0]["AulasFeitas"].ToString());
            return NumeroDeAulasFeitas;
        }
        [HttpPost]
        public ActionResult LegislacaoPartial()
        {
            var urlChecks = Request.Form["check"];
            var urlComments = Request.Form["comentario"];
            var IDAluno = int.Parse(Session["id"].ToString());
            var btnID = int.Parse(Request.Form["btnID"]);

            StringBuilder sbQuery = new StringBuilder();
            for (int contador = 0; contador < urlChecks.Split(',').Length; contador++)
            {
                var Checks = (urlChecks.Split(',')[contador] == null) ? null : urlChecks.Split(',')[contador];
                var Comments = (urlComments.Split(',')[contador] == null) ? null : urlComments.Split(',')[contador];

                sbQuery.Append("INSERT INTO AlunosEmLegislacao (IDAluno, IDAulaLegislacao, NumeroAulaLegislacao, ComentarioLegislacao ) VALUES");
                sbQuery.Append($"({IDAluno}, {btnID}, {Checks}, '{Comments}');");
                sbQuery.Append("");
            }
            SQL.ExecutarQuery(sbQuery.ToString());
            return RedirectToAction("MinhasAulas");
        }
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