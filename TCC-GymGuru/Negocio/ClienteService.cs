using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class ClienteService
    {
        public ClienteRepository repository;
        public ClienteService()
        {
            repository = new ClienteRepository();
        }

        public void Cadastrar(String cpf, string nome, int idade, string email, string genero, int celular, string experiencia)
        {
            repository.Cadastro(cpf, nome, idade, email, genero, celular, experiencia);
        }

        public DataTable exibir()
        {
            return repository.getAll();
        }

        public void deeletar(int id)
        {
            repository.Remove(id);
        }

        public void update(int id, String cpf, string nome, int idade, string email, string genero, int celular, string experiencia)
        {
            repository.Update(id, cpf, nome, idade, email, genero, celular, experiencia);
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
