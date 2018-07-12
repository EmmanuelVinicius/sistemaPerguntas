using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pgt
{
    class Program
    {
        static void Main(string[] args)
        {
            string strConexao = ConfigurationManager.ConnectionStrings["iusConnectionString"].ConnectionString;
            SqlConnection banco = new SqlConnection(strConexao);
            Mensagens msg = new Mensagens();
            List<Perguntas> per = new List<Perguntas>();
            bool continua = false;
            var op = 0;
            do
            {
                Console.WriteLine("Inserir Pergunta (1) - Responder as Questões (2)");
                try
                {
                    op = int.Parse(Console.ReadLine());
                    if (op == 1 || op == 2)
                        continua = true;
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        continua = false;
                    }
                }
                catch
                {
                    msg.ErroCatch(continua);
                }
            } while (!continua);
            continua = false;
            if (op == 1)
            {
                do
                {
                    Console.WriteLine("Digite o corpo da pergunta:");
                    string Corpo = Console.ReadLine();
                    Console.WriteLine("Digite as opções, de 1 a 4:");
                    string Opcao1 = Console.ReadLine();
                    string Opcao2 = Console.ReadLine();
                    string Opcao3 = Console.ReadLine();
                    string Opcao4 = Console.ReadLine();
                    Console.WriteLine("Digite a opção certa:");
                    char Certo = char.Parse(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("Obrigado por inserir a pergunta, estamos validando...");
                    try
                    {
                        SqlCommand ins = new SqlCommand();
                        ins.CommandText = $@"INSERT INTO Perguntas(Corpo, Opcao1, Opcao2, Opcao3, Opcao4, Certo)
                                VALUES ('{Corpo}','{Opcao1}', '{Opcao2}', '{Opcao3}', '{Opcao4}', '{Certo}' )";
                        ins.Connection = banco;

                        banco.Open();
                        ins.ExecuteNonQuery();
                        Console.Clear();
                        banco.Close();
                        Console.Clear();
                        continua = true;
                        Console.WriteLine("Pergunta inserida com sucesso!");
                        Console.ReadKey();
                    }
                    catch
                    {
                        msg.ErroCatch(continua);
                    }
                } while (!continua);
            }
            else if (op == 2)
            {
                do
                {
                    try
                    {
                        //Leitura dos dados e exibição
                        SqlCommand sel = new SqlCommand();
                        sel.CommandText = "SELECT * FROM Perguntas";
                        sel.Connection = banco;

                        banco.Open();
                        SqlDataReader rdr = sel.ExecuteReader();
                        int nuReg = 0;
                        while (rdr.Read())
                        {
                            per.Add(new Perguntas());
                            per[nuReg].ID = rdr["ID"].ToString();
                            per[nuReg].corpo = rdr["Corpo"].ToString();
                            per[nuReg].opcao1 = rdr["Opcao1"].ToString();
                            per[nuReg].opcao2 = rdr["Opcao2"].ToString();
                            per[nuReg].opcao3 = rdr["Opcao3"].ToString();
                            per[nuReg].opcao4 = rdr["Opcao4"].ToString();
                            per[nuReg].certo = rdr["Certo"].ToString();

                            nuReg++;
                        }
                        banco.Close();




                        int num = 0, pontuacao = 0;
                        while (num < 2)
                        {
                            Console.Clear();
                            Console.WriteLine((num + 1) + ". " + per[num].corpo);
                            Console.WriteLine(per[num].opcao1);
                            Console.WriteLine(per[num].opcao2);
                            Console.WriteLine(per[num].opcao3);
                            Console.WriteLine(per[num].opcao4);
                            string alt = Console.ReadLine();
                            if (per[num].certo == alt)
                                pontuacao++;
                            num++;
                        }
                        Console.Clear();
                        if (pontuacao >= 2)

                            Console.WriteLine($"Parabéns, você foi aprovado! Pontuação: {pontuacao}");
                        else
                            Console.WriteLine($"Desculpe, você foi reprovado! Pontuação: {pontuacao}");
                        continua = true;
                        Console.WriteLine("\n\nEnter para sair");
                        Console.ReadKey();
                    }
                    catch
                    {
                        msg.ErroCatch(continua);
                    }
                } while (!continua);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Houve um erro, saia e entre novamente.");
            }
        }
    }
}
