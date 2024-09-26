using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ClienteLogin
    {
        private string login { get; set; }

        private string senha  { get; set; }

        public ClienteLogin()
        {

        }

        public ClienteLogin(string login, string senha)
        {
            this.login = login;
            this.senha = senha;
        }
    }
}
