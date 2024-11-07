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

        public string Cadastrar(String cpf, string nome, int idade, string email, string genero, int celular, string experiencia,string cidade ,String rua, string bairro, int numero, string cep, string complemeto)
        {// mudar validacao
            Cliente cliente = new Cliente(cpf, nome, idade, email, genero, celular, experiencia, cidade, rua, bairro, numero, cep, complemeto);
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
           
                repository.Cadastro(cpf, nome, idade, email, genero.ToUpper(), celular, experiencia, cadastroEdenreco(cidade, rua, bairro, numero, cep, complemeto));
                return "Cliete cadastrado com sucesso";
    
        }
    
        public DataTable exibir()
        {
            return repository.getAll();
        }

        public void deeletar(int id, int idEnd)
        {
            repository.Remove(id);
            repository.RemoveEdenreco(idEnd);


        }

        public string update(int id, String cpf, string nome, int idade, string email, string genero, int celular, string experiencia, string cidade,int idEndereco , String rua, string bairro, int numero, string cep, string complemeto)
        {
            Cliente cliente = new Cliente(cpf, nome, idade, email, genero, celular, experiencia, cidade, rua, bairro, numero, cep, complemeto);
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
            repository.UpdateEdenreco(idEndereco,cidade,rua, bairro, numero, cep, complemeto);
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

        public int cadastroEdenreco(string cidade, String rua, string bairro, int numero, string cep, string complemeto)
        {
            repository.CadastroEdereco(cidade,rua, bairro, numero, cep, complemeto);
            return (repository.GetEdenrecoId(cep, numero));
        }

        public  DataTable getAllEdenreco()
        {
            return repository.getAllEndereco();
        }

        public DataTable getAllEndId(int id)
        {
            return repository.getEnderecoPorId(id);
        }

        
    }
}
