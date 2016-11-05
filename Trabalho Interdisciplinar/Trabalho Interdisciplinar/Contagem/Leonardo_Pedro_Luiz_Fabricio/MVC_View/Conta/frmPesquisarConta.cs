using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Conta
{
    public partial class frmPesquisarConta : Form
    {
        //caminho do arquivo
        private string strPathFile = @"C:/Users/Admin/Desktop/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivos/Contas.txt";

        //inicializador do form
        public frmPesquisarConta()
        {
            InitializeComponent();
            listViewResultadoConta.View = View.Details;
            listViewResultadoConta.GridLines = true;
            listViewResultadoConta.Columns.Add("CPF/CNPJ: ", 130, HorizontalAlignment.Left);
            listViewResultadoConta.Columns.Add("Valor da Conta: ", 200, HorizontalAlignment.Left);
            //listViewResultadoConta.Columns.Add("", 150, HorizontalAlignment.Left);
        }

        //------------------eventos
        //radiobuttons
        private void rdbPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPessoaFisica.Checked == true)
            {
                lblCnpj.Visible = false;
                lblCPF.Visible = true;
                txtMskCPF.Visible = true;
                txtMskCNPJ.Visible = false;
            }
            else if (rdbPessoaJuridica.Checked == true)
            {
                txtMskCPF.Visible = false;
                txtMskCNPJ.Visible = true;
                lblCnpj.Visible = true;
            }
        }
        private void rdbPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbPessoaFisica.Checked == true)
            {
                lblCnpj.Visible = false;
                lblCPF.Visible = true;
                txtMskCPF.Visible = true;
                txtMskCNPJ.Visible = false;
            }
            else if (rdbPessoaJuridica.Checked == true)
            {
                txtMskCPF.Visible = false;
                txtMskCNPJ.Visible = true;
                lblCnpj.Visible = true;
            }
        }
        //button
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        //------------------métodos
        private void Limpar()
        {
            txtMskCNPJ.Clear();
            txtMskCPF.Clear();
            listViewResultadoConta.Items.Clear();
        }
        private void Pesquisar()
        {
            string codigo = null;
            int flagCodigo = 1;
            flagCodigo = verfCod(ref codigo);
            //flagcodigo=0-->O codigo foi digitado e a variavel codigo está com ele
            //flagcodigo=1-->O cpf não foi digitado
            //flagcodigo=2-->O cnpj não foi digitado


            int flagCodigoEncontrado = 1;
            if (flagCodigo == 0)//só pesquisa se o usuario digitar um cpf ou cnpj
                flagCodigoEncontrado = pesquisaConta(codigo);
            //flagcodigoencontrado=0-->O codigo foi encontrado
            //flagcodigoencontrado=1-->O codigo não foi encontrado

            mensagemErro(flagCodigoEncontrado, flagCodigo);
            //imprime mensagem de erro se alguma flag não for 0
        }
        private int verfCod(ref string codigo)
        {
            int flagcodigo = 0;
            if (rdbPessoaFisica.Checked)
            {
                if (txtMskCPF.Text.StartsWith("   ,   ,   -"))//não foi informado o cpf
                {
                    flagcodigo = 1;
                }
                else
                    codigo = "CPF: " + txtMskCPF.Text;

            }
            else
            {
                if (txtMskCNPJ.Text.StartsWith("  ,   ,   /    -"))//não foi informado o cnpj
                {
                    flagcodigo = 2;
                }
                else
                    codigo = "CNPJ: " + txtMskCNPJ.Text;
            }
            return flagcodigo;
        }
        private int pesquisaConta(string codigo)
        {
            int flagCodigoEncontrado = 1;
            using (StreamReader ler = new StreamReader(strPathFile))
            {
                string leitura, leitura2,leitura3;
                while (!ler.EndOfStream)
                {
                    leitura = ler.ReadLine();//lê o cpf
                    ler.ReadLine();//lê a leitura Atual
                    ler.ReadLine();//lê a leitura Anterior
                    leitura2 = ler.ReadLine();//lê o valor da conta
                    leitura3=ler.ReadLine();//lê o _____
                // if (String.IsNullOrEmpty(leitura3))
                    if (leitura3 != null)
                        if (leitura.Equals(codigo))
                        {
                            flagCodigoEncontrado = 0;
                            ListViewItem lista = new ListViewItem(leitura);
                            lista.SubItems.Add(leitura2);
                            listViewResultadoConta.Items.Add(lista);
                            //adiciona na view lista desejada(listViewResultadoConsum) os itens leitura e leitura 2
                        }
                }
            }//fim do using
            return flagCodigoEncontrado;
        }
        private void mensagemErro(int flagcodigoencontrado, int flagcodigo)
        {
            if (flagcodigoencontrado == 1 && flagcodigo == 0)
            {
                MessageBox.Show("Não foram encontrados resultados para este código");
            }
            else if (flagcodigoencontrado == 1 && flagcodigo == 1)
                MessageBox.Show("Informe o cpf");
            else if (flagcodigoencontrado == 1 && flagcodigo == 2)
                MessageBox.Show("Informe o cnpj");
        }
    }
}
