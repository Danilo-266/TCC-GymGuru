using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Dados
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        //string cidade, string rua, string bairro, int numero, string cep, string complemento cpf, nome, email, genero, celular, senha
        public FuncionarioValidator() {
            RuleFor(Funcionario => Funcionario.nome ).NotEmpty().WithMessage("Campo NOME não pode ser vazio!");

            RuleFor(Funcionario => Funcionario.cpf).NotEmpty().WithMessage("Campo CPF não pode ser vazio!");

            RuleFor(Funcionario => Funcionario.email).NotEmpty().WithMessage("Campo EMAIL não pode ser vazio!");

            RuleFor(Funcionario => Funcionario.genero).NotEmpty().WithMessage("Campo GENERO não pode ser vazio!");

            RuleFor(Funcionario => Funcionario.celular).NotEmpty().WithMessage("Campo CELULAR não pode ser vazio!");

            RuleFor(Funcionario => Funcionario.senha).NotEmpty().WithMessage("Campo SENHA não pode ser vazio!");
            
           // RuleFor(Funcionario => Funcionario.comfirmar).NotEmpty().WithMessage("Confirme a senha!");

            RuleFor(Funcionario => Funcionario.cidade).NotEmpty().WithMessage("Campo CIDADE não pode ser vazio!");

            RuleFor(Funcionario => Funcionario.rua).NotEmpty().WithMessage("Campo RUA não pode ser vazio!");

            RuleFor(Funcionario => Funcionario.bairro).NotEmpty().WithMessage("Campo BAIRRO não pode ser vazio!");

            RuleFor(Funcionario => Funcionario.numero).NotEmpty().WithMessage("Campo NUMERO não pode ser vazio!");

            RuleFor(Funcionario => Funcionario.cep).NotEmpty().WithMessage("Campo CEP não pode ser vazio!");

            


        }
    }
}
