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
    public partial class Login : Form
    {
        public FuncionarioService service;

        public Login()
        {
            service = new FuncionarioService();
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            String usuario = txtLogin.Text;
            String senha = txtSenha.Text;

            bool permissao = true;
            try
            {
                permissao = service.Login(usuario, senha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (permissao == true)
            {
                MessageBox.Show("USUARIO ENCONTRADO", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SessaoUsuario.User = txtLogin.Text;
                TelaInicial tela = new TelaInicial();
           

                tela.Show();
                this.Hide();

                
                
            }
            else
            {
                MessageBox.Show("USUARIO NÃO ENCONTRADO", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
            this.Hide();
        }
    }
}
