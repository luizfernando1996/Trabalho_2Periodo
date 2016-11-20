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

using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Bloco_de_Notas.Conta;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.XML.Contas;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Banco_de_Dados.Conta;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Conta
{
    public partial class frmPesquisarConta : Form
    {
        //caminho do arquivo
        private string strPathFileTemp = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Bloco_de_Notas/Contas/Conta.tmp";
        private string strPathFileTemp1 = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Xml/Contas/Conta.tmp";

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
            string pessoa = null;
            pessoa = verfPessoa();

            string codigo = null;
            int flagCodigo = 1;
            flagCodigo = verfCod(ref codigo);
            //flagcodigo=0-->O codigo foi digitado e a variavel codigo está com ele
            //flagcodigo=1-->O cpf não foi digitado
            //flagcodigo=2-->O cnpj não foi digitado


            int flagCodigoEncontrado = 1;
            if (flagCodigo == 0)//só pesquisa se o usuario digitar um cpf ou cnpj
            //flagCodigoEncontrado = pesquisaContaTxt(pessoa, codigo);
           //flagCodigoEncontrado = pesquisaContaXml(pessoa, codigo);
                flagCodigoEncontrado = pesquisaContaBanco(pessoa, codigo);

            //flagcodigoencontrado=0-->O codigo foi encontrado
            //flagcodigoencontrado=1-->O codigo não foi encontrado

            mensagemErro(flagCodigoEncontrado, flagCodigo);
            //imprime mensagem de erro se alguma flag não for 0
        }
        public string verfPessoa()
        {
            string pessoa;
            if (rdbPessoaFisica.Checked)
            {
                pessoa = "Pessoa Física";
            }
            else
                pessoa = "Pessoa Jurídica";
            return pessoa;
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
        private int pesquisaContaTxt(string pessoa, string codigo)
        {
            ContaDAO cntDAO = new ContaDAO();
            int flagCodigoEncontrado = 1;

            //pesquisa na respectiva conta o codigo
            if (pessoa == "Pessoa Jurídica")
                flagCodigoEncontrado = cntDAO.pesquisarContaCom(codigo);
            else
                flagCodigoEncontrado = cntDAO.pesquisarContaRes(codigo);


            if (flagCodigoEncontrado == 0)
            {
                using (StreamReader ler = new StreamReader(strPathFileTemp))
                {
                    string leitura, leitura2;
                    while (!ler.EndOfStream)
                    {
                        leitura = ler.ReadLine();//lê o cpf
                        leitura2 = ler.ReadLine();//lê o valor da conta
                        ListViewItem lista = new ListViewItem(leitura);
                        lista.SubItems.Add(leitura2);
                        listViewResultadoConta.Items.Add(lista);
                        //adiciona na view lista desejada(listViewResultadoConsum) os itens leitura e leitura 2
                    }
                }//fim do using
            }
            cntDAO.apagarArqTemp();
            return flagCodigoEncontrado;
        }
        private int pesquisaContaXml(string pessoa, string codigo)
        {
            ContaComercialDAO cntComDAO = new ContaComercialDAO();
            ContaResidencialDAO cntResDAO = new ContaResidencialDAO();

            int flagCodigoEncontrado = 1;

            //pesquisa na respectiva conta o codigo
            if (pessoa == "Pessoa Jurídica")
                flagCodigoEncontrado = cntComDAO.pesquisarContaCom(codigo);
            else
                flagCodigoEncontrado = cntResDAO.pesquisarContaRes(codigo);


            if (flagCodigoEncontrado == 0)
            {
                using (StreamReader ler = new StreamReader(strPathFileTemp1))
                {
                    string leitura, leitura2;
                    while (!ler.EndOfStream)
                    {
                        leitura = ler.ReadLine();//lê o codigo
                        leitura2 = ler.ReadLine();//lê o valor da conta
                        ListViewItem lista = new ListViewItem(leitura);
                        lista.SubItems.Add(leitura2);
                        listViewResultadoConta.Items.Add(lista);
                        //adiciona na view lista desejada(listViewResultadoConsum) os itens leitura e leitura 2
                    }
                }//fim do using
            }
            cntComDAO.apagarArqTemp();
            //o arquivo temporario das duas contas possui o mesmo endereço.
            //Logo o processo de de exclusão apaga o arquivo temp das duas ontas
            return flagCodigoEncontrado;
        }
        private int pesquisaContaBanco(string pessoa, string codigo)
        {
            ContaResDAO objPessoaFis = new ContaResDAO();
            ContaComDAO objPessoaJur = new ContaComDAO();

            int flagCodigoEncontrado = 1;

            //pesquisa na respectiva conta o codigo
            if (pessoa == "Pessoa Jurídica")
                flagCodigoEncontrado = objPessoaJur.pesquisarContaCom(codigo);
            else
                flagCodigoEncontrado = objPessoaFis.pesquisarContaRes(codigo);

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
