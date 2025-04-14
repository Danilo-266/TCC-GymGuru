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
    public partial class FrmEdicaoEquipamento : Form
    {
        private readonly EquipamentoService equipamentoService;
        int id;
        public FrmEdicaoEquipamento(int id)
        {
            equipamentoService = new EquipamentoService();
            InitializeComponent();
            this.id = id;


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEdicaoEquipamento_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                label2.Text = "Cadastrar Equipamento:";
            }
            else
            {
                label2.Text = "Atualizar Equipamento:";
            }
            
             DataTable dt = equipamentoService.PesquisaPorId(id);

            if(dt != null && dt.Rows.Count > 0)
            {
                txtNome.Text = dt.Rows[0]["nome"].ToString();
                txtMusculo.Text = dt.Rows[0]["grupoMuscular"].ToString();
                txtDesc.Text = dt.Rows[0]["descricao"].ToString();
               

               
            }


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text, descricao = txtDesc.Text, musculo = txtMusculo.Text;
        
            if (id == 0)
            {
                try
                {
                    string resultado = equipamentoService.Cadastrar(nome, descricao, musculo);
                    if (resultado == "EQUIPAMENTO CADASTRADO COM SUCESSO!")
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

                    MessageBox.Show(ex.Message, "ERRO AO CADASTRAR EQUIPAMENTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                }


            }
            else
            {

                try
                {
                    string resultados = equipamentoService.update(id, nome, descricao, musculo);
                    if (resultados == "EQUIPAMENTO ATUALIZADO COM SUCESSO!")
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

                    MessageBox.Show(ex.Message, "ERRO AO ATUALIZAR EQUIPAMENTO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
