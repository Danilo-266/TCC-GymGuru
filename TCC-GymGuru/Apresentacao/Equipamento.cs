using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Apresentacao
{
    public partial class Equipamento : Form
    {
        private readonly EquipamentoService equipamentoService;
        private DataTable tblEquipamento = new DataTable();
        private int modo = 0;
        public Equipamento()
        {
            equipamentoService = new EquipamentoService();
            InitializeComponent();
            dgEquipamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgEquipamento.AllowUserToAddRows = false;
            dgEquipamento.AllowUserToDeleteRows = false;
            dgEquipamento.AllowUserToOrderColumns = false;
            dgEquipamento.ReadOnly = true;
            tblEquipamento = equipamentoService.exibir();
            Habilita();
        }

        private void Habilita()
        {
            switch (modo)
            {
                case 0://neutro
                    btnAlterar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnExcluir.Enabled = true;
                    btnNovo.Enabled = true;
                    btnPesquisa.Enabled = true;
                    btnSalvar.Enabled = false;
                    txtDesc.Enabled = false;
                    txtMusculo.Enabled = false;
                    txtNome.Enabled = false;
                    txtId.Enabled = false;
                    break;
                case 1://Adicionar
                    btnAlterar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnExcluir.Enabled = false;
                    btnNovo.Enabled = false;
                    btnPesquisa.Enabled = false;
                    btnSalvar.Enabled = true;
                    txtId.Enabled = false;
                    txtDesc.Enabled = true;
                    txtMusculo.Enabled = true;
                    txtNome.Enabled = true;
                    break;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void imgFuncionario_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();

            funcionario.Show();

            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Treino treino = new Treino();
            treino.Show();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Relatorio relatorio = new Relatorio();
            relatorio.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TelaInicial telaInicial = new TelaInicial();
            telaInicial.Show();
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
            txtDesc.Clear();
            txtMusculo.Clear();
            txtNome.Clear();
            txtId.Clear();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
        }

        private void Equipamento_Load(object sender, EventArgs e)
        {
            dgEquipamento.ColumnCount = 4;
            dgEquipamento.AutoGenerateColumns = false;

            dgEquipamento.Columns[0].Width = 60;
            dgEquipamento.Columns[0].HeaderText = "ID";
            dgEquipamento.Columns[0].DataPropertyName = "idAparelho";

            dgEquipamento.Columns[1].Width = 120;
            dgEquipamento.Columns[1].HeaderText = "NOME";
            dgEquipamento.Columns[1].DataPropertyName = "nome";

            dgEquipamento.Columns[2].Width = 250;
            dgEquipamento.Columns[2].HeaderText = "DESCRICAO";
            dgEquipamento.Columns[2].DataPropertyName = "descricao";

            dgEquipamento.Columns[3].Width = 120;
            dgEquipamento.Columns[3].HeaderText = "GRUPO MUSCULAR";
            dgEquipamento.Columns[3].DataPropertyName = "grupoMuscular";

            dgEquipamento.AllowUserToAddRows = false;
            dgEquipamento.AllowUserToDeleteRows = false;
            dgEquipamento.MultiSelect = false;
            dgEquipamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            carregaGridView();
        }

        public void carregaGridView()
        {
            dgEquipamento.DataSource = equipamentoService.exibir();
            dgEquipamento.Refresh();
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
                    equipamentoService.deletar(id);
                    MessageBox.Show("EQUIPAMENTO DELETADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO DELETAR EQUIPAMENTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            carregaGridView();

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisa p = new Pesquisa(3);
            string txtBusca = "";
            p.ShowDialog();
            txtBusca = p.Texto;

            DataTable dtTreino = equipamentoService.pesquisar(txtBusca);
            if (dtTreino != null)
            {
                dgEquipamento.DataSource = dtTreino;
                dgEquipamento.Refresh();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modo = 0;
            Habilita();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text, descricao = txtDesc.Text, musculo = txtMusculo.Text;
            int.TryParse(txtId.Text, out int id);
            if (txtId.Text == "")
            {
                try
                {
                    equipamentoService.Cadastrar(nome, descricao, musculo);
                    MessageBox.Show("EQUIPAMENTO CADASTRADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO CADASTRAR EQUIPAMENTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                carregaGridView();
                modo = 0;
                Habilita();
            }
            else
            {

                try
                {
                    equipamentoService.update(id, nome, descricao, musculo);
                    MessageBox.Show("EQUIPAMENTO ATUALIZADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO ATUALIZAR EQUIPAMENTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                carregaGridView();
                modo = 0;
                Habilita();
            }
        }

        private void dgEquipamento_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null)
                return;
            txtId.Text = dgEquipamento.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgEquipamento.CurrentRow.Cells[1].Value.ToString();
            txtDesc.Text = dgEquipamento.CurrentRow.Cells[2].Value.ToString();
           txtMusculo.Text = dgEquipamento.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
