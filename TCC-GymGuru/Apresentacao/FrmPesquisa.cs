using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Apresentacao
{
    public partial class FrmPesquisa : Form
    {
        private int funcao;

        private string _texto;
        public FrmPesquisa(int n)
        {
            InitializeComponent();
            funcao = n;
            Texto = "";
            if (funcao == 1)
                lpPesquisa.Text = "Digite o nome do treino desejado:";
            else if (funcao == 2)
                lpPesquisa.Text = "Digite o nome do cliente desejado:";
            else if (funcao == 3)
                lpPesquisa.Text = "Digite o nome do equipamento desejado:";
        }
        public string Texto { get => _texto; set => _texto = value; }
        

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public int n { get => funcao; set => funcao = value; }




        private void lpPesquisa_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            
                   
                    if (!string.IsNullOrEmpty(txtPesquisa.Text))
                    {
                        Texto = txtPesquisa.Text;
                    }
                    this.Close();
                    
            
        }
    }
}
