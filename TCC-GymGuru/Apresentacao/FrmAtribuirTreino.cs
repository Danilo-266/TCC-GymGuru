using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Apresentacao
{
   
    public partial class FrmAtribuirTreino : Form
    {
        int id;
        private readonly ClienteService clienteService;
        private DataTable tblCliente = new DataTable();
        private readonly TreinoService treinoService;
        private DataTable tblTreino = new DataTable();
        String idCliente, idTreino;
        public FrmAtribuirTreino(int cliente)
        {
            id = cliente;
            dgCliente = new DataGridView();
            dgTreino = new DataGridView();
            clienteService = new ClienteService();
            treinoService = new TreinoService();
            dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgCliente.AllowUserToAddRows = false;
            dgCliente.AllowUserToDeleteRows = false;
            dgCliente.AllowUserToOrderColumns = false;
            dgCliente.ReadOnly = true;
            dgTreino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgTreino.AllowUserToAddRows = false;
            dgTreino.AllowUserToDeleteRows = false;
            dgTreino.AllowUserToOrderColumns = false;
            dgTreino.ReadOnly = true;
            tblTreino = treinoService.exibir();
            tblCliente = clienteService.exibir();
        
            InitializeComponent();
        }

        private void lbPedido_Click(object sender, EventArgs e)
        {

        }

        private void dgCliente_SelectionChanged(object sender, EventArgs e)
        {
           idCliente= dgCliente.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            idTreino = dgTreino.CurrentRow.Cells[0].Value.ToString();
        }

        private void FrmAtribuirTreino_Load(object sender, EventArgs e)
        {
            dgCliente.ColumnCount = 3;
            dgCliente.AutoGenerateColumns = false;


            dgCliente.Columns[0].Width = 60;
            dgCliente.Columns[0].HeaderText = "ID";
            dgCliente.Columns[0].DataPropertyName = "idCliente";

            dgCliente.Columns[1].Width = 120;
            dgCliente.Columns[1].HeaderText = "CPF";
            dgCliente.Columns[1].DataPropertyName = "cpf";

            dgCliente.Columns[2].Width = 200;
            dgCliente.Columns[2].HeaderText = "NOME";
            dgCliente.Columns[2].DataPropertyName = "nome";

            dgCliente.AllowUserToAddRows = false;
            dgCliente.AllowUserToDeleteRows = false;
         
            dgCliente.MultiSelect = false;
            dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgTreino.ColumnCount = 3;
            dgTreino.AutoGenerateColumns = false;

            dgTreino.Columns[0].Width = 60;
            dgTreino.Columns[0].HeaderText = "ID";
            dgTreino.Columns[0].DataPropertyName = "idTreino";

            dgTreino.Columns[1].Width = 175;
            dgTreino.Columns[1].HeaderText = "NOME";
            dgTreino.Columns[1].DataPropertyName = "nome";

            dgTreino.Columns[2].Width = 150;
            dgTreino.Columns[2].HeaderText = "MUSCULO";
            dgTreino.Columns[2].DataPropertyName = "grupoMuscular";

            dgTreino.AllowUserToAddRows = false;
            dgTreino.AllowUserToDeleteRows = false;
            dgTreino.MultiSelect = false;
            dgCliente.ReadOnly = true;
            dgTreino.ReadOnly = true;
            dgTreino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            carregaGridView();
        }
        public void carregaGridView()
        {

            dgCliente.DataSource = clienteService.exibir();
            dgCliente.Refresh();
            dgTreino.DataSource = treinoService.exibir();
            dgTreino.Refresh();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmClienteTreino anterior = new FrmClienteTreino(id);
            anterior.Show();
            this.Close();
        }

        private void btnTreino_Click(object sender, EventArgs e)
        {
            var cliente = Application.OpenForms.OfType<FrmCliente>().FirstOrDefault();
            if (cliente != null)
            {
                cliente.Close(); 
            }
            FrmTreino treino = new FrmTreino();
            treino.Show();
            this.Close();
        }

        private void btnAtribuir_Click(object sender, EventArgs e)
        {
            clienteService.cadastroTreino(int.Parse(idCliente), int.Parse(idTreino));
            FrmClienteTreino anterior = new FrmClienteTreino(int.Parse(idCliente));
            anterior.Show();
            this.Close();
        }
    }
    }
