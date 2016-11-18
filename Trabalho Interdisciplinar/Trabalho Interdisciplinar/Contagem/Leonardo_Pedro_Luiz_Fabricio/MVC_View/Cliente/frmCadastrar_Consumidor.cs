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
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.XML.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Banco_de_Dados;
//foi alterado o parametro CharacterCasing para Upper
//se digitar r6 e apagar o 6 ai vou ter que apertar 2x o botao cadastrar

//Sempre colocar Mtd ou Atrb mais o nome da classe
//Sempre colocar flags como double mas tentar atribuir para todas elas valores inteiros porque se houver alguma correção
//para ser feita posteriormente será mt facil acrescentar novos valores entre dois numeros.


//o método cadastrar ja limpa o arquivo, porque?
namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Cliente
{
    public partial class frmCadastrar_Consumidor : Form
    {
        //atributo
        int flagNome = 1;

        //caminho do arquivo
        private string strPathFile = @"C:/Users/Admin/Desktop/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Bloco_de_Notas/Consumidores.txt";


        //inicializador do form
        public frmCadastrar_Consumidor()
        {
            InitializeComponent();
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
            Limpar();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cadastrarArqTxt();

        }
        //textbox
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar!=8)&&(e.KeyChar < 65) || (e.KeyChar > 90 && e.KeyChar < 97) || (e.KeyChar > 122)&&(e.KeyChar!=231))
            //{
            //    e.Handled = true;
            //    flagNome = 2;
            //}
            //else
            //    e.Handled = false;
            ////65 as 90 são os valores de A até Z
            ////97--122--minusculo
            ////8 = <--
            ////231==ç
            ////Keys//-->apertar f12 no keys que você encontra os codigos
        }
        //mskBox
        private void txtMskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cadastrarArqTxt();
        }
        private void txtMskCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cadastrarArqTxt();
        }

        //------------------métodos
        private void cadastrarArqTxt()
        {
            //flags
            double flagcodigo = 0;

            string nome = "a";
            flagNome = verfNome(ref nome);
            //flagnome=0-->O nome foi digitado e se encontra em Nome
            //flagnome=1-->O nome não foi digitado
            //flagnome=2-->O nome possui caracteres que não são letras

            string pessoa = verfPessoa();
            //Pessoa--->Atribui a Pessoa a string Pessoa Jurídica ou Pessoa Física

            string codigo = null;
            flagcodigo = verfCod(ref codigo);
            //flagcodigo=0-->O codigo foi digitado e ele se encontra na variavel codigo
            //flagcodigo=1-->O cpf não foi digitado
            //flagcodigo=2-->O cnpj não foi digitado

            if (flagNome == 0 && flagcodigo == 0)//escreve no arquivo se as duas flags forem 0
            {
                escrArqBlocoNotas(nome, pessoa, codigo);
                escreverArqXml(pessoa,nome, codigo);
                escreverArqBanco();
                Limpar();
            }
            mensagemErro(flagNome, flagcodigo);//imprime uma mensagem se alguma flag não conter 0

        }
        private int verfNome(ref string nome)
        {
            if (txtNome.Text == "")//não se pode usar o método StartsWith aqui
                flagNome = 1;
            else
            {
                if (flagNome != 2)
                {
                    nome = txtNome.Text;
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
        private double verfCod(ref string codigo)
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

        //  <MODEL>
        private void escrArqBlocoNotas(string nome, string pessoa, string codigo)
        {
            using (StreamWriter sw = File.AppendText(strPathFile))
            {
                sw.WriteLine(nome);
                sw.WriteLine(pessoa);
                sw.WriteLine(codigo);
                sw.WriteLine("______________________________");
                MessageBox.Show("Cadastro efetuado com sucesso");
            }
        }
        private void escreverArqXml(string pessoa,string nome, string codigo)
        {
            if (pessoa.StartsWith("Pessoa Física"))
            {
                PessoaFisicaDAO clntPF = new PessoaFisicaDAO();
                Pessoa_Fisica pf = new Pessoa_Fisica()
                {
                    nome_MtdPessoaF = nome,
                    cpf_MtdPessoaF = codigo
                };
                clntPF.adicionar_MtdPessoaFisicaDAO(pf);
                // clnt.carregar_MtdClienteDAO();
                clntPF.salvar_MtdPessoaFisicaDAO();
            }
            else
            {
                PessoaJuridicaDAO clntPJ = new PessoaJuridicaDAO();
                Pessoa_Juridica pj = new Pessoa_Juridica()
                {
                    nome_MtdPessoaJ = nome,
                    cnpj_MtdPessoaJ = codigo
                };
                clntPJ.adicionar_MtdPessoaFisicaDAO(pj);
                // clnt.carregar_MtdClienteDAO();
                clntPJ.salvar_MtdPessoaFisicaDAO();
            }
            
        }
        private void escreverArqBanco()
        {
            DAL dao = new DAL();
            try
            {
                dao.Conectar();
                dao.Inserir(txtMskCPF.Text, txtMskCNPJ.Text, txtNome.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// </MODEL>

        private void mensagemErro(int flagNome, double flagcodigo)
        {
            //flagNome==0&& flagcodigo==0--->escreve no arquivo e la mostra a mensagem Sucesso
            if (flagNome == 0 && flagcodigo == 1)
                MessageBox.Show("Informe o cpf");
            else if (flagNome == 0 && flagcodigo == 1.1)
                MessageBox.Show("Informe todo o cpf(11 digitos)");
            else if (flagNome == 0 && flagcodigo == 2)
                MessageBox.Show("Informe o cnpj");
            else if (flagNome == 0 && flagcodigo == 2.1)
                MessageBox.Show("Informe todo o cnpj(14digitos)");
            else if (flagNome == 1 && flagcodigo == 0)
                MessageBox.Show("Informe o nome");
            else if (flagNome == 1 && flagcodigo == 1)
                MessageBox.Show("Informe o nome e o cpf");
            else if (flagNome == 1 && flagcodigo == 1.1)
                MessageBox.Show("Informe o nome e todo o cpf(11 digitos)");
            else if (flagNome == 1 && flagcodigo == 2)
                MessageBox.Show("Informe o nome e o cnpj");
            else if (flagNome == 1 && flagcodigo == 2.1)
                MessageBox.Show("Informe o nome e todo o cnpj(14digitos)");
            //else if (flagNome == 2)
            //{
            //    MessageBox.Show("O campo nome só pode ter letras");
            //    flagNome = 1;
            //    //Codigo para que o programa após o digito de um numero, por exemplo, não repita 
            //    //a mensagem para outros nomes informados
            //}
        }
        private void Limpar()
        {
            //testando
            txtMskCNPJ.Clear();
            txtMskCPF.Clear();
            txtNome.Clear();
        }
    }
}
