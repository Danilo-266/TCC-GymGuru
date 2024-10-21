using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class EquipamentoService
    {
        public EquipamentoRepository repository;

        public EquipamentoService()
        {
            repository = new EquipamentoRepository();
        }

        public void Cadastrar(String nome, String descricao, String grupoMuscular)
        {
            repository.Cadastro(nome,descricao,grupoMuscular);
        }

        public DataTable exibir()
        {
            return repository.getAll();
        }

        public void deletar(int id)
        {
            repository.Remove(id);
        }

        public void update(int id, String nome, String descricao, String grupoMuscular)
        {
            repository.Update(id, nome, descricao, grupoMuscular);
        }

        public DataTable pesquisar(String nome)
        {
            return repository.PesquisaNome(nome);
        }

        public DataTable Ocupado(int disp)
        {
            return repository.PesquisaDisponivel(disp);
        }

    }
}
