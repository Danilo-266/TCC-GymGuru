using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class TreinoService
    {
        public TreinoRepository repository;

        public TreinoService()
        {
            repository = new TreinoRepository();
        }


        public DataTable exibir()
        {
            return repository.getAll();
        }
    }
}
