namespace Apresentacao
{
    partial class FrmPesquisa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisa));
            this.btnFechar = new System.Windows.Forms.Button();
            this.lpPesquisa = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFechar.BackgroundImage")));
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnFechar.Location = new System.Drawing.Point(512, 9);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(27, 25);
            this.btnFechar.TabIndex = 9;
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lpPesquisa
            // 
            this.lpPesquisa.AutoSize = true;
            this.lpPesquisa.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lpPesquisa.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lpPesquisa.Location = new System.Drawing.Point(41, 11);
            this.lpPesquisa.Name = "lpPesquisa";
            this.lpPesquisa.Size = new System.Drawing.Size(77, 25);
            this.lpPesquisa.TabIndex = 55;
            this.lpPesquisa.Text = "Label:";
            this.lpPesquisa.Click += new System.EventHandler(this.lpPesquisa_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.Location = new System.Drawing.Point(37, 45);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(311, 26);
            this.txtPesquisa.TabIndex = 54;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(379, 43);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(119, 32);
            this.btnPesquisar.TabIndex = 56;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // Pesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(548, 91);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.lpPesquisa);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Pesquisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lpPesquisa;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnPesquisar;
    }
}