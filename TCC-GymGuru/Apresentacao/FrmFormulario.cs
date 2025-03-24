using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
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
    public partial class FrmFormulario: Form
    {
        public FrmFormulario()
        {
            InitializeComponent();
        }

        private void FrmFormulario_Load(object sender, EventArgs e)
        {

            InitializeComponent();
        }

        private void FormRelatorio_Load(object sender, EventArgs e)
        {
            CarregarRelatorio();
        }

        private void CarregarRelatorio()
        {
            string connString = "Server=localhost;Database=gymguru;User Id=root;Password=1234;";
            string query = "SELECT * FROM usuarios"; // Altere para sua tabela

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    conn.Close();

                    // Passar os dados para o ReportViewer
                    ReportDataSource rds = new ReportDataSource("DataSetUsuarios", dt);
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }
    }
}
