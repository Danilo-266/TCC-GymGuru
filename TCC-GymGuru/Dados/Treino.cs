using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Treino
    {
        public String nome { get; set; }
        public String descrissao { get; set; }
        public int serie { get; set; }
        public String grupoMuscular { get; set; }
    
        public Treino() { }

        public Treino(string nome, string descrissao, int serie, string grupoMuscular)
        {
            this.nome = nome;
            this.descrissao = descrissao;
            this.serie = serie;
            this.grupoMuscular = grupoMuscular;
        }
    }
}
