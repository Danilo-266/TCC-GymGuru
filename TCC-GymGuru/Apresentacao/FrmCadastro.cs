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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Apresentacao
{
    public partial class FrmCadastro : Form
    {
        public FuncionarioService service;
        public FrmCadastro()
        {
            InitializeComponent();
            service = new FuncionarioService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (txtCorfirmaSenha.Text == txtSenha.Text) {
                string cpf = txtCPF.Text;
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                string genero = txtGenero.Text;
                string celular = txtCelular.Text;
                string senha = txtSenha.Text, confirmar = txtCorfirmaSenha.Text, cidade = txtCidade.Text, rua = txtRua.Text, bairro = txtBairro.Text, cep =txtCEP.Text, complemento = txtComplemento.Text;

                try
                {
                    string resultados = service.Cadrastro(cpf, nome, email, genero, celular, senha, confirmar, cidade, rua, bairro, int.Parse(txtNumero.Text),cep, complemento);
                    if (resultados != "FUNCIONARIO CADASTRADO COM SUCESSO")
                    {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FrmLogin login = new FrmLogin();
                        login.Show();
                        this.Close();
                        

                    }

                }
                catch (Exception ex){

                    MessageBox.Show(ex.Message, "ERRO AO CADASTRAR FUNCIONARIO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("AS DUAS SENHAS NÃO SÃO IGUAIS!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


           
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.Show();
            this.Close();
        }
    }
}
