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

        public Cliente() { }

        public Cliente(String cpf, string nome, int idade, string email, string genero, int celular, string experiencia)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.idade = idade;
            this.email = email;
            this.genero = genero;
            this.celular = celular;
            this.experiencia = experiencia;
        }
    }
}
