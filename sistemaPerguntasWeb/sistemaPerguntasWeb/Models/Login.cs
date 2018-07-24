using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Models
{
    public class Login
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }

        public bool ConexBanco(string user, string pass)
        {
            string strConexao = ConfigurationManager.ConnectionStrings["iusConnectionString"].ConnectionString;
            SqlConnection banco = new SqlConnection(strConexao);
            SqlCommand ins = new SqlCommand();
            ins.CommandText = $"SELECT COUNT(*) FROM Escopos WHERE Escopo = '{user}' AND IDEscopo = '{pass}'";
            ins.Connection = banco;
            banco.Open();
            var dr = ins.ExecuteReader();
            bool TemLinhas = dr.HasRows;
            dr.Close();
            banco.Close();
            if (TemLinhas)
                return true;
            else
                return false;
        }
    }
}