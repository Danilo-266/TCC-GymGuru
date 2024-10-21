using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dados
{
    public class ClienteRepository
    {
        public void Cadastro(String cpf, string nome, int idade, string email, string genero, int celular, string experiencia)
        {

            string query = "INSERT INTO GymGuruCliente (cpf, nome, idade, email, genero, celular, experiencia) VALUES (@cpf, @nome, @idade, @email, @genero, @celular, @experiencia)";
            Connection.getConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@idade", idade);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@celular", celular);
                cmd.Parameters.AddWithValue("@experiencia", experiencia);
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();
        }

        public DataTable getAll()
        {
            DataTable DtResultado = new DataTable("cliente");
            try
            {
                Connection.getConnection();
                String sqlSelect = "select * from GymGuruCliente";

                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlSelect;
                SqlCmd.CommandType = CommandType.Text;
                MySqlDataAdapter SqlData = new MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();
            return DtResultado;
        }



        public void Update(int id, String cpf, string nome, int idade, string email, string genero, int celular, string experiencia)
        {


            Connection.getConnection();
            string query = "UPDATE GymGuruCliente SET  cpf = @cpf, nome = @nome, idade = @idade ,email = @email, genero = @genero , celular = @celular, experiencia = @experiencia WHERE idCliente = @idCliente ";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@idCliente", id);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@idade", idade);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@celular", celular);
                cmd.Parameters.AddWithValue("@experiencia", experiencia);
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();


        }

        public void Remove(int idCliente)
        {

            Connection.getConnection();
            string query = "DELETE FROM GymGuruCliente WHERE idCliente = @idCliente";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();


        }

        public DataTable PesquisaNome(String Nome)
        {
            DataTable DtResultado = new DataTable("cliente");
            string selectSql;
            try
            {
                Connection.getConnection();
                if (!string.IsNullOrEmpty(Nome))
                {
                    selectSql = String.Format("SELECT * FROM GymGuruCliente WHERE nome LIKE @pNome");
                    Nome = '%' + Nome + '%';
                }
                else
                {
                    selectSql = String.Format("SELECT * FROM GymGuruCliente");
                }
                MySqlCommand SqlCmd = new MySqlCommand(selectSql, Connection.SqlCon);
                if (!string.IsNullOrEmpty(Nome))
                    SqlCmd.Parameters.AddWithValue("pNome", Nome);
                MySqlDataAdapter SqlData = new MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable PesquisaTreino(int id)
        {
            DataTable DtResultado = new DataTable("clienteTreino");
            string selectSql;
            try
            {
                Connection.getConnection();

                selectSql = String.Format("SELECT * FROM GymGuruTreinoCliente WHERE idCliente LIKE @pId");
                id = '%' + id + '%';
                MySqlCommand SqlCmd = new MySqlCommand(selectSql, Connection.SqlCon);
                SqlCmd.Parameters.AddWithValue("pId", id);
                MySqlDataAdapter SqlData = new MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }

        public DataTable getAllTreino()
        {
            DataTable DtResultado = new DataTable("clienteTreino");
            try
            {
                Connection.getConnection();
                String sqlSelect = "select * from GymGuruTreinoCliente";

                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlSelect;
                SqlCmd.CommandType = CommandType.Text;
                MySqlDataAdapter SqlData = new MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();
            return DtResultado;
        }
    }
}

