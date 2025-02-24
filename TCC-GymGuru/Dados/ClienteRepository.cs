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
        public void Cadastro(String cpf, string nome, int idade, string email, string genero, int celular, string experiencia, int idEdenreco)
        {

            string query = "INSERT INTO GymGuruCliente (cpf, nome, idade, email, genero, celular, experiencia, idEdenreco) VALUES (@cpf, @nome, @idade, @email, @genero, @celular, @experiencia, @idEdenreco)";
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
                cmd.Parameters.AddWithValue("@idEdenreco", idEdenreco);
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

                selectSql = "SELECT * FROM GymGuruTreinoCliente WHERE idCliente = @pId";
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

        public void CadastroTreino(int IdCliente, int idTreino)
        {

            string query = "INSERT INTO GymGuruTreinoCliente (idCliente, idTreino) VALUES (@idCliente, @idTreino)";
            Connection.getConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@idCliente", IdCliente);
                cmd.Parameters.AddWithValue("@idTreino", idTreino);
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();
        }

        public void RemoveTreino(int idCliente, int idTreino)
        {

            Connection.getConnection();
            string query = "DELETE FROM GymGuruTreinoCliente WHERE idCliente = @idCliente AND idTreino = @idTreino";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@idTreino", idTreino);

                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();

        }

        public DataTable PesquisaClientePorId(int id)
        {
            DataTable DtResultado = new DataTable("cliente");
            string selectSql;

            try
            {
                Connection.getConnection();
                selectSql = "SELECT * FROM GymGuruCliente WHERE idCliente = @idCliente";

                MySqlCommand SqlCmd = new MySqlCommand(selectSql, Connection.SqlCon);
                SqlCmd.Parameters.AddWithValue("@idCliente", id);

                MySqlDataAdapter SqlData = new MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


        //ENDERECO

        public void CadastroEdereco(string cidade ,String rua, string bairro, int numero, string cep, string complemeto)
        {

            string query = "INSERT INTO GymGuruEndereco (cidade, rua, bairro, numero, cep, complemento) VALUES (@cidade, @rua, @bairro, @numero, @cep, @complemento)";
            Connection.getConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@cidade", cidade);
                cmd.Parameters.AddWithValue("@rua", rua);
                cmd.Parameters.AddWithValue("@bairro", bairro);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@cep", cep);
                cmd.Parameters.AddWithValue("@complemento", complemeto);
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();
        }

        public DataTable getAllEndereco()
        {
            DataTable DtResultado = new DataTable("endereco");
            try
            {
                Connection.getConnection();
                String sqlSelect = "select * from GymGuruEndereco";

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

        public void RemoveEdenreco(int idEndereco)
        {

            Connection.getConnection();
            string query = "DELETE FROM GymGuruEndereco WHERE idEndereco = @idEndereco";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@idEndereco", idEndereco);

                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();


        }

        public void UpdateEdenreco(int id,string cidade  ,String rua, string bairro, int numero, string cep, string complemeto)
        {


            Connection.getConnection();
            string query = "UPDATE GymGuruEndereco SET  cidade = @cidade, rua = @rua, bairro = @bairro ,numero = @numero, cep = @cep , complemento = @complemento WHERE idEndereco = @idEndereco ";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@idEndereco", id);
                cmd.Parameters.AddWithValue("@cidade", cidade);
                cmd.Parameters.AddWithValue("@rua", rua);
                cmd.Parameters.AddWithValue("@bairro", bairro);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@cep", cep);
                cmd.Parameters.AddWithValue("@complemento", complemeto);
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();


        }

        public int GetEdenrecoId(string cep, int numero)
        {
            int idEdenreco = 0;
            string query = "SELECT idEndereco FROM GymGuruEndereco WHERE cep = @cep AND numero = @numero";

            Connection.getConnection();

            using (MySqlCommand command = new MySqlCommand(query, Connection.SqlCon))
            {

                command.Parameters.AddWithValue("@cep", cep);
                command.Parameters.AddWithValue("@numero", numero);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    idEdenreco = Convert.ToInt32(result);
                }
            }
            return idEdenreco;
        }

        public DataTable getEnderecoPorId(int id)
        {
            DataTable DtResultado = new DataTable("endereco");
            try
            {
                Connection.getConnection();
                string sqlSelect = "SELECT * FROM GymGuruEndereco WHERE idEndereco = @id";

                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlSelect;
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.Parameters.AddWithValue("@id", id);

                MySqlDataAdapter SqlData = new MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
            }
            return DtResultado;
        }

    }
}

