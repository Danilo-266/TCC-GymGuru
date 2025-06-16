using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Apresentacao
{
    public partial class FrmEdicaoCliente : Form
    {

        private readonly ClienteService clienteService;

        int id = 0;
        public FrmEdicaoCliente(int pesquisa)
        {
            clienteService = new ClienteService();
            InitializeComponent();
             id = pesquisa;
        }

        




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmEdicao_Load(object sender, EventArgs e)
        {
            if (id ==0)
            {
                label2.Text = "Cadastrar cliente";
            }
            else
            {
                label2.Text = "Atualizar cliente";
            }

            DataTable dt = clienteService.pesquisaPorId(id);
           
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCpf.Text = dt.Rows[0]["cpf"].ToString();
                txtNome.Text = dt.Rows[0]["nome"].ToString();
                txtIdade.Text = dt.Rows[0]["idade"].ToString();
                txtEmail.Text = dt.Rows[0]["email"].ToString();
                txtGenero.Text = dt.Rows[0]["genero"].ToString();
                txtCelular.Text = dt.Rows[0]["celular"].ToString();
                txtExperiencia.Text = dt.Rows[0]["experiencia"].ToString();
                int end = int.Parse(dt.Rows[0]["idEdenreco"].ToString());

 
                DataTable dtEnd = clienteService.getAllEndId(end);
                txtCidade.Text = dtEnd.Rows[0]["cidade"].ToString();
                txtRua.Text = dtEnd.Rows[0]["rua"].ToString();
                txtBairro.Text = dtEnd.Rows[0]["bairro"].ToString();
                txtNumero.Text = dtEnd.Rows[0]["numero"].ToString();
                txtCEP.Text = dtEnd.Rows[0]["cep"].ToString();
                txtComplemeto.Text = dtEnd.Rows[0]["complemento"].ToString();


                //idEndereco, , , , , cep, complemento
            }





        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
            String cpf = txtCpf.Text, nome = txtNome.Text, email = txtEmail.Text, genero = txtGenero.Text, experiencia = txtExperiencia.Text;
            string rua = txtRua.Text, bairro = txtBairro.Text, cep = txtCEP.Text, complemento = txtComplemeto.Text, cidade = txtCidade.Text, cref = txtPersonal.Text; 
            int.TryParse(txtCelular.Text, out int celular);
            int.TryParse(txtNumero.Text, out int numero);
            int.TryParse(txtIdade.Text, out int idade);
            string tipo = "";

            if (rbPersonal.Checked)
            {
                tipo = "Personal";
            }
            else if (rbUsuario.Checked)
            {
                tipo = "Usuario";
            }

            string senha = clienteService.GerarSenha(6);
           
            if (id == 0)
            {
                if (rbUsuario.Checked)
                {
                    try
                    {
                        string resultados = clienteService.CadastrarCliente(cpf, nome, idade, email, genero, celular, experiencia, cidade, rua, bairro, numero, cep, complemento, senha);
                        if (resultados == "Cliete cadastrado com sucesso")
                        {
                            MessageBox.Show("Cliente Cadastrado com sucesso:\n\nLogin no APP Mobile:\n\nLogin: " + email + "\nSenha: " + senha, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "ERRO AO CADASTRAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    try
                    {
                        string resultados = clienteService.CadastrarPersonal(cpf, nome, idade, email, genero, celular, experiencia, cidade, rua, bairro, numero, cep, complemento,cref ,senha);
                        if (resultados == "Cliete cadastrado com sucesso")
                        {
                            MessageBox.Show("Cliente Cadastrado com sucesso:\n\nLogin no APP Mobile:\nLogin: " + email + "\nSenha: " + senha, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "ERRO AO CADASTRAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }

            }
            else
            {

                try
                {
                    int idEnd= 0;
                    string resultados = clienteService.update(id, cpf, nome, idade, email, genero, celular, experiencia, cidade, idEnd, rua, bairro, numero, cep, complemento);
                    if (resultados == "CLIENTE ATUALIZADO COM SUCESSO!")
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

                    MessageBox.Show(ex.Message, "ERRO AO ATUALIZAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            txtPersonal.Enabled = true; 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtPersonal.Clear();
            txtPersonal.Enabled = false;   
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
