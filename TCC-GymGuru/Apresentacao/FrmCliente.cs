using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;

namespace Apresentacao
{
    public partial class FrmCliente : Form
    {
        private readonly ClienteService clienteService;
        private DataTable tblCliente = new DataTable();
        private DataTable tblEndereco = new DataTable();
        private int modo = 0;
        private string end = "";
        public FrmCliente()
        {
            clienteService = new ClienteService();
            InitializeComponent();
            dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgCliente.AllowUserToAddRows = false;
            dgCliente.AllowUserToDeleteRows = false;
            dgCliente.AllowUserToOrderColumns = false;
            dgCliente.ReadOnly = true;
    
            tblCliente = clienteService.exibir();
            tblEndereco = clienteService.getAllEdenreco();
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
                   
                    break;
                case 1://Adicionar
                    txtId.Enabled = false;
                    btnAlterar.Enabled = false;
                    btnSalvar.Enabled = true;
                    btnNovo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnExcluir.Enabled = false;
                    btnPesquisa.Enabled = false;
                   

                    break;


            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmEdicaoCliente edicao = new FrmEdicaoCliente(0, 0,int.Parse(txtId.Text));
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
           
            dgCliente.AllowUserToAddRows = false;
            dgCliente.AllowUserToDeleteRows = false;
            dgCliente.MultiSelect = false;
            dgCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgCliente.ColumnCount = 9;
            dgCliente.AutoGenerateColumns = false;
            rbtClietes.Checked = true;

        }

        public void carregaGridView(int modo)
        {
            dgCliente.Columns.Clear(); 

            try
            {
                if (modo == 0) 
                {
                    
                    dgCliente.Columns.Add("ID", "ID");
                    dgCliente.Columns.Add("CPF", "CPF");
                    dgCliente.Columns.Add("NOME", "NOME");
                    dgCliente.Columns.Add("IDADE", "IDADE");
                    dgCliente.Columns.Add("EMAIL", "EMAIL");
                    dgCliente.Columns.Add("GENERO", "GENERO");
                    dgCliente.Columns.Add("CELULAR", "CELULAR");
                    dgCliente.Columns.Add("EXPERIENCIA", "EXPERIENCIA");
                    dgCliente.Columns.Add("ENDERECO", "ENDERECO");


                    dgCliente.Columns[0].DataPropertyName = "idCliente";
                    dgCliente.Columns[1].DataPropertyName = "cpf";
                    dgCliente.Columns[2].DataPropertyName = "nome";
                    dgCliente.Columns[3].DataPropertyName = "idade";
                    dgCliente.Columns[4].DataPropertyName = "email";
                    dgCliente.Columns[5].DataPropertyName = "genero";
                    dgCliente.Columns[6].DataPropertyName = "celular";
                    dgCliente.Columns[7].DataPropertyName = "experiencia";
                    dgCliente.Columns[8].DataPropertyName = "idEdenreco";


                    dgCliente.DataSource = clienteService.exibir();
                }
                else if (modo == 1) 
                {
                    
                    dgCliente.Columns.Add("ID", "ID");
                    dgCliente.Columns.Add("CIDADE", "CIDADE");
                    dgCliente.Columns.Add("RUA", "RUA");
                    dgCliente.Columns.Add("BAIRRO", "BAIRRO");
                    dgCliente.Columns.Add("NUMERO", "NUMERO");
                    dgCliente.Columns.Add("CEP", "CEP");
                    dgCliente.Columns.Add("COMPLEMENTO", "COMPLEMENTO");

                   
                    dgCliente.Columns[0].DataPropertyName = "idEndereco";
                    dgCliente.Columns[1].DataPropertyName = "cidade";
                    dgCliente.Columns[2].DataPropertyName = "rua";
                    dgCliente.Columns[3].DataPropertyName = "bairro";
                    dgCliente.Columns[4].DataPropertyName = "numero";
                    dgCliente.Columns[5].DataPropertyName = "cep";
                    dgCliente.Columns[6].DataPropertyName = "complemento";

                 
                    dgCliente.DataSource = clienteService.getAllEdenreco();
                }

                
                dgCliente.Refresh();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Erro ao configurar colunas: " + ex.Message, "Erro de Configuração", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void dgCliente_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dgCliente.CurrentRow == null || dgCliente.CurrentRow.Index < 0)
                return;

            
            if (dgCliente.Columns.Count < 9)
                return;

            try
            {
                txtId.Clear();
                txtId.Text = dgCliente.CurrentRow.Cells[0]?.Value?.ToString() ?? string.Empty;
                end = dgCliente.CurrentRow.Cells[8]?.Value?.ToString() ?? string.Empty;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Erro ao acessar os dados da linha selecionada: " + ex.Message, "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            FrmEdicaoCliente edicao = new FrmEdicaoCliente(0, 0, int.Parse(txtId.Text));
            modo = 1;
            Habilita();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int.TryParse(txtId.Text, out int id);
            int.TryParse(end, out int idEnd);
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma exclusão?", "Aviso do sistema!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.OK)
            {


                try
                {
                    clienteService.deeletar(id,idEnd);
                    MessageBox.Show("CLIENTE DELETADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO DELETAR  CLIENTE!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            carregaGridView(0);
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            FrmPesquisa p = new FrmPesquisa(2);
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
            carregaGridView(0);
        }

        private void dgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTreino_Click(object sender, EventArgs e)
        {
            int.TryParse(txtId.Text, out int id);
            FrmClienteTreino cliTreino = new FrmClienteTreino(id);
            cliTreino.Show();
        }

        private void rbtnDisp_CheckedChanged(object sender, EventArgs e)
        {
            carregaGridView(1);
            txtId.Clear();


        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void rbtClietes_CheckedChanged(object sender, EventArgs e)
        {

            carregaGridView(0);

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
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
            FrmTelaInicial tela = new FrmTelaInicial();

            tela.Show();
            this.Hide();
        }
    }
    }
    
    

