using System;
using Dados;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        public void Cadrastro(string cpf, string nome, string email, string genero, string celular, string senha)
        {
            
            repository.Cadastro(cpf, nome, email, genero, celular, senha);
        }

        public DataTable pesquisar(String cpf)
        {
            return repository.PesquisaCpf(cpf);
        }

        public DataTable exibir()
        {
            return repository.getAll();
        }
    }
}
