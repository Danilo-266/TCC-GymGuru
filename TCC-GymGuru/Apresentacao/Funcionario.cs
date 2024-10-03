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
    public partial class Funcionario : Form
    {
        public Funcionario()
        {
            InitializeComponent();
            
        }

        private void imgFunc_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TelaInicial tela = new TelaInicial();

            tela.Show();
            this.Hide();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Relatorio relatorio = new Relatorio();
            relatorio.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }
        


    }
}
