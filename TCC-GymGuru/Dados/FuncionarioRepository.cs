using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dados
{
    public class FuncionarioRepository
    {
        public bool Login(string cpf, string senha)
        {
            

            string query = "SELECT COUNT(*) FROM GymGuruFuncionario WHERE cpf = @cpf AND senha = @senha";

            try
                {
                    Connection.getConnection();
                

                using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
                    {
                       
                        cmd.Parameters.AddWithValue("@cpf", cpf);
                        cmd.Parameters.AddWithValue("@senha", senha);

                       
                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userCount > 0)
                    {
                        return true;
                    }else
                        return false;
                    }
                }
                catch (Exception ex)
                {
      
                    return false;
                }
                finally
                    {
                    if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
                    }
                
        }
    

        public void Cadastro(string cpf,string nome, string email, string genero, string celular, string senha, int end)
        {
        
            string query = "INSERT INTO GymGuruFuncionario (cpf, nome, email, genero, celular, senha, idEndereco) VALUES (@cpf, @nome, @email, @genero, @celular, @senha, @idEndereco)";
            Connection.getConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@celular", celular);
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.Parameters.AddWithValue("@idEndereco", end);
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();
        }

        public DataTable PesquisaCpf(String Cpf)
        {
            DataTable DtResultado = new DataTable("funcionario");
            string selectSql;
            try
            {
                Connection.getConnection();
                if (!string.IsNullOrEmpty(Cpf))
                {
                    selectSql = String.Format("SELECT * FROM GymGuruFuncionario WHERE cpf LIKE @cpf");
                    Cpf = '%' + Cpf + '%';
                }
                else
                {
                    selectSql = String.Format("SELECT * FROM GymGuruFuncionario");
                }
                MySqlCommand SqlCmd = new MySqlCommand(selectSql, Connection.SqlCon);
                if (!string.IsNullOrEmpty(Cpf))
                    SqlCmd.Parameters.AddWithValue("@cpf", Cpf);
                MySqlDataAdapter SqlData = new MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable getAll()
        {
            DataTable DtResultado = new DataTable("funcionario");
            try
            {
                Connection.getConnection();
                String sqlSelect = "select * from GymGuruFuncionario";

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
        //Endereco
        public void CadastroEdereco(string cidade, String rua, string bairro, int numero, string cep, string complemeto)
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

        public void UpdateEdenreco(int id, string cidade, String rua, string bairro, int numero, string cep, string complemeto)
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

