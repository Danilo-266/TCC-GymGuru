using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Funcionario
    {
        private string cpf { get; set; }
        private string nome {  get; set; }

        private string email { get; set; }

        private string genero { get; set; }
       
        private string celular { get; set; }

        private string senha  { get; set; }

        public Funcionario()
        {

        }

        public Funcionario(string cpf,string nome, string email, string genero, string celular, string senha)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.email = email;
            this.genero = genero;
            this.celular = celular;
            this.senha = senha;
        }
    }
}
