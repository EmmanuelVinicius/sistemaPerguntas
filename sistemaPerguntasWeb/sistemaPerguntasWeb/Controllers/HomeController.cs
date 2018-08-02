using sistemaPerguntasWeb.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Controllers
{
    //[Authorize(Roles = "")]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Etapas> etapas = new List<Etapas>();
            string strConexao = ConfigurationManager.ConnectionStrings["iusConnectionString"].ConnectionString;
            SqlConnection banco = new SqlConnection(strConexao);
            SqlCommand ins = new SqlCommand();
            ins.CommandText = $"SELECT * FROM RegioesPais";
            //ins.CommandText = $"SELECT * FROM Etapas";
            ins.Connection = banco;
            banco.Open();
            var dr = ins.ExecuteReader();

            int cont = 0;
            while (dr.Read())
            {
                etapas.Add(new Etapas());
                etapas[cont].IDRegiaoPais = (int)dr["IDRegiaoPais"];
                etapas[cont].Nome = dr["Nome"].ToString();
                cont++;
            }
            banco.Close();
            return View(etapas);
        }
        public ActionResult MinhasAulas()
        {
            return View();
        }
        public ActionResult Programacao()
        {
            return View();
        }
        public ActionResult Direcao()
        {
            return View();
        }
        public RedirectToRouteResult Provinha()
        {
            return RedirectToAction("Legislacao", "Perguntas");
        }
    }
}