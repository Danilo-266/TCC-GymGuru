using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
                    txtCelular.Enabled = false;
                    txtCpf.Enabled = false;
                    txtEmail.Enabled = false;
                    txtExperiencia.Enabled = false;
                    txtGenero.Enabled = false;
                    txtIdade.Enabled = false;
                    txtNome.Enabled = false;
                    txtId.Enabled = false;
                    txtCidade.Enabled = false;
                    txtRua.Enabled = false;
                    txtBairro.Enabled = false;
                    txtNumero.Enabled = false;
                    txtCEP.Enabled = false;
                    txtComplemeto.Enabled = false;
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
                    txtCidade.Enabled = true;
                    txtRua.Enabled = true;
                    txtBairro.Enabled = true;
                    txtNumero.Enabled = true;
                    txtCEP.Enabled = true;
                    txtComplemeto.Enabled = true;

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
            txtCidade.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtNumero.Clear();
            txtCEP.Clear();
            txtComplemeto.Clear();
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
                txtCelular.Clear();
                txtCpf.Clear();
                txtEmail.Clear();
                txtExperiencia.Clear();
                txtGenero.Clear();
                txtIdade.Clear();
                txtNome.Clear();
                txtCidade.Clear();
                txtRua.Clear();
                txtBairro.Clear();
                txtNumero.Clear();
                txtCEP.Clear();
                txtComplemeto.Clear();  
                txtId.Text = dgCliente.CurrentRow.Cells[0]?.Value?.ToString() ?? string.Empty;
                txtCpf.Text = dgCliente.CurrentRow.Cells[1]?.Value?.ToString() ?? string.Empty;
                txtNome.Text = dgCliente.CurrentRow.Cells[2]?.Value?.ToString() ?? string.Empty;
                txtIdade.Text = dgCliente.CurrentRow.Cells[3]?.Value?.ToString() ?? string.Empty;
                txtEmail.Text = dgCliente.CurrentRow.Cells[4]?.Value?.ToString() ?? string.Empty;
                txtGenero.Text = dgCliente.CurrentRow.Cells[5]?.Value?.ToString() ?? string.Empty;
                txtCelular.Text = dgCliente.CurrentRow.Cells[6]?.Value?.ToString() ?? string.Empty;
                txtExperiencia.Text = dgCliente.CurrentRow.Cells[7]?.Value?.ToString() ?? string.Empty;
                
                 end = dgCliente.CurrentRow.Cells[8]?.Value?.ToString() ?? string.Empty;
                int.TryParse(end, out int val);
                DataTable edenreco = clienteService.getAllEndId(val);
                if (edenreco.Rows.Count > 0)
                {
                    DataRow row = edenreco.Rows[0];
                    txtCidade.Text = row["cidade"].ToString();
                    txtRua.Text = row["rua"].ToString();
                    txtBairro.Text = row["bairro"].ToString();
                    txtNumero.Text = row["numero"].ToString();
                    txtCEP.Text = row["cep"].ToString();
                    txtComplemeto.Text = row["complemento"].ToString();
                }
              
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Erro ao acessar os dados da linha selecionada: " + ex.Message, "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //idEndereco, rua, bairro, numero, cep, complemento
            String cpf = txtCpf.Text, nome = txtNome.Text, email = txtEmail.Text, genero = txtGenero.Text, experiencia = txtExperiencia.Text;
            string rua = txtRua.Text, bairro =txtBairro.Text, cep =txtCEP.Text, complemento = txtComplemeto.Text, cidade = txtCidade.Text;
            int.TryParse(txtCelular.Text, out int celular);
            int.TryParse(txtNumero.Text, out int numero);
            int.TryParse(txtIdade.Text, out int idade);
            int.TryParse(txtId.Text, out int id);
            if (txtId.Text == "")
            {
                try
                {
                    string resultados = clienteService.Cadastrar(cpf, nome, idade, email, genero, celular, experiencia, cidade,rua,bairro, numero,cep,complemento);
                    if (resultados == "Cliete cadastrado com sucesso") {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        carregaGridView(0);
                        modo = 0;
                        Habilita();
                    }
                    else
                    {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        txtId.Clear();
                    }

                }
            
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO CADASTRAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtId.Clear();
                }

             
            }
            else
            {

                try
                {
                    int.TryParse(end, out int idEnd);
                    string resultados = clienteService.update(id, cpf, nome, idade, email, genero, celular, experiencia, cidade, idEnd, rua, bairro, numero, cep, complemento);
                    if (resultados == "CLIENTE ATUALIZADO COM SUCESSO!")
                    {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        carregaGridView(0);
                        modo = 0;
                        Habilita();
                    }
                    else
                    {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO ATUALIZAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
        }
        private void RestaurarValores(string id, string cpf, string nome, string idade, string email, string genero, string celular, string experiencia)
        {
            txtId.Text = id;
            txtCpf.Text = cpf;
            txtNome.Text = nome;
            txtIdade.Text = idade;
            txtEmail.Text = email;
            txtGenero.Text = genero;
            txtCelular.Text = celular;
            txtExperiencia.Text = experiencia;
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
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
            txtCelular.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtExperiencia.Clear();
            txtGenero.Clear();
            txtIdade.Clear();
            txtNome.Clear();

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void rbtClietes_CheckedChanged(object sender, EventArgs e)
        {
           txtCidade.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtNumero.Clear();
            txtCEP.Clear();
            txtComplemeto.Clear();
            carregaGridView(0);

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

        }
    }
    
    
}
