namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Conta
{
    partial class frmCadastrarConta
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
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtLeituraAnterior = new System.Windows.Forms.TextBox();
            this.txtLeituraAtual = new System.Windows.Forms.TextBox();
            this.lblLeitura_Anterior = new System.Windows.Forms.Label();
            this.lblLeitura_Atual = new System.Windows.Forms.Label();
            this.txtMskCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.txtMskCPF = new System.Windows.Forms.MaskedTextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.rdbPessoaJuridica = new System.Windows.Forms.RadioButton();
            this.rdbPessoaFisica = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(199, 152);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 31;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(47, 152);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 30;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtLeituraAnterior
            // 
            this.txtLeituraAnterior.Location = new System.Drawing.Point(141, 112);
            this.txtLeituraAnterior.Name = "txtLeituraAnterior";
            this.txtLeituraAnterior.Size = new System.Drawing.Size(116, 20);
            this.txtLeituraAnterior.TabIndex = 29;
            // 
            // txtLeituraAtual
            // 
            this.txtLeituraAtual.Location = new System.Drawing.Point(141, 78);
            this.txtLeituraAtual.Name = "txtLeituraAtual";
            this.txtLeituraAtual.Size = new System.Drawing.Size(116, 20);
            this.txtLeituraAtual.TabIndex = 28;
            // 
            // lblLeitura_Anterior
            // 
            this.lblLeitura_Anterior.AutoSize = true;
            this.lblLeitura_Anterior.Location = new System.Drawing.Point(50, 115);
            this.lblLeitura_Anterior.Name = "lblLeitura_Anterior";
            this.lblLeitura_Anterior.Size = new System.Drawing.Size(81, 13);
            this.lblLeitura_Anterior.TabIndex = 27;
            this.lblLeitura_Anterior.Text = "Leitura Anterior:";
            // 
            // lblLeitura_Atual
            // 
            this.lblLeitura_Atual.AutoSize = true;
            this.lblLeitura_Atual.Location = new System.Drawing.Point(50, 81);
            this.lblLeitura_Atual.Name = "lblLeitura_Atual";
            this.lblLeitura_Atual.Size = new System.Drawing.Size(69, 13);
            this.lblLeitura_Atual.TabIndex = 26;
            this.lblLeitura_Atual.Text = "Leitura Atual:";
            // 
            // txtMskCNPJ
            // 
            this.txtMskCNPJ.Location = new System.Drawing.Point(189, 37);
            this.txtMskCNPJ.Mask = "00.000.000/0000-00";
            this.txtMskCNPJ.Name = "txtMskCNPJ";
            this.txtMskCNPJ.Size = new System.Drawing.Size(110, 20);
            this.txtMskCNPJ.TabIndex = 25;
            this.txtMskCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMskCNPJ.Visible = false;
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(156, 40);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(37, 13);
            this.lblCnpj.TabIndex = 24;
            this.lblCnpj.Text = "CNPJ:";
            this.lblCnpj.Visible = false;
            // 
            // txtMskCPF
            // 
            this.txtMskCPF.Location = new System.Drawing.Point(46, 37);
            this.txtMskCPF.Mask = "000.000.000-00";
            this.txtMskCPF.Name = "txtMskCPF";
            this.txtMskCPF.Size = new System.Drawing.Size(99, 20);
            this.txtMskCPF.TabIndex = 23;
            this.txtMskCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMskCPF.Visible = false;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(10, 40);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(30, 13);
            this.lblCPF.TabIndex = 22;
            this.lblCPF.Text = "CPF:";
            this.lblCPF.Visible = false;
            // 
            // rdbPessoaJuridica
            // 
            this.rdbPessoaJuridica.AutoSize = true;
            this.rdbPessoaJuridica.Location = new System.Drawing.Point(198, 14);
            this.rdbPessoaJuridica.Name = "rdbPessoaJuridica";
            this.rdbPessoaJuridica.Size = new System.Drawing.Size(101, 17);
            this.rdbPessoaJuridica.TabIndex = 21;
            this.rdbPessoaJuridica.TabStop = true;
            this.rdbPessoaJuridica.Text = "Pessoa Jurídica";
            this.rdbPessoaJuridica.UseVisualStyleBackColor = true;
            this.rdbPessoaJuridica.CheckedChanged += new System.EventHandler(this.rdbPessoaJuridica_CheckedChanged);
            // 
            // rdbPessoaFisica
            // 
            this.rdbPessoaFisica.AutoSize = true;
            this.rdbPessoaFisica.Location = new System.Drawing.Point(28, 14);
            this.rdbPessoaFisica.Name = "rdbPessoaFisica";
            this.rdbPessoaFisica.Size = new System.Drawing.Size(92, 17);
            this.rdbPessoaFisica.TabIndex = 20;
            this.rdbPessoaFisica.TabStop = true;
            this.rdbPessoaFisica.Text = "Pessoa Física";
            this.rdbPessoaFisica.UseVisualStyleBackColor = true;
            this.rdbPessoaFisica.CheckedChanged += new System.EventHandler(this.rdbPessoaFisica_CheckedChanged);
            // 
            // frmCadastrarConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 189);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtLeituraAnterior);
            this.Controls.Add(this.txtLeituraAtual);
            this.Controls.Add(this.lblLeitura_Anterior);
            this.Controls.Add(this.lblLeitura_Atual);
            this.Controls.Add(this.txtMskCNPJ);
            this.Controls.Add(this.lblCnpj);
            this.Controls.Add(this.txtMskCPF);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.rdbPessoaJuridica);
            this.Controls.Add(this.rdbPessoaFisica);
            this.Name = "frmCadastrarConta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Conta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.TextBox txtLeituraAnterior;
        private System.Windows.Forms.TextBox txtLeituraAtual;
        private System.Windows.Forms.Label lblLeitura_Anterior;
        private System.Windows.Forms.Label lblLeitura_Atual;
        private System.Windows.Forms.MaskedTextBox txtMskCNPJ;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.MaskedTextBox txtMskCPF;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.RadioButton rdbPessoaJuridica;
        private System.Windows.Forms.RadioButton rdbPessoaFisica;
    }
}