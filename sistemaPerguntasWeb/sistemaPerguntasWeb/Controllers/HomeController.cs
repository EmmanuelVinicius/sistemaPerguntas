using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Mvc;
using sistemaPerguntasWeb.Models;
using sistemaPerguntasWeb.App_Start;

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
            var IDAluno = Request.QueryString["IDAluno"].ToString();
            StringBuilder dsAluno = new StringBuilder();
            dsAluno.Append(" SELECT Etapa FROM Alunos WHERE IDAluno = @IDAluno");

            Dictionary<string, Object> parametros = new Dictionary<string, Object>();
            parametros.Add("@IDAluno", IDAluno);

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

            var comando = SQL.GetDataSet("SELECT * FROM Legislacao");
            int cont = 0;
            for (int i = 0; i < comando.Tables[0].Rows.Count; i++)
            {
                model.Add(new Legislacao());
                model[cont].IDLegislacao = (int)comando.Tables[0].Rows[i]["IDLegislacao"];
                model[cont].Descricao = comando.Tables[0].Rows[i]["Descricao"].ToString();
                model[cont].QuantidadeAulas = (int)comando.Tables[0].Rows[i]["QuantidadeAulas"];
                cont++;
            }

            IDAluno = Request.QueryString["IDAluno"].ToString();
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