using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Treino
    {
        private String nome { get; set; }
        private String descrissao { get; set; }
        private int serie { get; set; }
        private String grupoMuscular { get; set; }
    
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
