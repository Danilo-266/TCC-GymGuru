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

namespace Apresentacao
{
    public partial class FrmEdicaoEquipamento : Form
    {
        private readonly EquipamentoService equipamentoService;
        int ID;
        public FrmEdicaoEquipamento(int iD)
        {
            equipamentoService = new EquipamentoService();
            InitializeComponent();
            ID = iD;


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEdicaoEquipamento_Load(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                label2.Text = "Cadastrar Equipamento:";
            }
            else
            {
                label2.Text = "Atualizar Equipamento:";
            }
            
             DataTable dt = equipamentoService.PesquisaPorId(ID);

            if(dt != null && dt.Rows.Count > 0)
            {
                txtNome.Text = dt.Rows[0]["nome"].ToString();
                txtMusculo.Text = dt.Rows[0]["grupoMuscular"].ToString();
                txtDesc.Text = dt.Rows[0]["descricao"].ToString();
               

               
            }


        }
    }
}
