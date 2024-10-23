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
    public partial class FrmRelatorio : Form
    {
        public FrmRelatorio()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmEquipamento equipamento = new FrmEquipamento();
            equipamento.Show();
            this.Close();
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
            FrmRelatorio relatorio = new FrmRelatorio();
            relatorio.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmTelaInicial telaInicial = new FrmTelaInicial();
            telaInicial.Show();
            this.Close();
        }
    }
}
