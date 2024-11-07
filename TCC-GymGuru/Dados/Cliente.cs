using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Cliente
    {
        public String cpf {  get; set; }
        public String nome {  get; set; }
        public int idade {  get; set; }
        public string email {  get; set; }
        public String genero {  get; set; }
        public int celular {  get; set; }
        public String experiencia {  get; set; }
  
        public String cidade { get; set; }
        public String rua { get; set; }
        public String bairro { get; set; }
        public int numero { get; set; }
        public String cep { get; set; }
        public String complemento { get; set; }
        public Cliente() { }

        public Cliente(String cpf, string nome, int idade, string email, string genero, int celular, string experiencia, string cidade, string rua, string bairro, int numero, string cep, string complemento)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.idade = idade;
            this.email = email;
            this.genero = genero;
            this.celular = celular;
            this.experiencia = experiencia;
            this.cidade = cidade;
            this.rua = rua;
            this.bairro = bairro;
            this.numero = numero;
            this.cep = cep;
            this.complemento = complemento;
        }
    }
}
