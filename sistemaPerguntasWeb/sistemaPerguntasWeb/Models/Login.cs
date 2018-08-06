using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace sistemaPerguntasWeb.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ReturnUrl { get; set; }
        public bool Conex(string email, string pass)
        {
            Email = email;
            Senha = pass;
            if (Banco(email,Criptografa(Senha)))
                return true;
            else
                return false;
        }
		private string Criptografa(string senha)
		{
			var stringHash = "";
			try
			{
				UnicodeEncoding encode = new UnicodeEncoding();
				byte[] hashBytes, messageBytes = encode.GetBytes(senha);
				SHA512Managed managed = new SHA512Managed();
				hashBytes = managed.ComputeHash(messageBytes);

				foreach (byte b in hashBytes)
				{
					stringHash += String.Format("{0:x2}", b);
				}
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return stringHash;
		}
        private bool Banco(string email, string senha)
        {
			try
			{

			/*Conexão do trampo
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
			*/

			/*Conexão do barraco*/
			string strConexao = ConfigurationManager.ConnectionStrings["homeConnectionString"].ConnectionString;
			MySqlConnection banco = new MySqlConnection(strConexao);
			MySqlCommand ins = new MySqlCommand();

			ins.CommandText = $"SELECT A.IDAluno, A.NomeCompleto FROM Usuarios U INNER JOIN Alunos A ON U.IDAluno = A.IDAluno WHERE U.Email = '{email}' AND U.Senha = '{senha}'";
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
			catch (Exception ex)
			{

				throw ex;
			}
		}

    }
}