using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Cliente;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Conta;

namespace Trabalho_Interdisciplinar
{
    public partial class Form1 : Form
    {
        //inicializador do form
        public Form1()
        {
            InitializeComponent();
        }

        //eventos de transição de janelas
        private void menu_Consumidor_Cadastrar_Click(object sender, EventArgs e)
        {
            frmCadastrar_Consumidor tela = new frmCadastrar_Consumidor();
            tela.ShowDialog();
        }
        private void menu_Consumidor_Consultar_Click(object sender, EventArgs e)
        {
            frmPesquisarConsumidor tela = new frmPesquisarConsumidor();
            tela.ShowDialog();
        }
        private void menu_Conta_Cadastrar_Click(object sender, EventArgs e)
        {
            frmCadastrarConta tela = new frmCadastrarConta();
            tela.ShowDialog();
        }
        private void menu_Conta_Consultar_Click(object sender, EventArgs e)
        {
            frmPesquisarConta tela = new frmPesquisarConta();
            tela.ShowDialog();
        }


    }
}
