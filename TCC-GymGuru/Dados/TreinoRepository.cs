using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;

namespace Dados
{
    public class TreinoRepository
    {
        public void Cadastro(string nome, string descrissao, int serie, string grupoMuscular, int idAparelho)
        {

            string query = "INSERT INTO GymGuruTreino (nome, descricao, series, grupoMuscular, FkAparelho) VALUES (@nome, @descricao, @series, @grupoMuscular, @idAparelho)";
            Connection.getConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@descricao", descrissao);
                cmd.Parameters.AddWithValue("@series",  serie);
                cmd.Parameters.AddWithValue("@grupoMuscular", grupoMuscular);
                cmd.Parameters.AddWithValue("@idAparelho", idAparelho);
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();
        }

        public DataTable getAll()
        {
            DataTable DtResultado = new DataTable("treino");
            try
            {
                Connection.getConnection();
                String sqlSelect = "select * from GymGuruTreino";

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
            
            

        public void Update(int id, String nome, String descricao, int series, String grupoMuscular )
        {
           
            
                Connection.getConnection();
                string query = "UPDATE GymGuruTreino SET nome = @nome, descricao = @descricao, series = @series, grupoMuscular = @grupoMuscular WHERE idTreino = @idTreino ";
                using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
                {
                    cmd.Parameters.AddWithValue("@idTreino", id);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@series", series);
                    cmd.Parameters.AddWithValue("@grupoMuscular", grupoMuscular);
                    cmd.ExecuteNonQuery();
                }
                if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();


        }

        public void Remove(int idTreino)
        {

            Connection.getConnection();
            string query = "DELETE FROM GymGuruTreino WHERE idTreino = @idTreino";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@idTreino", idTreino);
                
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();


        }

        public DataTable PesquisaNome(String Nome)
        {
            DataTable DtResultado = new DataTable("fornecedor");
            string selectSql;
            try
            {
                Connection.getConnection();
                if (!string.IsNullOrEmpty(Nome))
                {
                    
                    selectSql = String.Format("SELECT * FROM GymGuruTreino WHERE nome LIKE @pNome");
                    Nome = Nome + '%'; 
                }
                else
                {
                    selectSql = String.Format("SELECT * FROM GymGuruTreino");
                }

                MySqlCommand SqlCmd = new MySqlCommand(selectSql, Connection.SqlCon);

                if (!string.IsNullOrEmpty(Nome))
                    SqlCmd.Parameters.AddWithValue("@pNome", Nome); 

                MySqlDataAdapter SqlData = new MySqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }




        public String GetAparelhoNome(int idAparelho)
        {
            string nomeAparelho = "";
            string query = "SELECT nome FROM GymGuruAparelho WHERE idAparelho = @id";

            Connection.getConnection();

            using (MySqlCommand command = new MySqlCommand(query, Connection.SqlCon))
            {

                command.Parameters.AddWithValue("@id", idAparelho);


                object result = command.ExecuteScalar();

                if (result != null)
                {
                    nomeAparelho = result.ToString();
                }
            }

            return nomeAparelho;


        }

        public int GetAparelhoId(string aparelhoNome)
        {
            int idAparelho = 0;
            string query = "SELECT idAparelho FROM GymGuruAparelho WHERE nome = @nomes";

            Connection.getConnection(); 

            using (MySqlCommand command = new MySqlCommand(query, Connection.SqlCon))
            {

                command.Parameters.AddWithValue("@nomes", aparelhoNome);


                object result = command.ExecuteScalar();
                if (result != null)
                {
                    idAparelho = Convert.ToInt32(result); 
                }


            }

            return idAparelho;


        }
    }
}
