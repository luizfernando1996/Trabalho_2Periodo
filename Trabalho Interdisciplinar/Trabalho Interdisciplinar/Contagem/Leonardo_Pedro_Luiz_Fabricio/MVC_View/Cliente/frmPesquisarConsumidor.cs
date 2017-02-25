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

using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Bloco_de_Notas.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.XML.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Banco_de_Dados.Consumidor;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Cliente
{
    public partial class frmPesquisarConsumidor : Form
    {
        //atributo
        int flagNome = 1;

        private string strPathFileTempTxt = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Bloco_de_Notas/Consumidor/Consumidor.tmp";
        private string strPathFileTempXml = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Xml/Cliente/Consumidor.tmp";

        //inicializador do form
        public frmPesquisarConsumidor()
        {
            InitializeComponent();
            listViewResultadoConsum.View = View.Details;
            listViewResultadoConsum.GridLines = true;
            listViewResultadoConsum.Columns.Add("Nome: ", 100, HorizontalAlignment.Left);
            listViewResultadoConsum.Columns.Add("Pessoa: ", 80, HorizontalAlignment.Left);
            listViewResultadoConsum.Columns.Add("CPF/CNPJ: ", 200, HorizontalAlignment.Left);
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
                lblCPF.Visible = false;
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
                lblCPF.Visible = false;
            }
        }
        
        //buttons
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtMskCNPJ.Clear();
            txtMskCPF.Clear();
            txtNome.Clear();
            listViewResultadoConsum.Items.Clear();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pesquisar();
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            if (checkBox1.Checked)
                checkBox2.Checked = false;
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            if (checkBox2.Checked)
                checkBox1.Checked = false;
        }
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            //txtNome.CharacterCasing = CharacterCasing.Upper;
            //if ((e.KeyChar < 65) || (e.KeyChar > 90 && e.KeyChar < 97) || e.KeyChar > 122)
            //{
            //    //e.Handled = true;
            //    flagNome = 2;
            //}
            ////97--122--minusculo
            ////65 - 90--maiusculo
            ////Keys
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int arq;
            if (checkBox1.Checked)
                arq = 1;
            else
                arq = 2;
            pesquisarArq(arq);
            pictureBox1.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
        }
        //mskBox
        private void txtMskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                pesquisar();
        }
        private void txtMskCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                pesquisar();
        }


        //------------------métodos
        public void verificaTudo(ref string Nome, ref string Pessoa, ref string codigo, ref double flagCodigo)
        {
            flagNome = verfNome(ref Nome);
            //flagNome=0-->O nome foi digitado e se encontra na variavel Nome
            //flagNome=1-->O nome não foi digitado
            //flagNome=2-->O nome contem caracteres que não são letras

            Pessoa = verfPessoa();
            //Pessoa--->Atribui a Pessoa a string Pessoa Jurídica ou Pessoa Física

            codigo = null;
            flagCodigo = verfCod(ref codigo);
            //flagcodigo=0-->O codigo foi digitado e ele se encontra na variavel codigo
            //flagcodigo=1-->O cpf não foi digitado
            //flagcodigo=2-->O cnpj não foi digitado
        }
        public void pesquisar()
        {
            string Nome = "a", Pessoa = "b", codigo = "c";
            double flagCodigo=2;
            verificaTudo(ref Nome, ref Pessoa, ref codigo, ref flagCodigo);

            int erro = mensagemErro(flagNome, flagCodigo);
            //imprime uma mensagem se houver algum erro que somente ocorrera se alguma flag não conter 0
            if (erro == 0)
            {
                pictureBox1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
            }
        }
        public void pesquisarArq(int arq)
        {
            string Nome = "a", Pessoa = "b", codigo = "c";
            double flagCodigo = 2;
            verificaTudo(ref Nome, ref Pessoa, ref codigo, ref flagCodigo);

            int flagPessoaEncontrada = 1;
            if (flagNome == 0 && flagCodigo == 0)//Se o usuario digitou o nome e o codigo então irá busca-lo
                if (arq == 1)
                    flagPessoaEncontrada = pesquisarConsumidorXml(Nome, Pessoa, codigo);
                else
                    flagPessoaEncontrada = pesquisarConsumidorTxt(Nome, Pessoa, codigo);

            //flagPessoaEncontrada=0-->O codigo foi encontrado e ja foi adicionado na lista
            //flagPessoaEncontrada=1-->O codigo não foi encontrado

            //flagPessoaEncontrada = pesquisarConsumidorBanco(Nome, Pessoa, codigo);

            mensagemErro(flagNome, flagCodigo, flagPessoaEncontrada);
            //Se algum dos flags for diferente de 0 irá aparecer uma mensagem respectiva

            if (flagNome == 0 && flagCodigo == 0 && flagPessoaEncontrada == 0)
                Limpar();
            //se der tudo certo o campo nome e cpf/cnpj será limpo mas os resultados não
        }
        public int verfNome(ref string Nome)
        {
            if (txtNome.Text == "")// não se pode usar o método StartsWith aqui
            {
                flagNome = 1;
            }
            else
            {
                if (flagNome != 2)
                {
                    Nome = txtNome.Text;
                    flagNome = 0;
                }
            }
            return flagNome;
        }
        public string verfPessoa()
        {
            string Pessoa;
            if (rdbPessoaFisica.Checked)
            {
                Pessoa = "Pessoa Física";
            }
            else
                Pessoa = "Pessoa Jurídica";
            return Pessoa;

        }
        public double verfCod(ref string codigo)
        {
            double flagcodigo = 0;
            if (rdbPessoaFisica.Checked)
            {
                if (txtMskCPF.Text.StartsWith("   ,   ,   -"))//não foi informado o cpf
                {
                    flagcodigo = 1;
                }
                else
                {
                    int cont = 0;
                    foreach (char item in txtMskCPF.Text)
                    {
                        cont++;
                    }
                    if (cont == 14)
                        codigo = "CPF: " + txtMskCPF.Text;
                    else
                        flagcodigo = 1.1;
                }
            }
            else
            {
                if (txtMskCNPJ.Text.StartsWith("  ,   ,   /    -"))//não foi informado o cnpj
                {
                    flagcodigo = 2;
                }
                else
                {
                    int cont = 0;
                    foreach (char item in txtMskCNPJ.Text)
                    {
                        cont++;
                    }
                    if (cont == 18)
                        codigo = "CNPJ: " + txtMskCNPJ.Text;
                    else
                        flagcodigo = 2.1;
                }
            }
            return flagcodigo;
        }
        //<Procura na memoria>
        public int pesquisarConsumidorTxt(string nome, string pessoa, string codigo)
        {
            int flagPessoaEncontrada = 1;
            PessoaDAO pesqPessoa = new PessoaDAO();
            if (pessoa == "Pessoa Física")
                flagPessoaEncontrada = pesqPessoa.pesquisaPesFis(nome, pessoa, codigo);
            else
                flagPessoaEncontrada = pesqPessoa.pesquisaPesJurid(nome, pessoa, codigo);
            if (flagPessoaEncontrada == 0)
            {
                using (StreamReader ler = new StreamReader(strPathFileTempTxt))
                {

                    while (!ler.EndOfStream)
                    {
                        string leitura1 = ler.ReadLine();//lê o nome
                        string leitura2 = ler.ReadLine();//pessoa
                        string leitura3 = ler.ReadLine();//codigo
                                                         //escrever na lista
                        ListViewItem lista = new ListViewItem(leitura1);
                        lista.SubItems.Add(leitura2);
                        lista.SubItems.Add(leitura3);
                        listViewResultadoConsum.Items.Add(lista);
                        //adiciona na view lista desejada(listViewResultadoConsum) os itens leitura1...2..3
                    }

                }
            }
            pesqPessoa.apagarArqTemp();
            return flagPessoaEncontrada;
        }
        public int pesquisarConsumidorXml(string nome, string pessoa, string codigo)
        {
            int flagPessoaEncontrada = 1;
            PessoaFisicaDAO objPessoaFis = new PessoaFisicaDAO();
            PessoaJuridicaDAO objPessoaJur = new PessoaJuridicaDAO();

            if (pessoa == "Pessoa Física")
                flagPessoaEncontrada = objPessoaFis.pesqPessoaFis(nome, pessoa, codigo);//(nome, pessoa, codigo);
            else
                flagPessoaEncontrada = objPessoaJur.pesqPessoaJur(nome, pessoa, codigo);//(nome, pessoa, codigo);
            if (flagPessoaEncontrada == 0)
            {
                using (StreamReader ler = new StreamReader(strPathFileTempXml))
                {

                    while (!ler.EndOfStream)
                    {
                        string leitura1 = ler.ReadLine();//lê o nome
                        string leitura2 = ler.ReadLine();//pessoa
                        string leitura3 = ler.ReadLine();//codigo
                        //escreve na lista
                        ListViewItem lista = new ListViewItem(leitura1);
                        lista.SubItems.Add(leitura2);
                        lista.SubItems.Add(leitura3);
                        listViewResultadoConsum.Items.Add(lista);
                        //adiciona na view lista desejada(listViewResultadoConsum) os itens leitura1...2..3
                    }

                }
            }
            objPessoaJur.apagarArqTemp();
            //o arquivo temporario para ambas as pessoas é o mesmo endereço. Logo se uma pessoa apagar ela apaga para as duas
            return flagPessoaEncontrada;
        }
        public int pesquisarConsumidorBanco(string nome, string pessoa, string codigo)
        {
            int flagPessoaEncontrada = 1;
            try
            {
                PessoaFisDAO objPessoaFis = new PessoaFisDAO();
                PessoaJuriDAO objPessoaJur = new PessoaJuriDAO();
                if (pessoa == "Pessoa Física")
                {
                    objPessoaFis.conectar();
                    flagPessoaEncontrada = objPessoaFis.pesqPessoaFis(nome, pessoa, codigo);//(nome, pessoa, codigo);
                }
                else
                {
                    objPessoaJur.conectar();
                    flagPessoaEncontrada = objPessoaJur.pesqPessoaJur(nome, pessoa, codigo);//(nome, pessoa, codigo);
                }
                if (flagPessoaEncontrada == 0)
                {
                    //escreve no datagried view
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flagPessoaEncontrada;
        }
        //</Procura na memoria>
        private int mensagemErro(int flagNome, double flagCodigo)
        {
            int erro = 0;
            if (flagNome == 0 && flagCodigo == 1)
            {
                MessageBox.Show("Informe o cpf do cliente");
                erro = 1;
            }
            else if (flagNome == 0 && flagCodigo == 1.1)
            {
                MessageBox.Show("Informe todo o cpf do cliente (11 digitos)");
                erro = 1;
            }
            else if ((flagNome == 0 && flagCodigo == 2))
            {
                MessageBox.Show("Informe o cnpj do cliente");
                erro = 1;
            }
            else if (flagNome == 0 && flagCodigo == 2.1)
            {
                MessageBox.Show("Informe todo o cnpj do cliente (14digitos)");
                erro = 1;
            }
            else if (flagNome == 1 && flagCodigo == 0)
            {
                MessageBox.Show("Informe o nome do cliente");
                erro = 1;
            }
            else if (flagNome == 1 && flagCodigo == 1)
            {
                MessageBox.Show("Informe o nome e cpf do cliente");
                erro = 1;
            }
            else if (flagNome == 1 && flagCodigo == 1.1)
            {
                MessageBox.Show("Informe o nome e todo o cpf do cliente (11 digitos)");
                erro = 1;
            }
            else if (flagNome == 1 && flagCodigo == 2)
            {
                MessageBox.Show("Informe o nome e cnpj do cliente");
                erro = 1;
            }
            else if (flagNome == 1 && flagCodigo == 2.1)
            {
                MessageBox.Show("Informe o nome e todo o cnpj do cliente (14digitos)");
                erro = 1;
            }
            return erro;
        }
        private void mensagemErro(int flagNome, double flagCodigo, int flagPessoaEncontrada)
        {
            //flagNome==0 &&flagCodigo==0--->procura o consumidor 
            if ((flagCodigo == 0) && (flagNome == 0) && flagPessoaEncontrada == 1)
                MessageBox.Show("Não foi encontrado este consumidor!");
            //else if (flagNome == 2)
            //{
            //    MessageBox.Show("Insira no campo nome apenas letras");
            //    flagNome = 1;
            //}
        }
        public void Limpar()
        {
            txtNome.Clear();
            txtMskCNPJ.Clear();
            txtMskCPF.Clear();
        }
    }

}

