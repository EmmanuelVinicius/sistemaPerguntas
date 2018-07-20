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
            //banco.ConnectionString = "connectionString = 'Password=bdcal12@@;Persist Security Info=True;Connect Timeout=450;User ID=ius;Initial Catalog=Solicitacoes2;Data Source=ius-srv-ti01&#92;DEV' providerName = 'System.Data.SqlClient'";
            SqlCommand ins = new SqlCommand();
            ins.CommandText = $"SELECT COUNT(*) FROM Escopos WHERE Escopo = '{user}' AND IDEscopo = '{pass}'";
            /*
            ins.CommandText = $@"INSERT INTO Perguntas
                VALUES ('{_usuario}','{_senha}', '{_email}', '{_nomeCompleto}', '{_sexo}', '{_termos}' )";
            */
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