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
  

    
        public partial class FrmFormularioEquipamento : Form
        {
            List<Equipamento> listaEquipamentos = new List<Equipamento>();

            public FrmFormularioEquipamento(List<Equipamento> listaEquipamentos)
            {
                InitializeComponent();
                this.listaEquipamentos = listaEquipamentos;
            }

        private void FrmFormulario_Load(object sender, EventArgs e)
        {
            try
            {
                if (listaEquipamentos != null && listaEquipamentos.Count > 0)
                {
                    
                    var musculosUnicos = listaEquipamentos
                     .Select(equip => equip.musculo)
                     .Where(m => !string.IsNullOrEmpty(m))
                       .Distinct()
                      .OrderBy(m => m)
                      .ToList();
                    musculosUnicos.Insert(0, "Todos");

                   
                    comboBox1.DataSource = musculosUnicos;
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

                    comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

                   
                    AtualizarRelatorio(listaEquipamentos);
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string musculoSelecionado = comboBox1.SelectedItem.ToString();
            List<Equipamento> listaFiltrada;

            if (musculoSelecionado == "Todos")
                listaFiltrada = listaEquipamentos;
            else
                listaFiltrada = listaEquipamentos.FindAll(equip => equip.musculo == musculoSelecionado);

            AtualizarRelatorio(listaFiltrada);
        }

        private void AtualizarRelatorio(List<Equipamento> equipamentosParaRelatorio)
        {
            reportViewer1.Reset();
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = @"C:\Users\lucas\OneDrive\Desktop\TCC-GymGuru\TCC-GymGuru\Apresentacao\RelatorioEquipamento.rdlc";

            ReportDataSource rds = new ReportDataSource("DataSetEquipamento", equipamentosParaRelatorio);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }


        private void reportViewer1_Load(object sender, EventArgs e)
            {
                
            }
        }
    


}
