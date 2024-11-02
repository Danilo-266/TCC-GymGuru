using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Dados
{
    public class EquipamentoValidator : AbstractValidator<Equipamento>
    {
        public EquipamentoValidator() {
            RuleFor(Equipamento => Equipamento.nome).NotEmpty().WithMessage("Campo NOME não pode ser vazio!");
            RuleFor(Equipamento => Equipamento.nome).Length(1, 45).WithMessage("Campo NOME deve conter de 1 a 45 caracteres!");

            RuleFor(Equipamento => Equipamento.descricao).NotEmpty().WithMessage("Campo DESCRICÃO não pode ser vazio!");
            RuleFor(Equipamento => Equipamento.descricao).Length(1, 200).WithMessage("Campo DESCRICÃO deve conter até 200 caracteres!");

            RuleFor(Equipamento => Equipamento.musculo).NotEmpty().WithMessage("Campo GRUPO MUSCULAR não pode ser vazio!");
            RuleFor(Equipamento => Equipamento.musculo).Length(1, 45).WithMessage("Campo GRUPO MUSCULAR deve conter de 1 a 45 caracteres!");

        }

    }
}