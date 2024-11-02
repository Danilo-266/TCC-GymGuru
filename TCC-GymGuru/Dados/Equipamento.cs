using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Equipamento
    {
        public String nome {  get; set; }
        public String descricao { get; set; }
        public String musculo { get; set; }

        public int usabilidade {  get; set; }

        public Equipamento() { }

        public Equipamento(string nome, string descricao, string musculo)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.musculo = musculo;
           
        }
    }
}
