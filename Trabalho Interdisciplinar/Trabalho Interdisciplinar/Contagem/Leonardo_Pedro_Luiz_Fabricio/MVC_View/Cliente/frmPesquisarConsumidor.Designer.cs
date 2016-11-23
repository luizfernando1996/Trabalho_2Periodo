namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Cliente
{
    partial class frmPesquisarConsumidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisarConsumidor));
            this.lblResultado = new System.Windows.Forms.Label();
            this.listViewResultadoConsum = new System.Windows.Forms.ListView();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtMskCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.txtMskCPF = new System.Windows.Forms.MaskedTextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.rdbPessoaJuridica = new System.Windows.Forms.RadioButton();
            this.rdbPessoaFisica = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(15, 149);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(119, 13);
            this.lblResultado.TabIndex = 33;
            this.lblResultado.Text = "Resultado da Pesquisa:";
            // 
            // listViewResultadoConsum
            // 
            this.listViewResultadoConsum.Location = new System.Drawing.Point(12, 165);
            this.listViewResultadoConsum.Name = "listViewResultadoConsum";
            this.listViewResultadoConsum.Size = new System.Drawing.Size(356, 158);
            this.listViewResultadoConsum.TabIndex = 32;
            this.listViewResultadoConsum.UseCompatibleStateImageBehavior = false;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(250, 93);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 31;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(54, 118);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 27);
            this.btnPesquisar.TabIndex = 30;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtMskCNPJ
            // 
            this.txtMskCNPJ.Location = new System.Drawing.Point(225, 67);
            this.txtMskCNPJ.Mask = "00.000.000/0000-00";
            this.txtMskCNPJ.Name = "txtMskCNPJ";
            this.txtMskCNPJ.Size = new System.Drawing.Size(100, 20);
            this.txtMskCNPJ.TabIndex = 29;
            this.txtMskCNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMskCNPJ.Visible = false;
            this.txtMskCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMskCNPJ_KeyPress);
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(182, 70);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(37, 13);
            this.lblCnpj.TabIndex = 28;
            this.lblCnpj.Text = "CNPJ:";
            this.lblCnpj.Visible = false;
            // 
            // txtMskCPF
            // 
            this.txtMskCPF.Location = new System.Drawing.Point(72, 67);
            this.txtMskCPF.Mask = "000.000.000-00";
            this.txtMskCPF.Name = "txtMskCPF";
            this.txtMskCPF.Size = new System.Drawing.Size(99, 20);
            this.txtMskCPF.TabIndex = 27;
            this.txtMskCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMskCPF.Visible = false;
            this.txtMskCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMskCPF_KeyPress);
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(28, 70);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(30, 13);
            this.lblCPF.TabIndex = 26;
            this.lblCPF.Text = "CPF:";
            this.lblCPF.Visible = false;
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(79, 18);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(246, 20);
            this.txtNome.TabIndex = 25;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(35, 21);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 24;
            this.lblNome.Text = "Nome:";
            // 
            // rdbPessoaJuridica
            // 
            this.rdbPessoaJuridica.AutoSize = true;
            this.rdbPessoaJuridica.Location = new System.Drawing.Point(224, 44);
            this.rdbPessoaJuridica.Name = "rdbPessoaJuridica";
            this.rdbPessoaJuridica.Size = new System.Drawing.Size(101, 17);
            this.rdbPessoaJuridica.TabIndex = 23;
            this.rdbPessoaJuridica.TabStop = true;
            this.rdbPessoaJuridica.Text = "Pessoa Jurídica";
            this.rdbPessoaJuridica.UseVisualStyleBackColor = true;
            this.rdbPessoaJuridica.CheckedChanged += new System.EventHandler(this.rdbPessoaJuridica_CheckedChanged);
            // 
            // rdbPessoaFisica
            // 
            this.rdbPessoaFisica.AutoSize = true;
            this.rdbPessoaFisica.Location = new System.Drawing.Point(54, 44);
            this.rdbPessoaFisica.Name = "rdbPessoaFisica";
            this.rdbPessoaFisica.Size = new System.Drawing.Size(92, 17);
            this.rdbPessoaFisica.TabIndex = 22;
            this.rdbPessoaFisica.TabStop = true;
            this.rdbPessoaFisica.Text = "Pessoa Física";
            this.rdbPessoaFisica.UseVisualStyleBackColor = true;
            this.rdbPessoaFisica.CheckedChanged += new System.EventHandler(this.rdbPessoaFisica_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(188, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 27);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(139, 140);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(41, 17);
            this.checkBox2.TabIndex = 35;
            this.checkBox2.Text = "Txt";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(139, 107);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(43, 17);
            this.checkBox1.TabIndex = 34;
            this.checkBox1.Text = "Xml";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // frmPesquisarConsumidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 340);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.listViewResultadoConsum);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.txtMskCNPJ);
            this.Controls.Add(this.lblCnpj);
            this.Controls.Add(this.txtMskCPF);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.rdbPessoaJuridica);
            this.Controls.Add(this.rdbPessoaFisica);
            this.Name = "frmPesquisarConsumidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Consumidor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.ListView listViewResultadoConsum;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.MaskedTextBox txtMskCNPJ;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.MaskedTextBox txtMskCPF;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.RadioButton rdbPessoaJuridica;
        private System.Windows.Forms.RadioButton rdbPessoaFisica;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}