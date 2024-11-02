using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Dados
{
   
        public class ClienteValidator : AbstractValidator<Cliente>
        {
            public ClienteValidator()
            {
                RuleFor(Cliente => Cliente.nome).NotEmpty().WithMessage("Campo NOME não pode ser vazio!");
                RuleFor(Cliente => Cliente.nome).Length(3, 100).WithMessage("Campo NOME deve conter de 3 a 100 caracteres!");

                RuleFor(Cliente => Cliente.email).NotEmpty().WithMessage("Campo EMAIL não pode ser vazio!");
                RuleFor(Cliente => Cliente.email).EmailAddress().WithMessage("Campo EMAIL deve ser válido!");

                RuleFor(Cliente => Cliente.cpf).NotEmpty().WithMessage("Campo CPF não pode ser vazio!");
                RuleFor(cliente => cliente.cpf).Matches(@"^\d+$").WithMessage("O CPF deve conter apenas números.");
                RuleFor(cliente => cliente.cpf).Length(11).WithMessage("Campo CPF deve conter 11 caracteres!");

                RuleFor(Cliente => Cliente.genero).Length(1).WithMessage("Campo GENERO deve conter apenas 1 caracter");
                RuleFor(cliente => cliente.genero).Must(genero => genero == "M" || genero == "F" || genero == "m" || genero == "f").WithMessage("O gênero deve ser 'M' ou 'F'");
                RuleFor(cliente => cliente.genero).NotEmpty().WithMessage("Campo GENERO não pode ser vazio!");

                RuleFor(cliente => cliente.idade).NotEmpty().WithMessage("Campo IDADE não pode ser vazio!");

                RuleFor(cliente => cliente.celular).NotEmpty().WithMessage("Campo IDADE não pode ser vazio!");

                RuleFor(cliente => cliente.experiencia).Length(1,50).WithMessage("Campo EXPERINECIA deve conter de 1 a 50 caracteres!");
            
        }
    }
    
}
