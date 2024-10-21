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
    public partial class Treino : Form
    {
        private readonly TreinoService treinoService;
        private DataTable tblTreino = new DataTable();
        private int modo = 0;
        
        public Treino()
        {
            treinoService = new TreinoService();
            InitializeComponent();
            dgTreino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgTreino.AllowUserToAddRows = false;
            dgTreino.AllowUserToDeleteRows = false;
            dgTreino.AllowUserToOrderColumns = true;
            dgTreino.ReadOnly = true;

            tblTreino = treinoService.exibir();
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
                    btnPesquisar.Enabled = true;
                    txtDesc.Enabled = false;
                    txtExercicio.Enabled = false;
                    txtMusculo.Enabled = false;
                    txtSeries.Enabled = false;
                    txtId.Enabled = false;
                    txtId.Enabled = false;
                    txtEquipamento.Enabled = false;
                    break;
                case 1://Adicionar
                    txtDesc.Enabled=true;
                    txtExercicio.Enabled=true;
                    txtMusculo.Enabled=true;
                    txtId.Enabled=true;
                    txtEquipamento.Enabled=true;
                    txtSeries.Enabled=true;
                    btnCancelar.Enabled=true;
                    btnSalvar.Enabled=true;
                    btnNovo.Enabled=false;
                    btnAlterar.Enabled=false;
                    btnExcluir.Enabled=false;
                    btnPesquisar.Enabled=false;
                    txtId.Enabled = false;
                    break;
                    
            }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
        }

        private void dgTreino_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null) 
                return;
            txtExercicio.Text =  dgTreino.CurrentRow.Cells[1].Value.ToString();
            txtDesc.Text = dgTreino.CurrentRow.Cells[2].Value.ToString();
            txtSeries.Text = dgTreino.CurrentRow.Cells[3].Value.ToString();
            txtMusculo.Text = dgTreino.CurrentRow.Cells[4].Value.ToString();
            txtId.Text = dgTreino.CurrentRow.Cells[0].Value.ToString();
            txtEquipamento.Text = treinoService.pesquisaAparelhoNome(int.Parse(dgTreino.CurrentRow.Cells[5].Value.ToString()) ) ;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            String nome = txtExercicio.Text, descricao = txtDesc.Text, grupomuscular = txtMusculo.Text, aparelho = txtEquipamento.Text;
            int.TryParse(txtSeries.Text, out int series);
            int.TryParse(txtId.Text, out int id);

            
     
            if (txtId.Text == "")
            {
                try
                {
                    treinoService.Cadastrar(nome, descricao, series, grupomuscular, treinoService.pesquisarAparelhoID(aparelho));
                    MessageBox.Show("TREINO CADASTRADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO CADASTRAR TREINO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                modo = 0;
                Habilita();
                carregaGridView();
            }
            else
            {
                
                try
                {
                    treinoService.update(id, nome, descricao, series, grupomuscular);
                    MessageBox.Show("TREINO ATUALIZADO COM SUCESSO!", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                }
                catch (Exception ex)
                {
                  
                    MessageBox.Show(ex.Message, "ERRO AO ATUALIZAR TREINO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                carregaGridView();
                modo = 0;
                Habilita();
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
            txtDesc.Clear();
            txtMusculo.Clear();
            txtId.Clear();
            txtSeries.Clear();
            txtExercicio.Clear();
            txtId.Clear();
            txtEquipamento.Clear();
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
            Pesquisa p = new Pesquisa(1);
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
            Habilita();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
