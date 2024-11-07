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
        public String cpf { get; set; }
        public String nome {  get; set; }

        public String email { get; set; }

        public String genero { get; set; }

        public String celular { get; set; }

        public String senha  { get; set; }
        public String comfirmar { get; set; }
        public String cidade { get; set; }
        public String rua { get; set; }
        public String bairro { get; set; }
        public int numero { get; set; }
        public String cep { get; set; }
        public String complemento { get; set; }

        public Funcionario()
        {

        }

        public Funcionario(string cpf,string nome, string email, string genero, string celular, string senha,string confirmar , string cidade, string rua, string bairro, int numero, string cep, string complemento)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.email = email;
            this.genero = genero;
            this.celular = celular;
            this.senha = senha;
            this.comfirmar = comfirmar;
            this.cidade = cidade;
            this.rua = rua;
            this.bairro = bairro;
            this.numero = numero;
            this.cep = cep;
            this.complemento = complemento;
        }
    }
}
