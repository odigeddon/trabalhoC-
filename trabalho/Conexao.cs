using System;
using MySql.Data.MySqlClient;

namespace BestBurger
{
    public class Conexao
    {
        public MySqlConnection conectarBD()
        {
            MySqlConnection conn;

            string dadosConexao =
                "Persist Security Info=false;" +
                "server=localhost;" +
                "database=BBD;" +
                "uid=root;" +
                "pwd=1234;";

            try
            {
                conn = new MySqlConnection(dadosConexao);
                conn.Open();

                return conn;
            }
            catch (MySqlException ex)
            {
                throw new Exception(
                    "Conexão não estabelecida: " + ex.Message
                );
            }
        }
    }
}