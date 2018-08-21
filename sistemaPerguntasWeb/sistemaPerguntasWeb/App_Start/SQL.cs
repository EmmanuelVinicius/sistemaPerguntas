using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace sistemaPerguntasWeb.App_Start
{
    public class SQL
    {

        private static string conexao = ConfigurationManager.ConnectionStrings["iusConnectionString"].ConnectionString;

        //Primeiro método: Serve para fazer inserções, alterações e exclusões.
        //Parâmetro: Query.
        public static void ExecutarQuery_SemTempoLimite(string strQuery)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = conexao;

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.CommandTimeout = 0;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        //Segundo método: Executa procedures de inserção.
        //Parâmetros: Variáveis para Procedures.
        public static int ExecuteScalar(string nomeProc, Dictionary<string, SqlDbType> parametroOutPut, Dictionary<string, Object> parametros)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = conexao;
            string retorno = "";
            try
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nomeProc;
                cmd.CommandTimeout = 120;

                foreach (KeyValuePair<string, SqlDbType> parametroOut in parametroOutPut)
                {
                    retorno = parametroOut.Key;
                    cmd.Parameters.Add(new SqlParameter(retorno, parametroOut.Value));
                    cmd.Parameters[retorno].Direction = ParameterDirection.Output;
                }

                foreach (KeyValuePair<string, Object> parametro in parametros)
                {
                    cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                cnn.Open();

                int registrosAlterados = cmd.ExecuteNonQuery();
                int ID;
                if (!(registrosAlterados == 0))
                {
                    ID = ((int)(cmd.Parameters[retorno].Value));
                }
                else
                {
                    ID = -1;
                }

                return ID;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
                parametros.Clear();
                parametroOutPut.Clear();
                retorno = "";
            }
        }
        //Terceiro método: Executar consulta por procedures.
        //Parâmetro: Variáveis para Procedures.
        public static void ExecutarQuery_SemTempoLimite(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = conexao;

            try
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = Tipo;
                cmd.CommandText = strQuery;
                cmd.CommandTimeout = 0;

                foreach (KeyValuePair<string, Object> parametro in parametros)
                {
                    cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
                parametros.Clear();
            }
        }
        //Quarto método: Serve para fazer inserções, alterações e exclusões. 
        //Parâmetro: Query.
        public static void ExecutarQuery(string strQuery)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = conexao;

            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.CommandTimeout = 120;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        public static void ExecutarQuery(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = conexao;

            try
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = Tipo;
                cmd.CommandText = strQuery;
                cmd.CommandTimeout = 120;

                foreach (KeyValuePair<string, Object> parametro in parametros)
                {
                    cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
                parametros.Clear();
            }
        }
        public static SqlDataReader ExecuteReader(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            SqlConnection cnn = new SqlConnection();
            SqlDataReader dr;
            cnn.ConnectionString = conexao;

            try
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = Tipo;
                cmd.CommandText = strQuery;
                cmd.CommandTimeout = 120;

                foreach (KeyValuePair<string, Object> parametro in parametros)
                {
                    cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                cnn.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
                parametros.Clear();
            }
        }

        public static SqlDataReader ExecuteReader(string strQuery)
        {
            SqlConnection cnn = new SqlConnection();
            SqlDataReader dr;
            cnn.ConnectionString = conexao;

            try
            {
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.CommandTimeout = 120;

                cnn.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}