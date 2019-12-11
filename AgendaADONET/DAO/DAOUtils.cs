using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaADONET.DAO
{
    public class DAOUtils
    {
        public static DbConnection GetConexao()
        {
            //adicionar referencia SYSTEM.CONFIGURATION pois configuration manager é uma DLL necessaria

            string server = ConfigurationManager.AppSettings["server"].ToString(); //pegou o valor que estiver dentro da tag server dentro do app settings
            string database = ConfigurationManager.AppSettings["database"].ToString();
            string user = ConfigurationManager.AppSettings["user"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();
            DbConnection conexao = null;
            string connectionString = "";
            if (ConfigurationManager.AppSettings["provider"].ToString().Equals("MSSQL"))
            {
                connectionString = @"Server=" + server + ";Database=" + database + ";User Id=" + user + ";Password =" + password + ";";
                conexao = new SqlConnection(connectionString);
            }
            else
            {
                connectionString = @"Server=" + server + ";Database=" + database + ";Uid=" + user + ";Pwd =" + password + ";";
                conexao = new MySqlConnection(connectionString);
            }

            conexao.Open();
            return conexao;

        }


        public static DbCommand GetComando(DbConnection conexao) // precisa saber a partir de qual conexão ele vai ser executado.
        {
            DbCommand comando = conexao.CreateCommand(); // com este objeto posso executar instruções SQL na minha base de dados
            return comando;
        }

        public static DbDataReader GetDataReader(DbCommand comando)
        {
            return comando.ExecuteReader(); // método devolve um DbDataReader com os resultados que o comando contem.
        }

        public static DbParameter GetParameter(string nome, object valor)
        {
            DbParameter parametro = null;
            if (ConfigurationManager.AppSettings["provider"].ToString().Equals("MSSQL"))
            {
                parametro = new SqlParameter(nome, valor);
            }
            else
            {
                parametro = new MySqlParameter(nome, valor);
            }

            return parametro;
        }

    }
}

