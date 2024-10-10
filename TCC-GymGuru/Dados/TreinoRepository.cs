using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public void Cadastro(string nome, string descrissao, int serie, string grupoMuscular)
        {

            string query = "INSERT INTO GymGuruTreino (nome, descricao, series, grupoMuscular) VALUES (@nome, @descricao, @series, @grupoMuscular)";
            Connection.getConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@descricao", descrissao);
                cmd.Parameters.AddWithValue("@series",  serie);
                cmd.Parameters.AddWithValue("@grupoMuscular", grupoMuscular);
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
            return DtResultado;
        }

        public void Update(String nome, String descricao, int series, String grupoMuscular )
        {
            string resp = "";
            
                Connection.getConnection();
                string query = "UPDATE fornecedor SET nome = @nome, descricao = @descricao, series = @series, grupoMuscular = @grupoMuscular ";
                using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@series", series);
                    cmd.Parameters.AddWithValue("@grupoMuscular", grupoMuscular);
                    cmd.ExecuteNonQuery();
                }
                if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();


        }

    }
}
