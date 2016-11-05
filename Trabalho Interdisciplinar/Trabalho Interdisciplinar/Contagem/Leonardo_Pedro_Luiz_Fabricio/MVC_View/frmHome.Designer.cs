namespace Trabalho_Interdisciplinar
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_Consumidor = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Consumidor_Cadastrar = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Consumidor_Consultar = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Conta = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Conta_Cadastrar = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Conta_Consultar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(50, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 200);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Consumidor,
            this.menu_Conta});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(432, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_Consumidor
            // 
            this.menu_Consumidor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Consumidor_Cadastrar,
            this.menu_Consumidor_Consultar});
            this.menu_Consumidor.Name = "menu_Consumidor";
            this.menu_Consumidor.Size = new System.Drawing.Size(85, 20);
            this.menu_Consumidor.Text = "Consumidor";
            // 
            // menu_Consumidor_Cadastrar
            // 
            this.menu_Consumidor_Cadastrar.Name = "menu_Consumidor_Cadastrar";
            this.menu_Consumidor_Cadastrar.Size = new System.Drawing.Size(125, 22);
            this.menu_Consumidor_Cadastrar.Text = "Cadastrar";
            this.menu_Consumidor_Cadastrar.Click += new System.EventHandler(this.menu_Consumidor_Cadastrar_Click);
            // 
            // menu_Consumidor_Consultar
            // 
            this.menu_Consumidor_Consultar.Name = "menu_Consumidor_Consultar";
            this.menu_Consumidor_Consultar.Size = new System.Drawing.Size(125, 22);
            this.menu_Consumidor_Consultar.Text = "Consultar";
            this.menu_Consumidor_Consultar.Click += new System.EventHandler(this.menu_Consumidor_Consultar_Click);
            // 
            // menu_Conta
            // 
            this.menu_Conta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Conta_Cadastrar,
            this.menu_Conta_Consultar});
            this.menu_Conta.Name = "menu_Conta";
            this.menu_Conta.Size = new System.Drawing.Size(51, 20);
            this.menu_Conta.Text = "Conta";
            // 
            // menu_Conta_Cadastrar
            // 
            this.menu_Conta_Cadastrar.Name = "menu_Conta_Cadastrar";
            this.menu_Conta_Cadastrar.Size = new System.Drawing.Size(125, 22);
            this.menu_Conta_Cadastrar.Text = "Cadastrar";
            this.menu_Conta_Cadastrar.Click += new System.EventHandler(this.menu_Conta_Cadastrar_Click);
            // 
            // menu_Conta_Consultar
            // 
            this.menu_Conta_Consultar.Name = "menu_Conta_Consultar";
            this.menu_Conta_Consultar.Size = new System.Drawing.Size(125, 22);
            this.menu_Conta_Consultar.Text = "Consultar";
            this.menu_Conta_Consultar.Click += new System.EventHandler(this.menu_Conta_Consultar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 263);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_Consumidor;
        private System.Windows.Forms.ToolStripMenuItem menu_Consumidor_Cadastrar;
        private System.Windows.Forms.ToolStripMenuItem menu_Consumidor_Consultar;
        private System.Windows.Forms.ToolStripMenuItem menu_Conta;
        private System.Windows.Forms.ToolStripMenuItem menu_Conta_Cadastrar;
        private System.Windows.Forms.ToolStripMenuItem menu_Conta_Consultar;
    }
}

