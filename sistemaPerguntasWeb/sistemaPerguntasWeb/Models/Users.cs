using System.Data.SqlClient;
using System.Configuration;

namespace sistemaPerguntasWeb.Models
{
    public class Users
	{
		public int id { get; set; }
		public string usuario { get; set; }
		public string senha { get; set; }
		public string email { get; set; }
		public string nomeCompleto { get; set; }
		public bool sexo { get; set; }
		public bool termos { get; set; }

		private int _id;
		private string _usuario;
		private string _senha;
		private string _email;
		private string _nomeCompleto;
		private bool _sexo;
		private bool _termos;

		public Users()
		{
			//id = _id;
			usuario = _usuario;
			senha = _senha;
			email = _email;
			nomeCompleto = _nomeCompleto;
			sexo = _sexo;
			termos = _termos;
            ConexBanco();
		}

        private void ConexBanco()
        {
            string strConexao = ConfigurationManager.ConnectionStrings["iusConnectionString"].ConnectionString;
            SqlConnection banco = new SqlConnection(strConexao);
            SqlCommand ins = new SqlCommand();
            ins.CommandText = $@"INSERT INTO Perguntas
                VALUES ('{_usuario}','{_senha}', '{_email}', '{_nomeCompleto}', '{_sexo}', '{_termos}' )";
            ins.Connection = banco;
            banco.Open();
            ins.ExecuteNonQuery();
            banco.Close();
        }
	}
}