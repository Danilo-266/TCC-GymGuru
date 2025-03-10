
namespace Apresentacao
{
    partial class FrmClienteTreino
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPedido = new System.Windows.Forms.Label();
            this.dgPesquisa = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.bntAtribuir = new System.Windows.Forms.Button();
            this.rbntTdos = new System.Windows.Forms.RadioButton();
            this.rbtCliente = new System.Windows.Forms.RadioButton();
            this.btnDeletar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPedido
            // 
            this.lbPedido.AutoSize = true;
            this.lbPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPedido.ForeColor = System.Drawing.SystemColors.Control;
            this.lbPedido.Location = new System.Drawing.Point(22, 12);
            this.lbPedido.Name = "lbPedido";
            this.lbPedido.Size = new System.Drawing.Size(208, 24);
            this.lbPedido.TabIndex = 6;
            this.lbPedido.Text = "Treinos Cadastrados:";
            // 
            // dgPesquisa
            // 
            this.dgPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPesquisa.Location = new System.Drawing.Point(26, 63);
            this.dgPesquisa.Name = "dgPesquisa";
            this.dgPesquisa.Size = new System.Drawing.Size(361, 175);
            this.dgPesquisa.TabIndex = 42;
            this.dgPesquisa.SelectionChanged += new System.EventHandler(this.dgPesquisa_SelectionChanged);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(192, 248);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 44;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // bntAtribuir
            // 
            this.bntAtribuir.Location = new System.Drawing.Point(273, 248);
            this.bntAtribuir.Name = "bntAtribuir";
            this.bntAtribuir.Size = new System.Drawing.Size(114, 23);
            this.bntAtribuir.TabIndex = 45;
            this.bntAtribuir.Text = "Atribuir Novo Treino";
            this.bntAtribuir.UseVisualStyleBackColor = true;
            this.bntAtribuir.Click += new System.EventHandler(this.bntAtribuir_Click);
            // 
            // rbntTdos
            // 
            this.rbntTdos.AutoSize = true;
            this.rbntTdos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbntTdos.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.rbntTdos.Location = new System.Drawing.Point(170, 43);
            this.rbntTdos.Name = "rbntTdos";
            this.rbntTdos.Size = new System.Drawing.Size(60, 17);
            this.rbntTdos.TabIndex = 46;
            this.rbntTdos.TabStop = true;
            this.rbntTdos.Text = "Todos";
            this.rbntTdos.UseVisualStyleBackColor = true;
            this.rbntTdos.CheckedChanged += new System.EventHandler(this.rbntTdos_CheckedChanged);
            // 
            // rbtCliente
            // 
            this.rbtCliente.AutoSize = true;
            this.rbtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtCliente.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.rbtCliente.Location = new System.Drawing.Point(26, 43);
            this.rbtCliente.Name = "rbtCliente";
            this.rbtCliente.Size = new System.Drawing.Size(138, 17);
            this.rbtCliente.TabIndex = 47;
            this.rbtCliente.TabStop = true;
            this.rbtCliente.Text = "Cliente Selecionado";
            this.rbtCliente.UseVisualStyleBackColor = true;
            this.rbtCliente.CheckedChanged += new System.EventHandler(this.rbtCliente_CheckedChanged);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(26, 248);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(87, 23);
            this.btnDeletar.TabIndex = 48;
            this.btnDeletar.Text = "DeletarTreino";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // FrmClienteTreino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(426, 290);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.rbtCliente);
            this.Controls.Add(this.rbntTdos);
            this.Controls.Add(this.bntAtribuir);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dgPesquisa);
            this.Controls.Add(this.lbPedido);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClienteTreino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClienteTreino";
            this.Load += new System.EventHandler(this.ClienteTreino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPedido;
        private System.Windows.Forms.DataGridView dgPesquisa;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button bntAtribuir;
        private System.Windows.Forms.RadioButton rbntTdos;
        private System.Windows.Forms.RadioButton rbtCliente;
        private System.Windows.Forms.Button btnDeletar;
    }
}