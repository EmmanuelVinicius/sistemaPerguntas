using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace sistemaPerguntasWeb.Models
{
    public class Etapas
    {
        public Etapas(int IDRegiaoPais, string Nome)
        {
            IDRegiaoPais = _IDRegiaoPais;
            Nome = _Nome;
        }
        
        public int _IDRegiaoPais;
        public string _Nome;
        
        public int IDRegiaoPais { get; set; }
        public string Nome { get; set; }
        public List<Etapas> GetEtapas()
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
                etapas.Add(new Etapas(
                etapas[cont].IDRegiaoPais = (int)dr["IDRegiaoPais"],
                etapas[cont].Nome = dr["Nome"].ToString()
                    ));
                cont++;
            }
            banco.Close();
            return etapas;
        }
    }
}