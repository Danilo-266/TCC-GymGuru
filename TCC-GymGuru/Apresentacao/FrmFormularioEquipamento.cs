using Dados;
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
    public partial class FrmFormularioEquipamento: Form
    {
        List<Equipamento> listaEquipamentos = new List<Equipamento>();
        public FrmFormularioEquipamento(List<Equipamento> listaEquipamentos)
        {
            InitializeComponent();
            this.listaEquipamentos  = listaEquipamentos;
          
        }

        private void FrmFormulario_Load(object sender, EventArgs e)
        {
            try
            {
                if (listaEquipamentos != null && listaEquipamentos.Count > 0)
                {
                    // Criar um DataTable
                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(int));
                    dt.Columns.Add("nome", typeof(string));
                    dt.Columns.Add("descricao", typeof(string));
                    dt.Columns.Add("musculo", typeof(string));
                    dt.Columns.Add("usabilidade", typeof(int));

                    // Preencher o DataTable com os dados
                    foreach (var equipamento in listaEquipamentos)
                    {
                        dt.Rows.Add(equipamento.id, equipamento.nome, equipamento.descricao, equipamento.musculo, equipamento.usabilidade);
                    }

                    // Configurar o ReportViewer
                    reportViewer1.Reset();
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.ReportPath = @"C:\Users\Usuario\Desktop\TCC-GymGuru\TCC-GymGuru\Apresentacao\RelatorioEquipamento.rdlc";

                    // Criar e adicionar o DataSource
                    ReportDataSource rds = new ReportDataSource("DataSetEquipamento", dt);
                    reportViewer1.LocalReport.DataSources.Add(rds);

                    // Atualizar o relatório
                    reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("A lista de equipamentos está vazia!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o relatório: " + ex.Message + "\n" + ex.StackTrace);
            }
        }


        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
