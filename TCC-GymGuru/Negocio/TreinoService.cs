using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using FluentValidation.Results;

namespace Negocio
{
    public class TreinoService
    {
        public TreinoRepository repository;

        public TreinoService()
        {
            repository = new TreinoRepository();
        }

        public String Cadastrar(String nome, String descricao, int serie, String musculo, int idAparelho)
        {
            Treino treino = new Treino(nome, descricao, serie, musculo);
            TreinoValidator validator = new TreinoValidator();
            ValidationResult results = validator.Validate(treino);
            IList<ValidationFailure> failures = results.Errors;
            if (!results.IsValid)
            {
                foreach (ValidationFailure failure in failures)
                {
                    string ERRO = failure.ErrorMessage;
                    return ERRO;
                }
            }
            repository.Cadastro(nome, descricao, serie, musculo, idAparelho);
            return "TREINO CADASTRADO COM SUCESSO!";
        }

        public DataTable exibir()
        {
            return repository.getAll();
        }

        public void deeletar(int id)
        {
            repository.Remove(id);
        }

        public String update(int id,  String nome, String descricao,  int series, String grupoMuscular)
        {
            Treino treino = new Treino(nome, descricao, series, grupoMuscular);
            TreinoValidator validator = new TreinoValidator();
            ValidationResult results = validator.Validate(treino);
            IList<ValidationFailure> failures = results.Errors;
            if (!results.IsValid)
            {
                foreach (ValidationFailure failure in failures)
                {
                    string ERRO = failure.ErrorMessage;
                    return ERRO;
                }
            }
            repository.Update(id, nome,descricao,series,grupoMuscular);
            return "TREINO ATUALIZADO COM SUCESSO!";
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
