using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Dados
{
    public class TreinoValidator : AbstractValidator<Treino>
    {
        public TreinoValidator() {
            RuleFor(Treino => Treino.nome).NotEmpty().WithMessage("Campo NOME não pode ser vazio!");
            RuleFor(Treino => Treino.nome).Length(1, 45).WithMessage("Campo NOME deve conter de 1 a 45 caracteres!");

            RuleFor(Treino => Treino.descrissao).NotEmpty().WithMessage("Campo DESCRICÃO não pode ser vazio!");
            RuleFor(Treino => Treino.descrissao).Length(1, 45).WithMessage("Campo DESCRICÃO deve conter de 1 a 45 caracteres!");

            RuleFor(Treino => Treino.grupoMuscular).NotEmpty().WithMessage("Campo GRUPO MUSCULAR não pode ser vazio!");
            RuleFor(Treino => Treino.grupoMuscular).Length(1, 45).WithMessage("Campo GRUPO MUSCULAR deve conter de 1 a 45 caracteres!");
        }
    }
}
