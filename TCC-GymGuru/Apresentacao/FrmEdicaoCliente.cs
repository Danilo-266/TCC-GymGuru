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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Apresentacao
{
    public partial class FrmEdicaoCliente : Form
    {

        private readonly ClienteService clienteService;

        int funcao = 0;
        int evento = 0;
        int id = 0;
        public FrmEdicaoCliente(int tipo,int modo ,int pesquisa)
        {
            clienteService = new ClienteService();
            InitializeComponent();
                 funcao  = tipo;
                evento = modo;
             id = pesquisa;
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmEdicao_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
            String cpf = txtCpf.Text, nome = txtNome.Text, email = txtEmail.Text, genero = txtGenero.Text, experiencia = txtExperiencia.Text;
            string rua = txtRua.Text, bairro = txtBairro.Text, cep = txtCEP.Text, complemento = txtComplemeto.Text, cidade = txtCidade.Text;
            int.TryParse(txtCelular.Text, out int celular);
            int.TryParse(txtNumero.Text, out int numero);
            int.TryParse(txtIdade.Text, out int idade);
           
            if (id == 0)
            {
                try
                {
                    string resultados = clienteService.Cadastrar(cpf, nome, idade, email, genero, celular, experiencia, cidade, rua, bairro, numero, cep, complemento);
                    if (resultados == "Cliete cadastrado com sucesso")
                    {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(resultados, "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "ERRO AO CADASTRAR CLIENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
    }
}
