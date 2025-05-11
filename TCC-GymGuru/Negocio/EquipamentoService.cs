using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using FluentValidation;
using FluentValidation.Results;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class EquipamentoService
    {
        public EquipamentoRepository repository;

        public EquipamentoService()
        {
            repository = new EquipamentoRepository();
        }

        public String Cadastrar(String nome, String descricao, String grupoMuscular)
        {
            Equipamento equip = new Equipamento(0,nome,descricao,grupoMuscular, 0);
            EquipamentoValidator validator = new EquipamentoValidator();
            ValidationResult results = validator.Validate(equip);
            IList<ValidationFailure> failures = results.Errors;
            if (!results.IsValid)
            {
                foreach (ValidationFailure failure in failures)
                {
                    string ERRO = failure.ErrorMessage;
                    return ERRO;
                }
            }
            repository.Cadastro(nome,descricao,grupoMuscular);
            return "EQUIPAMENTO CADASTRADO COM SUCESSO!";
        }

        public DataTable exibir()
        {
            return repository.getAll();
        }

        public void deletar(int id)
        {
            repository.Remove(id);
        }

        public String update(int id, String nome, String descricao, String grupoMuscular)
        {
            Equipamento equip = new Equipamento(0, nome, descricao, grupoMuscular, 0);
            EquipamentoValidator validator = new EquipamentoValidator();
            ValidationResult results = validator.Validate(equip);
            IList<ValidationFailure> failures = results.Errors;
            if (!results.IsValid)
            {
                foreach (ValidationFailure failure in failures)
                {
                    string ERRO = failure.ErrorMessage;
                    return ERRO;
                }
            }
            repository.Update(id, nome, descricao, grupoMuscular);
            return "EQUIPAMENTO ATUALIZADO COM SUCESSO!";
        }

        public DataTable pesquisar(String nome)
        {
            return repository.PesquisaNome(nome);
        }

        public DataTable Ocupado(int disp)
        {
            return repository.PesquisaDisponivel(disp);
        }

        public DataTable PesquisaPorId(int id)
        {
            return repository.PesquisaEquipamentoPorId(id);
        }

        public List<Equipamento> listaEquipamento()
        {
            return repository.listagemEquipamento();
        }


    }
}
