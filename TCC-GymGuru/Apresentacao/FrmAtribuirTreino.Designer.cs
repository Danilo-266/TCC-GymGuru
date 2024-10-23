namespace Apresentacao
{
    partial class FrmAtribuirTreino
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
            this.dgCliente = new System.Windows.Forms.DataGridView();
            this.dgTreino = new System.Windows.Forms.DataGridView();
            this.lbPedido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAtribuir = new System.Windows.Forms.Button();
            this.btnTreino = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTreino)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCliente
            // 
            this.dgCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCliente.Location = new System.Drawing.Point(32, 107);
            this.dgCliente.Name = "dgCliente";
            this.dgCliente.Size = new System.Drawing.Size(437, 273);
            this.dgCliente.TabIndex = 18;
            this.dgCliente.SelectionChanged += new System.EventHandler(this.dgCliente_SelectionChanged);
            // 
            // dgTreino
            // 
            this.dgTreino.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTreino.Location = new System.Drawing.Point(497, 107);
            this.dgTreino.Name = "dgTreino";
            this.dgTreino.Size = new System.Drawing.Size(437, 273);
            this.dgTreino.TabIndex = 19;
            this.dgTreino.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // lbPedido
            // 
            this.lbPedido.AutoSize = true;
            this.lbPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPedido.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lbPedido.Location = new System.Drawing.Point(27, 24);
            this.lbPedido.Name = "lbPedido";
            this.lbPedido.Size = new System.Drawing.Size(178, 29);
            this.lbPedido.TabIndex = 20;
            this.lbPedido.Text = "Atribuir treino:";
            this.lbPedido.Click += new System.EventHandler(this.lbPedido_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(27, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 49;
            this.label1.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(492, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 50;
            this.label2.Text = "Treino:";
            // 
            // btnAtribuir
            // 
            this.btnAtribuir.Location = new System.Drawing.Point(842, 388);
            this.btnAtribuir.Name = "btnAtribuir";
            this.btnAtribuir.Size = new System.Drawing.Size(92, 23);
            this.btnAtribuir.TabIndex = 51;
            this.btnAtribuir.Text = "Atribuir";
            this.btnAtribuir.UseVisualStyleBackColor = true;
            // 
            // btnTreino
            // 
            this.btnTreino.Location = new System.Drawing.Point(32, 388);
            this.btnTreino.Name = "btnTreino";
            this.btnTreino.Size = new System.Drawing.Size(129, 23);
            this.btnTreino.TabIndex = 52;
            this.btnTreino.Text = "Cadastrar Novo Treino";
            this.btnTreino.UseVisualStyleBackColor = true;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(729, 388);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(92, 23);
            this.btnVoltar.TabIndex = 53;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // FrmAtribuirTreino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(963, 423);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnTreino);
            this.Controls.Add(this.btnAtribuir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPedido);
            this.Controls.Add(this.dgTreino);
            this.Controls.Add(this.dgCliente);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAtribuirTreino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AtribuirTreino";
            this.Load += new System.EventHandler(this.FrmAtribuirTreino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTreino)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCliente;
        private System.Windows.Forms.DataGridView dgTreino;
        private System.Windows.Forms.Label lbPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAtribuir;
        private System.Windows.Forms.Button btnTreino;
        private System.Windows.Forms.Button btnVoltar;
    }
}