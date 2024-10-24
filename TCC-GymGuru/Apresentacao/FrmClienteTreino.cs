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
    public partial class FrmClienteTreino : Form
    {
        private String idCliente, idTreino;
        private readonly ClienteService clienteService;
        private DataTable tblClienteTreino = new DataTable();
        private int cliente;
        public FrmClienteTreino(int atual)
        {
            clienteService = new ClienteService();
            InitializeComponent();
            dgPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPesquisa.AllowUserToAddRows = false;
            dgPesquisa.AllowUserToDeleteRows = false;
            dgPesquisa.AllowUserToOrderColumns = false;
            dgPesquisa.ReadOnly = true;
            tblClienteTreino = clienteService.getAllTreino();
            cliente= atual;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClienteTreino_Load(object sender, EventArgs e)
        {
            dgPesquisa.ColumnCount = 2;
            dgPesquisa.AutoGenerateColumns = false;


            dgPesquisa.Columns[0].Width = 120;
            dgPesquisa.Columns[0].HeaderText = "ID CLIENTE";
            dgPesquisa.Columns[0].DataPropertyName = "idCliente";

            dgPesquisa.Columns[1].Width = 120;
            dgPesquisa.Columns[1].HeaderText = "IDTREINO";
            dgPesquisa.Columns[1].DataPropertyName = "idTreino";

           
            dgPesquisa.AllowUserToAddRows = false;
            dgPesquisa.AllowUserToDeleteRows = false;
            dgPesquisa.MultiSelect = false;
            dgPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            rbtCliente.Checked = true;
        }

        public void carregaGridView(int modo)
        {
            if (modo == 0)
            {
                dgPesquisa.DataSource = clienteService.getAllTreino();
                dgPesquisa.Refresh();
            }
            else if (modo == 1) 
            {
                dgPesquisa.DataSource = clienteService.pesquisarTreino(cliente);
                dgPesquisa.Refresh();
                
            }        
        
        }

        private void rbtCliente_CheckedChanged(object sender, EventArgs e)
        {
            carregaGridView(1);
            
        }

        private void rbntTdos_CheckedChanged(object sender, EventArgs e)
        {
            carregaGridView(0);
        }

        private void bntAtribuir_Click(object sender, EventArgs e)
        {
            FrmAtribuirTreino treino = new FrmAtribuirTreino(cliente);
            treino.Show();
            this.Close();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {

            clienteService.deletarTreino(int.Parse(idCliente), int.Parse(idTreino));
            if (rbtCliente.Checked)
            {
                carregaGridView(1);
            }
            else
            {
                carregaGridView(0);
            }
            
        }

        private void dgPesquisa_SelectionChanged(object sender, EventArgs e)
        {
            idCliente = dgPesquisa.CurrentRow.Cells[0].Value.ToString();
            idTreino = dgPesquisa.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
