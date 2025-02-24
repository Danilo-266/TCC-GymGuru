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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Apresentacao
{
    public partial class FrmTreino : Form
    {
        private readonly TreinoService treinoService;
        private DataTable tblTreino = new DataTable();
        private int modo = 0;
        
        public FrmTreino()
        {
            treinoService = new TreinoService();
            InitializeComponent();
            dgTreino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgTreino.AllowUserToAddRows = false;
            dgTreino.AllowUserToDeleteRows = false;
            dgTreino.AllowUserToOrderColumns = true;
            dgTreino.ReadOnly = true;

            tblTreino = treinoService.exibir();
            

        }

       



        private void Treino_Load(object sender, EventArgs e)
        {
            dgTreino.ColumnCount= 6;
            dgTreino.AutoGenerateColumns= false;

            dgTreino.Columns[0].Width = 60;
            dgTreino.Columns[0].HeaderText = "ID";
            dgTreino.Columns[0].DataPropertyName = "idTreino";

            dgTreino.Columns[1].Width = 300;
            dgTreino.Columns[1].HeaderText = "NOME";
            dgTreino.Columns[1].DataPropertyName = "nome";

            dgTreino.Columns[2].Width = 500;
            dgTreino.Columns[2].HeaderText = "DESCRICÃO";
            dgTreino.Columns[2].DataPropertyName = "descricao";

            dgTreino.Columns[3].Width = 60;
            dgTreino.Columns[3].HeaderText = "SERIES";
            dgTreino.Columns[3].DataPropertyName = "series";

            dgTreino.Columns[4].Width = 250;
            dgTreino.Columns[4].HeaderText = "MUSCULO";
            dgTreino.Columns[4].DataPropertyName = "grupoMuscular";

            dgTreino.Columns[5].Width = 100;
            dgTreino.Columns[5].HeaderText = "EQUIPAMENTO";
            dgTreino.Columns[5].DataPropertyName = "FkAparelho";

            dgTreino.AllowUserToAddRows = false;
            dgTreino.AllowUserToDeleteRows = false;
            dgTreino.MultiSelect = false;
            dgTreino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            carregaGridView();

        }

        private void carregaGridView()
        {
            dgTreino.DataSource = treinoService.exibir();
            dgTreino.Refresh();
        }

        private void imgFuncionario_Click(object sender, EventArgs e)
        {
            FrmFuncionario funcionario = new FrmFuncionario();

            funcionario.Show();

            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmCliente cliente = new FrmCliente();
            cliente.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmTreino treino = new FrmTreino();
            treino.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmEquipamento equipamento = new FrmEquipamento();
            equipamento.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmTelaInicial telaInicial = new FrmTelaInicial();
            telaInicial.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void dgTreino_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null) 
                return;

            txtId.Text = dgTreino.CurrentRow.Cells[0].Value.ToString();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmEdicaoTreino edicao = new FrmEdicaoTreino(int.Parse(txtId.Text));
            edicao.Show();

        }
            

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int.TryParse(txtId.Text, out int id);
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma exclusão?", "Aviso do sistema!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.OK)
            {


                try
                {
                    treinoService.deeletar(id);
                    MessageBox.Show("TREINO DELETADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO DELETAR  TREINO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            carregaGridView();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FrmPesquisa p = new FrmPesquisa(1);
            string txtBusca = "";
            p.ShowDialog();
            txtBusca = p.Texto;
          
            DataTable dtTreino = treinoService.pesquisar(txtBusca);
            if (dtTreino != null)
            {
                dgTreino.DataSource = dtTreino;
                dgTreino.Refresh();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modo = 0;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void imgFuncionario_Click_1(object sender, EventArgs e)
        {
            FrmFuncionario funcionario = new FrmFuncionario();

            funcionario.Show();

            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            FrmCliente cliente = new FrmCliente();
            cliente.Show();
            this.Close();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            FrmTreino treino = new FrmTreino();
            treino.Show();
            this.Close();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            FrmEquipamento equipamento = new FrmEquipamento();
            equipamento.Show();
            this.Close();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            FrmTelaInicial telaInicial = new FrmTelaInicial();
            telaInicial.Show();
            this.Close();
        }
    }
}
