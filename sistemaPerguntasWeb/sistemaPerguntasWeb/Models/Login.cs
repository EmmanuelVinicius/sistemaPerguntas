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

        public bool Conex(string user, string pass)
        {
            Usuario = user;
            Senha = pass;
            if (Banco())
                return true;
            else
                return false;
        }
        private bool Banco()
        {
            string strConexao = ConfigurationManager.ConnectionStrings["iusConnectionString"].ConnectionString;
            SqlConnection banco = new SqlConnection(strConexao);
            SqlCommand ins = new SqlCommand();
            ins.CommandText = $"SELECT * FROM Escopos WHERE Escopo = '{Usuario}' AND IDEscopo = '{Senha}'";
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