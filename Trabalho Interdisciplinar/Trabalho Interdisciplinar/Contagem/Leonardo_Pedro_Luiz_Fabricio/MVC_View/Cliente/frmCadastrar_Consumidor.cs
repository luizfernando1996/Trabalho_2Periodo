using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Bloco_de_Notas.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.XML.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Banco_de_Dados.Consumidor;
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
            cadastrar();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int arq;
            if (checkBox1.Checked)
                arq = 1;
            else
                arq = 2;
            cadastrarArq(arq);
            pictureBox1.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;

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
        //textbox
        //private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if ((e.KeyChar != 8) && (e.KeyChar < 65) || (e.KeyChar > 90 && e.KeyChar < 97) || (e.KeyChar > 122) && (e.KeyChar != 231))
        //    {
        //        e.Handled = true;
        //        flagNome = 2;
        //    }
        //    else
        //        e.Handled = false;
        //    //65 as 90 são os valores de A até Z
        //    //97--122--minusculo
        //    //8 = <--
        //    //231==ç
        //    //Keys//-->apertar f12 no keys que você encontra os codigos
        //}
        //mskBox
        private void txtMskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cadastrar();
        }
        private void txtMskCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cadastrar();
        }

        //------------------métodos
        private void cadastrar()
        {
            double flagcodigo = 0;
            string nome = "a", pessoa = "a", codigo = "b";

            verificaTudo(ref flagcodigo, ref nome, ref flagNome, ref pessoa, ref codigo);

            int erro = confErroSeHouverInforma(flagNome, flagcodigo);
            //imprime uma mensagem se houver algum erro que somente ocorrera se alguma flag não conter 0
            if (erro == 0)
            {
                pictureBox1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
            }
        }
        private void verificaTudo(ref double flagcodigo,ref string nome,ref int flagNome,ref string pessoa,ref string codigo)
        {             //flags
            flagcodigo = 0;

            nome = "a";
            flagNome = verfNome(ref nome);
            //flagnome=0-->O nome foi digitado e se encontra em Nome
            //flagnome=1-->O nome não foi digitado
            //flagnome=2-->O nome possui caracteres que não são letras

            pessoa = verfPessoa();
            //Pessoa--->Atribui a Pessoa a string Pessoa Jurídica ou Pessoa Física

            codigo = null;
            flagcodigo = verfCod(ref codigo);
            //flagcodigo=0-->O codigo foi digitado e ele se encontra na variavel codigo
            //flagcodigo=1-->O cpf não foi digitado
            //flagcodigo=2-->O cnpj não foi digitado
        } 
        private void cadastrarArq(int arquivo)
        {
            double flagcodigo = 0;
            string nome = "a", pessoa = "a", codigo = "b";

            verificaTudo(ref flagcodigo, ref nome, ref flagNome, ref pessoa, ref codigo);
            if (flagNome == 0 && flagcodigo == 0)//escreve no arquivo se as duas flags forem 0
            {
                if(arquivo==1)
                    escreverArqXml(nome, pessoa, codigo);
                else
                    escrArqBlocoNotas(nome, pessoa, codigo);
                //escreverArqBanco(nome, pessoa, codigo);
                Limpar();
            }
            confErroSeHouverInforma(flagNome, flagcodigo);

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

        //  <persistencia>>
        private void escrArqBlocoNotas(string nome, string pessoa, string codigo)
        {
            PessoaDAO consDAO = new PessoaDAO();
            if (pessoa == "Pessoa Física")
                consDAO.escreverPessoaFisica(nome, pessoa, codigo);
            else
                consDAO.escreverPessoaJuridica(nome, pessoa, codigo);
            MessageBox.Show("Cadastro efetuado com sucesso no bloco de notas");
        }
        private void escreverArqXml(string nome, string pessoa, string codigo)
        {
            if (pessoa.StartsWith("Pessoa Física"))
            {
                PessoaFisicaDAO clntPF = new PessoaFisicaDAO();
                clntPF.carregar_MtdPessoaFisicaDAO();//antes de adicionar é melhor carregar
                Pessoa_Fisica pf = new Pessoa_Fisica()
                {
                    nome_MtdPessoaF = nome,
                    cpf_MtdPessoaF = codigo
                };
                clntPF.adicionar_MtdPessoaFisicaDAO(pf);
                clntPF.salvar_MtdPessoaFisicaDAO();
            }
            else
            {
                PessoaJuridicaDAO clntPJ = new PessoaJuridicaDAO();
                clntPJ.carregar_MtdPessoaJuridicaDAO();
                Pessoa_Juridica pj = new Pessoa_Juridica()
                {
                    nome_MtdPessoaJ = nome,
                    cnpj_MtdPessoaJ = codigo
                };
                clntPJ.adicionar_MtdPessoaJuridicaDAO(pj);
                // clnt.carregar_MtdClienteDAO();
                clntPJ.salvar_MtdPessoaJuridicaDAO();
            }
            MessageBox.Show("Conta cadastrada com sucesso no xml");

        }
        private void escreverArqBanco(string nome, string pessoa, string codigo)
        {
            try
            {
                if (pessoa.StartsWith("Pessoa Física"))
                {
                    PessoaFisDAO objPesFis = new PessoaFisDAO();
                    objPesFis.conectar();
                    objPesFis.inserir(nome, pessoa, codigo);
                }
                else
                {
                    PessoaJuriDAO objPesJur = new PessoaJuriDAO();
                    objPesJur.conectar();
                    objPesJur.inserir(nome, pessoa, codigo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            MessageBox.Show("Cliente cadastrado com sucesso no banco de dados");

        }
        /// </persistencia>

        private int confErroSeHouverInforma(int flagNome, double flagcodigo)
        {
            int erro = 0;
            //flagNome==0&& flagcodigo==0--->escreve no arquivo e la mostra a mensagem Sucesso
            if (flagNome == 0 && flagcodigo == 1)
            {
                MessageBox.Show("Informe o cpf");
                erro = 1;
            }
            else if (flagNome == 0 && flagcodigo == 1.1)
            {
                MessageBox.Show("Informe todo o cpf(11 digitos)");
                erro = 1;
            }
            else if (flagNome == 0 && flagcodigo == 2)
            {
                MessageBox.Show("Informe o cnpj");
                erro = 1;
            }
            else if (flagNome == 0 && flagcodigo == 2.1)
            {
                MessageBox.Show("Informe todo o cnpj(14digitos)");
                erro = 1;
            }
            else if (flagNome == 1 && flagcodigo == 0)
            {
                MessageBox.Show("Informe o nome");
                erro = 1;
            }
            else if (flagNome == 1 && flagcodigo == 1)
            {
                MessageBox.Show("Informe o nome e o cpf");
                erro = 1;
            }
            else if (flagNome == 1 && flagcodigo == 1.1)
            {
                MessageBox.Show("Informe o nome e todo o cpf(11 digitos)");
                erro = 1;
            }
            else if (flagNome == 1 && flagcodigo == 2)
            {
                MessageBox.Show("Informe o nome e o cnpj");
                erro = 1;
            }
            else if (flagNome == 1 && flagcodigo == 2.1)
            {
                MessageBox.Show("Informe o nome e todo o cnpj(14digitos)");
                erro = 1;
            }
            //else if (flagNome == 2)
            //{
            //    MessageBox.Show("O campo nome só pode ter letras");
            //    flagNome = 1;
            //    //Codigo para que o programa após o digito de um numero, por exemplo, não repita 
            //    //a mensagem para outros nomes informados
            //}
            return erro;
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
