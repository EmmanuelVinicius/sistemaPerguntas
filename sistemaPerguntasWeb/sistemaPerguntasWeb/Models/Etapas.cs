using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace sistemaPerguntasWeb.Models
{
    public class Etapas
    {
        public int IDRegiaoPais { get; set; }
        public string Nome { get; set; }
 /*
        public Etapas(int _IDRegiaoPais, string _Nome)
        {
            IDRegiaoPais = _IDRegiaoPais;
            Nome = _Nome;
        }
       public int IDEtapa { get; set; }
        public string Descricao { get; set; }

        public List<Etapas> GetEtapas()
        {
            List<Etapas> etapas = new List<Etapas>();
            string stringConexao = ConfigurationManager.ConnectionStrings["ConnectionAWS"].ConnectionString;
            SqlConnection banco = new SqlConnection(stringConexao);
            SqlCommand comando = new SqlCommand();
            comando.CommandText = $"SELECT * FROM Etapas";
            comando.Connection = banco;
            banco.Open();
            var lerDados = comando.ExecuteReader();

            int cont = 0;
            while (lerDados.Read())
            {
                etapas.Add(new Etapas());
                etapas[cont].IDEtapa = (int)lerDados["IDRegiaoPais"];
                etapas[cont].Descricao = lerDados["Nome"].ToString();
                    
                cont++;
            }
            banco.Close();
            return etapas;
        }*/
    }
}