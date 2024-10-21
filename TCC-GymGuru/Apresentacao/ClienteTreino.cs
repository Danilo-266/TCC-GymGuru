using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class ClienteTreino : Form
    {
        private readonly ClienteService clienteService;
        private DataTable tblClienteTreino = new DataTable();
        public ClienteTreino()
        {
            clienteService = new ClienteService();
            InitializeComponent();
            dgPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPesquisa.AllowUserToAddRows = false;
            dgPesquisa.AllowUserToDeleteRows = false;
            dgPesquisa.AllowUserToOrderColumns = false;
            dgPesquisa.ReadOnly = true;
            tblClienteTreino = clienteService.getAllTreino();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
