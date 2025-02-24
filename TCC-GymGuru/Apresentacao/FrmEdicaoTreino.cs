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
    public partial class FrmEdicaoTreino : Form
    {
        int id;
        public FrmEdicaoTreino(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FmrEdicaoTreino_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
