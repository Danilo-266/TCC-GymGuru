using System;
using Dados;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteLoginService
    {
        public ClienteLoginRepository repository;

        public ClienteLoginService()
        {
            repository = new ClienteLoginRepository();
        }

        public bool Login(String login, String senha)
        {
            return repository.Login(login, senha);

        }


    }
}
