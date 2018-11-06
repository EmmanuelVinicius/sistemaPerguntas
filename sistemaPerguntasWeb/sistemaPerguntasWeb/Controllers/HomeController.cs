using sistemaPerguntasWeb.App_Start;
using sistemaPerguntasWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Controllers
{
    //setar o id de todas as paginas com o id que vem do login, quando o usuario digita o email e a senha é verificada.(Retornar o IDAluno de lá)
    //[Authorize(Roles = "")]
    public class HomeController : Controller
    {
        List<int> direcao = new List<int>();
        // GET: Home
        public ActionResult Index()
        {
            List<Etapas> etapas = new List<Etapas>();
            var comando = SQL.GetDataSet("SELECT * FROM RegioesPais"/*Etapas*/);
            int cont = 0;
            for (int i = 0; i < comando.Tables[0].Rows.Count; i++)
            {
                etapas.Add(new Etapas());
                etapas[cont].IDRegiaoPais/*IDEtapa*/ = (int)comando.Tables[0].Rows[i]["IDRegiaoPais"];
                etapas[cont].Nome/*Descricao*/ = comando.Tables[0].Rows[i]["Nome"].ToString();

                cont++;
            }
            var IDAluno = Request.QueryString["IDAluno"].ToString();
            StringBuilder dsAluno = new StringBuilder();
            dsAluno.Append(" SELECT Etapa FROM Alunos WHERE IDAluno = @IDAluno");

            Dictionary<string, Object> parametros = new Dictionary<string, Object>();
            parametros.Add("@IDAluno", IDAluno);

            ViewBag.ID = 4/*SQL.ExecuteScalar(dsAluno.ToString(), CommandType.Text, parametros)*/;
            return View(etapas);
        }
        public ActionResult MinhasAulas()
        {
            List<Legislacao> model = new List<Legislacao>();
            model.Add(new Legislacao(1, 1, "Legislação", 15));
            model.Add(new Legislacao(2, 1, "Direção Defensiva", 15));
            model.Add(new Legislacao(3, 1, "Meio Ambiente", 9));
            model.Add(new Legislacao(4, 1, "Mecânica", 6));
            /*
                var comando = SQL.ExecuteReader("SELECT * FROM Legislacao");
                int cont = 0;
                while (comando.HasRows)
                {
                    model[cont].Descricao = comando["Descricao"].ToString();
                    cont++ ;
                }
                */
            return View(model);
        }
        [HttpPost]
        public ActionResult LegislacaoPartial(int[] selecoes)
        {
            selecoes = new int[Request.Form.Count];
            for (int i = 0; i < selecoes.Length; i++)
            {
                selecoes[i] = Request.Form["aulas"][i];
            }
            return RedirectToAction("MinhasAulas");
        }
        public PartialViewResult DirecaoPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult DirecaoPartial(int[] caixasMarcadas)
        {
            caixasMarcadas = new int[Request.Form.Count];
            for (int i = 0; i < caixasMarcadas.Length; i++)
            {
                caixasMarcadas[i] = Request.Form["aulas"][i];
            }
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