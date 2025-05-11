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
            InitializeComponent();

            
                try
                {
                    // Obter a lista de equipamentos
                   

                    // Verificar se há dados na lista
                    if (listaEquipamentos != null && listaEquipamentos.Count > 0)
                    {
                        Console.WriteLine("Quantidade de equipamentos: " + listaEquipamentos.Count);

                        // Verificar os dados da lista
                        foreach (var equipamento in listaEquipamentos)
                        {
                            Console.WriteLine($"ID: {equipamento.id}, Nome: {equipamento.nome}, Usabilidade: {equipamento.usabilidade}");
                        }

                        // Configurar o ReportViewer
                        reportViewer1.Reset();
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.ReportPath = "RelatorioEquipamentos.rdlc";

                        // Criar e adicionar o DataSource
                        ReportDataSource rds = new ReportDataSource("DataSetEquipamento", listaEquipamentos);
                        reportViewer1.LocalReport.DataSources.Add(rds);

                        // Atualizar o relatório
                        reportViewer1.LocalReport.Refresh();
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("A lista de equipamentos está vazia!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar o relatório: " + ex.Message);
                }
            



            /*

            ReportDataSource rds = new ReportDataSource("DataSetEquipamento", listaEquipamentos);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.ReportPath = "RelatorioEquipamento.rdlc";
            reportViewer1.RefreshReport();*/

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
