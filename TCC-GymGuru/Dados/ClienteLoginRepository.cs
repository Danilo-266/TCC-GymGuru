using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dados
{
    public class ClienteLoginRepository
    {
        public bool Login(string login, string senha)
        {
            // Comando SQL para verificar se o usuário existe

            string query = "SELECT COUNT(*) FROM usuarioLogin WHERE login = @login AND senha = @senha";

            try
                {
                    Connection.getConnection();
                

                using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
                    {
                        // Substitui os parâmetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        // Executa o comando e verifica se encontrou o usuário
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
    }


}

