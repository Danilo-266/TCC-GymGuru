using MySql.Data.MySqlClient;
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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Apresentacao
{
    public partial class FrmEdicaoTreino : Form
    {
        private readonly TreinoService treinoService;
        int id;
        public FrmEdicaoTreino(int id)
        {
            treinoService = new TreinoService();
            InitializeComponent();
            this.id = id;
            CarregarEquipamentosNoComboBox();
        }
        private string connectionString = "server=143.106.241.4;user=cl203518;database=cl203518;password=cl*15052007";

        private void CarregarEquipamentosNoComboBox()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT nome FROM GymGuruAparelho"; // Apenas os nomes

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBoxEquipamento.Items.Clear(); // Limpa os itens antes de carregar

                            while (reader.Read())
                            {
                                comboBoxEquipamento.Items.Add(reader["nome"].ToString()); // Adiciona apenas o nome
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar equipamentos: " + ex.Message);
            }
        }

        private void FmrEdicaoTreino_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                label2.Text = "Cadastrar Treinos:";
            }
            else
            {
                label2.Text = "Atualizar Treinos:";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            String nome = txtExercicio.Text, descricao = txtDesc.Text, grupomuscular = txtMusculo.Text, aparelho = comboBoxEquipamento.SelectedItem.ToString();
            int.TryParse(txtSeries.Text, out int series);
           



            if (id == 0)
            {
                try
                {
                    String resultado = treinoService.Cadastrar(nome, descricao, series, grupomuscular, treinoService.pesquisarAparelhoID(aparelho));
                    if (resultado == "TREINO CADASTRADO COM SUCESSO!")
                    {
                        MessageBox.Show(resultado, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(resultado, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO CADASTRAR TREINO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }

            }
            else
            {

                try
                {
                    string resultados = treinoService.update(id, nome, descricao, series, grupomuscular);
                    if (resultados == "TREINO ATUALIZADO COM SUCESSO!")
                    {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO ATUALIZAR TREINO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
