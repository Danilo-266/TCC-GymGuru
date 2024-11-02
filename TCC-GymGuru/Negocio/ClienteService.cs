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
    public class ClienteService
    {
        public ClienteRepository repository;
        public ClienteService()
        {
            repository = new ClienteRepository();
        }

        public string Cadastrar(String cpf, string nome, int idade, string email, string genero, int celular, string experiencia)
        {
            Cliente cliente = new Cliente(cpf, nome, idade, email, genero, celular, experiencia);
            ClienteValidator validator = new ClienteValidator();
            ValidationResult results = validator.Validate(cliente);
            IList<ValidationFailure> failures = results.Errors;
            if (!results.IsValid)
            {
                foreach (ValidationFailure failure in failures)
                {
                    string ERRO = failure.ErrorMessage;
                    return ERRO;
                }
            }
           
                repository.Cadastro(cpf, nome, idade, email, genero.ToUpper(), celular, experiencia);
                return "Cliete cadastrado com sucesso";
    
        }
    
        public DataTable exibir()
        {
            return repository.getAll();
        }

        public void deeletar(int id)
        {
            repository.Remove(id);
        }

        public string update(int id, String cpf, string nome, int idade, string email, string genero, int celular, string experiencia)
        {
            Cliente cliente = new Cliente(cpf, nome, idade, email, genero, celular, experiencia);
            ClienteValidator validator = new ClienteValidator();
            ValidationResult results = validator.Validate(cliente);
            IList<ValidationFailure> failures = results.Errors;
            if (!results.IsValid)
            {
                foreach (ValidationFailure failure in failures)
                {
                    string ERRO = failure.ErrorMessage;
                    return ERRO;
                }
            }
            repository.Update(id, cpf, nome, idade, email, genero.ToUpper(), celular, experiencia);
            return "CLIENTE ATUALIZADO COM SUCESSO!";
        }

        public DataTable pesquisar(String nome)
        {
            return repository.PesquisaNome(nome);
        }
        
        public DataTable getAllTreino()
        {
            return repository.getAllTreino();
        }

        public DataTable pesquisarTreino(int id)
        {
            return repository.PesquisaTreino(id);
        }

        public void cadastroTreino(int cliente, int treino)
        {
          repository.CadastroTreino(cliente, treino);
        }

        public void deletarTreino(int id,int treino)
        {
            repository.RemoveTreino(id, treino);
        }
    }
}
