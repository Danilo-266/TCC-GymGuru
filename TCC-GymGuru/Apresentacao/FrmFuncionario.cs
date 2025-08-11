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
    public partial class FrmFuncionario : Form
    {
        private readonly FuncionarioService funcionarioService;
        private DataTable tblFuncionario = new DataTable();
        private int modo = 0;
        public FrmFuncionario()
        {
            funcionarioService = new FuncionarioService();
            InitializeComponent();
            dgFuncionario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFuncionario.AllowUserToAddRows = false;
            dgFuncionario.AllowUserToDeleteRows = false;
            dgFuncionario.AllowUserToOrderColumns = true;
            dgFuncionario.ReadOnly = true;
            tblFuncionario = funcionarioService.exibir();
            useratual();

        }

        private void imgFunc_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmEquipamento equipamento = new FrmEquipamento();
            equipamento.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmTelaInicial tela = new FrmTelaInicial();

            tela.Show();
            this.Hide();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void Funcionario_Load(object sender, EventArgs e)
        {//idPersonal, cpf, nome, email, genero, celular, senha, online
            dgFuncionario.ColumnCount = 6;
            dgFuncionario.AutoGenerateColumns = false;

            dgFuncionario.Columns[0].Width = 60;
            dgFuncionario.Columns[0].HeaderText = "ID";
            dgFuncionario.Columns[0].DataPropertyName = "idPersonal";

            dgFuncionario.Columns[1].Width = 100;
            dgFuncionario.Columns[1].HeaderText = "CPF";
            dgFuncionario.Columns[1].DataPropertyName = "cpf";
            
            dgFuncionario.Columns[2].Width = 150;
            dgFuncionario.Columns[2].HeaderText = "NOME";
            dgFuncionario.Columns[2].DataPropertyName = "nome";

            dgFuncionario.Columns[3].Width = 150;
            dgFuncionario.Columns[3].HeaderText = "EMAIL";
            dgFuncionario.Columns[3].DataPropertyName = "email";

            dgFuncionario.Columns[4].Width = 120;
            dgFuncionario.Columns[4].HeaderText = "GENERO";
            dgFuncionario.Columns[4].DataPropertyName = "genero";

            dgFuncionario.Columns[5].Width = 120;
            dgFuncionario.Columns[5].HeaderText = "CELULAR";
            dgFuncionario.Columns[5].DataPropertyName = "celular";

            dgFuncionario.AllowUserToAddRows = false;
            dgFuncionario.AllowUserToDeleteRows = false;
            dgFuncionario.MultiSelect = false;
            dgFuncionario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            carregaGridView();
        }
        private void useratual()
        {
            DataTable usuario = funcionarioService.pesquisar(SessaoUsuario.User);
            DataRow row = usuario.Rows[0];
            lbNome.Text = row["nome"].ToString();
            lbGenero.Text = row["genero"].ToString();
            lbEmail.Text = row["email"].ToString();
            lbCpf.Text = row["cpf"].ToString();
            lbCelular.Text = row["celular"].ToString() ;
            
           
        }

        private void carregaGridView()
        {
            DataTable dt = funcionarioService.exibir();
            dt.DefaultView.Sort = "nome ASC";
            dgFuncionario.DataSource = dt;
            dgFuncionario.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
