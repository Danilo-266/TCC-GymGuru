﻿using System;
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
    

    public void Cadastro(string cpf,string nome, string email, string genero, string celular, string senha)
    {
        
            string query = "INSERT INTO GymGuruFuncionario (cpf, nome, email, genero, celular, senha) VALUES (@cpf, @nome, @email, @genero, @celular, @senha)";
            Connection.getConnection();
            using (MySqlCommand cmd = new MySqlCommand(query, Connection.SqlCon))
            {
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@celular", celular);
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.ExecuteNonQuery();
            }
            if (Connection.SqlCon.State == ConnectionState.Open)
                Connection.SqlCon.Close();
    }
    }
}
