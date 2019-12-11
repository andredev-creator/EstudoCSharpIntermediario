using AgendaADONET.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaADONET.DAO
{
    public class ContatoDAO
    {
        public DataTable GetContatos() // SÓ QUERO TRAZER INFORMAÇÕES DO BANCO DE DADOS.
        {
            DbConnection conexao = DAOUtils.GetConexao(); // abri a conexao com o bando de dados
            DbCommand comando = DAOUtils.GetComando(conexao); // crie uma classe que vai executar comandos la na base de dados
            comando.CommandType = CommandType.Text;   // tipo de comando que eu vou disparar para esta conexão, no caso tipo textp(ele é um ENUM)
            comando.CommandText = "SELECT * FROM CONTATOS"; // especifiquei qual comando SQL será executado
            DbDataReader reader = DAOUtils.GetDataReader(comando); // e pedi para o método GetDataReader, gerar DataReader a partir de comando;
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;    // teste para consulta usando o DataSet ao invés de serem jogados dentro de um DataReader através do DataTable. 
        }

        public void Excluir(int id)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE FROM CONTATOS WHERE ID = @id";
            //comando.Parameters.Add(new SqlParameter("@id", id));
            comando.Parameters.Add(DAOUtils.GetParameter("@id", id));
            comando.ExecuteNonQuery();
        }

        public void Inserir(Contato contato)
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO CONTATOS (NOME, EMAIL, TELEFONE) VALUES (@NOME, @EMAIL, @TELEFONE)"; // INFO SERAO INSERIDAS NA CLASSE CONTATO SEGUNDO O PARAMENTRO CONTATO.

            comando.Parameters.Add(DAOUtils.GetParameter("@nome", contato.Nome));
            comando.Parameters.Add(DAOUtils.GetParameter("@email", contato.Email));
            comando.Parameters.Add(DAOUtils.GetParameter("@telefone", contato.Telefone));
            comando.ExecuteNonQuery();

        }

        public void Atualizar(Contato contato)
        {
            try
            {
                DbConnection conexao = DAOUtils.GetConexao();
                DbCommand comando = DAOUtils.GetComando(conexao);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "UPDATE CONTATOS SET NOME = @nome, EMAIL = @email, TELEFONE = @telefone WHERE ID = @id";
                comando.Parameters.Add(DAOUtils.GetParameter("@nome", contato.Nome));
                comando.Parameters.Add(DAOUtils.GetParameter("@email", contato.Email));
                comando.Parameters.Add(DAOUtils.GetParameter("@telefone", contato.Telefone));
                comando.Parameters.Add(DAOUtils.GetParameter("@id", contato.Id));
                comando.ExecuteNonQuery(); // QUANDO A QUERY NAO RETORNA NADA

            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao salvar dados" + e.Message);

            }
        }

        public int ContarUsuarios()
        {
            DbConnection conexao = DAOUtils.GetConexao();
            DbCommand comando = DAOUtils.GetComando(conexao);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT COUNT(*) FROM CONTATOS";
            return (int)comando.ExecuteScalar();

        }


    }
}
