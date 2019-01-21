using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace sistemaPerguntasWeb.App_Start
{
    public class SQL
    {
        private static string conexao = ConfigurationManager.ConnectionStrings["mySqlExternoConnectionString"].ConnectionString;
        //Update, Alter e Delete
        public static void ExecutarQuery_SemTempoLimite(string strQuery)
        {
            MySqlConnection cnn = new MySqlConnection();
            cnn.ConnectionString = conexao;

            MySqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.CommandTimeout = 0;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        //Query.ToString(), CommandType.Text, parametros
        public static int ExecuteScalar(string nomeProc, Dictionary<string, MySqlDbType> parametroOutPut, Dictionary<string, Object> parametros)
        {
            MySqlConnection cnn = new MySqlConnection();
            cnn.ConnectionString = conexao;
            string retorno = "";
            try
            {
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nomeProc;
                cmd.CommandTimeout = 120;

                foreach (KeyValuePair<string, MySqlDbType> parametroOut in parametroOutPut)
                {
                    retorno = parametroOut.Key;
                    cmd.Parameters.Add(new MySqlParameter(retorno, parametroOut.Value));
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
            catch (MySqlException ex)
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
        public static void ExecutarQuery_SemTempoLimite(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            MySqlConnection cnn = new MySqlConnection();
            cnn.ConnectionString = conexao;

            try
            {
                MySqlCommand cmd = cnn.CreateCommand();
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
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
                parametros.Clear();
            }
        }

        public static void ExecutarQuery(string strQuery)
        {
            MySqlConnection cnn = new MySqlConnection();
            cnn.ConnectionString = conexao;

            MySqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.CommandTimeout = 120;

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
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
            MySqlConnection cnn = new MySqlConnection();
            cnn.ConnectionString = conexao;

            try
            {
                MySqlCommand cmd = cnn.CreateCommand();
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
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
                parametros.Clear();
            }
        }

        public static int ExecuteScalar(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            MySqlConnection cnn = new MySqlConnection();
            cnn.ConnectionString = conexao;
            object retorno;

            try
            {
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = Tipo;
                cmd.CommandText = strQuery;
                cmd.CommandTimeout = 120;

                foreach (KeyValuePair<string, Object> parametro in parametros)
                {
                    cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                cnn.Open();
                retorno = cmd.ExecuteScalar();

                int Total = 0;

                if (retorno != null && !int.TryParse(retorno.ToString(), out Total))
                    Total = 0;

                return Total;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
                parametros.Clear();
            }
        }

        public static float ExecuteScalar_float(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            MySqlConnection cnn = new MySqlConnection();
            cnn.ConnectionString = conexao;
            object retorno;

            try
            {
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = Tipo;
                cmd.CommandText = strQuery;
                cmd.CommandTimeout = 120;

                foreach (KeyValuePair<string, Object> parametro in parametros)
                {
                    cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                cnn.Open();
                retorno = cmd.ExecuteScalar();

                float Total = 0;

                if (retorno != null && !float.TryParse(retorno.ToString(), out Total))
                    Total = 0;

                return Total;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
                parametros.Clear();
            }
        }

        public static MySqlDataReader ExecuteReader(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            MySqlConnection cnn = new MySqlConnection();
            MySqlDataReader dr;
            cnn.ConnectionString = conexao;

            try
            {
                MySqlCommand cmd = cnn.CreateCommand();
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
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
                parametros.Clear();
            }
        }

        public static MySqlDataReader ExecuteReader(string strQuery)
        {
            MySqlConnection cnn = new MySqlConnection();
            MySqlDataReader dr;
            cnn.ConnectionString = conexao;

            try
            {
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.CommandTimeout = 120;

                cnn.Open();
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        
        public static DataSet GetDataSet(string strQuery)
        {
            MySqlConnection MyConnection = new MySqlConnection(conexao);
            MySqlDataAdapter MyDataAdapter = new MySqlDataAdapter(strQuery, MyConnection);
            MyDataAdapter.SelectCommand.CommandType = CommandType.Text;
            MyDataAdapter.SelectCommand.CommandTimeout = 120;

            try
            {
                DataSet DS = new DataSet();
                MyDataAdapter.Fill(DS, "Resultado");
                return DS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public static DataSet GetDataSet(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            MySqlConnection MyConnection = new MySqlConnection(conexao);
            MySqlDataAdapter MyDataAdapter = new MySqlDataAdapter(strQuery, MyConnection);
            MyDataAdapter.SelectCommand.CommandType = Tipo;
            MyDataAdapter.SelectCommand.CommandTimeout = 120;

            try
            {
                foreach (KeyValuePair<string, Object> parametro in parametros)
                {
                    MyDataAdapter.SelectCommand.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                DataSet DS = new DataSet();
                MyDataAdapter.Fill(DS, "Resultado");
                return DS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MyConnection.Close();
                parametros.Clear();
            }
        }

        public static DataSet GetDataSet(string strQuery, CommandType Tipo)
        {
            MySqlConnection MyConnection = new MySqlConnection(conexao);
            MySqlDataAdapter MyDataAdapter = new MySqlDataAdapter(strQuery, MyConnection);
            MyDataAdapter.SelectCommand.CommandType = Tipo;
            MyDataAdapter.SelectCommand.CommandTimeout = 120;

            try
            {
                DataSet DS = new DataSet();
                MyDataAdapter.Fill(DS, "Resultado");
                return DS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MyConnection.Close();
            }
        }

        public static DataSet GetDataSet_SemTempoLimite(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            MySqlConnection MyConnection = new MySqlConnection(conexao);
            MySqlDataAdapter MyDataAdapter = new MySqlDataAdapter(strQuery, MyConnection);
            MyDataAdapter.SelectCommand.CommandType = Tipo;
            MyDataAdapter.SelectCommand.CommandTimeout = 0;

            try
            {
                foreach (KeyValuePair<string, Object> parametro in parametros)
                {
                    MyDataAdapter.SelectCommand.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                DataSet DS = new DataSet();
                MyDataAdapter.Fill(DS, "Resultado");
                return DS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MyConnection.Close();
                parametros.Clear();
            }
        }
        public static DataSet GetDataSet_SemTempoLimite(string strQuery)
        {
            MySqlConnection MyConnection = new MySqlConnection(conexao);
            MySqlDataAdapter MyDataAdapter = new MySqlDataAdapter(strQuery, MyConnection);
            MyDataAdapter.SelectCommand.CommandType = CommandType.Text;
            MyDataAdapter.SelectCommand.CommandTimeout = 0;

            try
            {
                DataSet DS = new DataSet();
                MyDataAdapter.Fill(DS, "Resultado");
                return DS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MyConnection.Close();
            }
        }
        public static DataTable GetDataTable(string strQuery, CommandType Tipo, Dictionary<string, Object> parametros)
        {
            MySqlConnection MyConnection = new MySqlConnection(conexao);
            MySqlDataAdapter MyDataAdapter = new MySqlDataAdapter(strQuery, MyConnection);
            MyDataAdapter.SelectCommand.CommandType = Tipo;
            MyDataAdapter.SelectCommand.CommandTimeout = 120;

            try
            {
                foreach (KeyValuePair<string, Object> parametro in parametros)
                {
                    MyDataAdapter.SelectCommand.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }

                DataSet DS = new DataSet();
                MyDataAdapter.Fill(DS, "Resultado");
                return DS.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MyConnection.Close();
                parametros.Clear();
            }
        }

        public static DataTable GetDataTable(string strQuery)
        {
            MySqlConnection MyConnection = new MySqlConnection(conexao);
            MySqlDataAdapter MyDataAdapter = new MySqlDataAdapter(strQuery, MyConnection);
            MyDataAdapter.SelectCommand.CommandType = CommandType.Text;
            MyDataAdapter.SelectCommand.CommandTimeout = 120;

            try
            {
                DataSet DS = new DataSet();
                MyDataAdapter.Fill(DS, "Resultado");
                return DS.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                MyConnection.Close();
            }
        }   
    }

}