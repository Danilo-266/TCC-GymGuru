using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class TreinoService
    {
        public TreinoRepository repository;

        public TreinoService()
        {
            repository = new TreinoRepository();
        }

        public void Cadastrar(String nome, String descricao, int serie, String musculo, int idAparelho)
        {
            repository.Cadastro(nome, descricao, serie, musculo, idAparelho);
        }

        public DataTable exibir()
        {
            return repository.getAll();
        }

        public void deeletar(int id)
        {
            repository.Remove(id);
        }

        public void update(int id,  String nome, String descricao,  int series, String grupoMuscular)
        {
            repository.Update(id, nome,descricao,series,grupoMuscular);
        }

        public DataTable pesquisar(String nome)
        {
           return repository.PesquisaNome(nome);
       }

        public String pesquisaAparelhoNome(int idAp)
        {
            return repository.GetAparelhoNome(idAp);
        }

        public int pesquisarAparelhoID(string nomeId)
        {
            return repository.GetAparelhoId(nomeId);
        }

    }
}
