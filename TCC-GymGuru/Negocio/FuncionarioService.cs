using System;
using Dados;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FluentValidation.Results;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace Negocio
{
    public class FuncionarioService
    {
        public FuncionarioRepository repository;
       

        public FuncionarioService()
        {
            repository = new FuncionarioRepository();
        }
        public bool Login(String cpf, String senha)
        {
            return repository.Login(cpf, senha);
        }

      
        public string Cadrastro(string cpf, string nome, string email, string genero, string celular, string senha, string confirmar, string cidade, String rua, string bairro, int numero, string cep, string complemento)
        {
            Funcionario funcionario = new Funcionario(cpf, nome, email, genero, celular, senha, confirmar, cidade, rua, bairro, numero, cep, complemento);
            FuncionarioValidator validator = new FuncionarioValidator();
            ValidationResult results = validator.Validate(funcionario);
            IList<ValidationFailure> failures = results.Errors;
              if (!results.IsValid)
              {
                foreach (ValidationFailure failure in failures)
               {
                    string ERRO = failure.ErrorMessage;
                  return ERRO;
               }
            }
            repository.Cadastro(cpf, nome, email, genero, celular, senha, cadastroEdenreco(cidade, rua, bairro, numero, cep, complemento));
            return "FUNCIONARIO CADASTRADO COM SUCESSO";
        }

        public DataTable pesquisar(String cpf)
        {
            return repository.PesquisaCpf(cpf);
        }
        public int cadastroEdenreco(string cidade, String rua, string bairro, int numero, string cep, string complemeto)
        {
            repository.CadastroEdereco(cidade, rua, bairro, numero, cep, complemeto);
            return (repository.GetEdenrecoId(cep, numero));
        }

        public DataTable exibir()
        {
            return repository.getAll();
        }
    }
}
