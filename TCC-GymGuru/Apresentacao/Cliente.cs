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
    public partial class Cliente : Form
    {
        private readonly ClienteService clienteService;
        private DataTable tblCliente = new DataTable();
        private int modo = 0;

        public Cliente()
        {
            clienteService = new ClienteService();
            InitializeComponent();
            dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgCliente.AllowUserToAddRows = false;
            dgCliente.AllowUserToDeleteRows = false;
            dgCliente.AllowUserToOrderColumns = false;
            dgCliente.ReadOnly = true;
            tblCliente = clienteService.exibir();
            Habilita();
        }

        private void Habilita()
        {
            switch (modo)
            {
                case 0://neutro
                    btnAlterar.Enabled = true;
                    btnSalvar.Enabled = false;
                    btnNovo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnExcluir.Enabled = true;
                    btnPesquisa.Enabled = true;
                    txtCelular.Enabled = false;
                    txtCpf.Enabled = false;
                    txtEmail.Enabled = false;
                    txtExperiencia.Enabled = false;
                    txtGenero.Enabled = false;
                    txtIdade.Enabled = false;
                    txtNome.Enabled = false;
                    txtId.Enabled = false;
                    break;
                case 1://Adicionar
                    txtId.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnSalvar.Enabled = true;
                    btnNovo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnExcluir.Enabled = false;
                    btnPesquisa.Enabled = false;
                    txtCelular.Enabled = true;
                    txtCpf.Enabled = true;
                    txtEmail.Enabled = true;
                    txtExperiencia.Enabled = true;
                    txtGenero.Enabled = true;
                    txtIdade.Enabled = true;
                    txtNome.Enabled = true;
                    break;

            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
            txtId.Clear();
            txtCelular.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtExperiencia.Clear();
            txtGenero.Clear();
            txtIdade.Clear();
            txtNome.Clear();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            dgCliente.ColumnCount = 8;
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

            dgCliente.Columns[3].Width = 60;
            dgCliente.Columns[3].HeaderText = "IDADE";
            dgCliente.Columns[3].DataPropertyName = "idade";

            dgCliente.Columns[4].Width = 200;
            dgCliente.Columns[4].HeaderText = "EMAIL";
            dgCliente.Columns[4].DataPropertyName = "email";

            dgCliente.Columns[5].Width = 120;
            dgCliente.Columns[5].HeaderText = "GENERO";
            dgCliente.Columns[5].DataPropertyName = "genero";

            dgCliente.Columns[6].Width = 120;
            dgCliente.Columns[6].HeaderText = "CELULAR";
            dgCliente.Columns[6].DataPropertyName = "celular";

            dgCliente.Columns[7].Width = 170;
            dgCliente.Columns[7].HeaderText = "EXPERIENCIA";
            dgCliente.Columns[7].DataPropertyName = "experiencia";

            dgCliente.AllowUserToAddRows = false;
            dgCliente.AllowUserToDeleteRows = false;
            dgCliente.MultiSelect = false;
            dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            carregaGridView();

        }

        public void carregaGridView()
        {
            dgCliente.DataSource = clienteService.exibir();
            dgCliente.Refresh();
        }

        private void dgCliente_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null)
                return;
            txtId.Text = dgCliente.CurrentRow.Cells[0].Value.ToString();
            txtCpf.Text = dgCliente.CurrentRow.Cells[1].Value.ToString();
            txtNome.Text = dgCliente.CurrentRow.Cells[2].Value.ToString();
            txtIdade.Text = dgCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dgCliente.CurrentRow.Cells[4].Value.ToString();
            txtGenero.Text = dgCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = dgCliente.CurrentRow.Cells[6].Value.ToString();
            txtExperiencia.Text = dgCliente.CurrentRow.Cells[7].Value.ToString();


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            String cpf = txtCpf.Text, nome = txtNome.Text, email = txtEmail.Text,genero = txtGenero.Text, experiencia = txtExperiencia.Text;
            int.TryParse(txtCelular.Text, out int celular);
            int.TryParse(txtIdade.Text, out int idade);
            int.TryParse(txtId.Text, out int id);
            if (txtId.Text == "")
            {
                try
                {
                    clienteService.Cadastrar(cpf, nome, idade,email, genero, celular, experiencia);
                    MessageBox.Show("CLIENTE CADASTRADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    carregaGridView();
                    modo = 0;
                    Habilita();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO CADASTRAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                carregaGridView();
            }
            else
            {

                try
                {
                    clienteService.update(id, cpf, nome, idade, email, genero, celular, experiencia);
                    MessageBox.Show("CLIENTE ATUALIZADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    carregaGridView();
                    modo = 0;
                    Habilita();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO ATUALIZAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
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
                    clienteService.deeletar(id);
                    MessageBox.Show("CLIENTE DELETADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO DELETAR  CLIENTE!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            carregaGridView();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisa p = new Pesquisa(2);
            string txtBusca = "";
            p.ShowDialog();
            txtBusca = p.Texto;

            DataTable dtCliente = clienteService.pesquisar(txtBusca);
            if (dtCliente != null)
            {
                dgCliente.DataSource = dtCliente;
                dgCliente.Refresh();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            modo = 0;
            Habilita();
        }

        private void dgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
    
}
