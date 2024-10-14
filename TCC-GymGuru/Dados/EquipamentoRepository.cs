using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dados
{
        public class EquipamentoRepository
        {
        public void Cadastro(String nome, String descricao, String musculo)
        {

            string query = "INSERT INTO GymGuruAparelho (nome, descricao, grupoMuscular) VALUES (@nome, @descricao, @grupoMuscular)";
            Connection.getConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@nome",nome );
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@grupoMuscular", musculo);

                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();
        }

        public DataTable getAll()
        {
            DataTable DtResultado = new DataTable("aparelho");
            try
            {
                Connection.getConnection();
                String sqlSelect = "select * from GymGuruAparelho";

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



        public void Update(int id, String nome, String descricao, String musculo)
        {
            Connection.getConnection();
            string query = "UPDATE GymGuruAparelho SET  nome= @nome, descricao = @descricao, grupoMuscular = @grupoMuscular WHERE idAparelho = @idAparelho ";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@idAparelho", id);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@grupoMuscular", musculo);
             
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();


        }

        public void Remove(int idAparelho)
        {

            Connection.getConnection();
            string query = "DELETE FROM GymGuruAparelho WHERE idAparelho = @idAparelho";
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@idAparelho", idAparelho);

                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();


        }

        public DataTable PesquisaNome(String Nome)
        {
            DataTable DtResultado = new DataTable("aparelho");
            string selectSql;
            try
            {
                Connection.getConnection();
                if (!string.IsNullOrEmpty(Nome))
                {
                    selectSql = String.Format("SELECT * FROM GymGuruAparelho WHERE nome LIKE @pNome");
                    Nome = '%' + Nome + '%';
                }
                else
                {
                    selectSql = String.Format("SELECT * FROM GymGuruAparelho");
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
    }
}
