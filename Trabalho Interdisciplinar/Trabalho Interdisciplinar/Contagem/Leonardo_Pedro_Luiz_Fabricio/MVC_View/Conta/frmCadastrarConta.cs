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

//classes
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Tarifa;
//dal
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Bloco_de_Notas.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Bloco_de_Notas.Conta;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.XML.Contas;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.XML.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Banco_de_Dados.Consumidor;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Banco_de_Dados.Conta;


//Os nomes das pastas possuem MVC antes para evitar o erro de referencia
//Este erro de referencia ocorre porque um dos atributos da listView é um atrbituo chamado View e desta forma
//quando se coloca o nome da pasta de view o programa não consegue saber qual dos dois definir.

//Math.Round
//O método acima faz o arrendondamento do valor para quantas casas decimais o usuario desejar.

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Conta
{
    public partial class frmCadastrarConta : Form
    {

        //inicializador do form
        public frmCadastrarConta()
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

        //------------------métodos
        private void Limpar()
        {
            txtMskCNPJ.Clear();
            txtMskCPF.Clear();
            txtLeituraAnterior.Clear();
            txtLeituraAtual.Clear();
        }
        private void cadastrar()
        {
            string pessoa = verfPessoa();
            //Pessoa--->Atribui a Pessoa a string Pessoa Jurídica ou Pessoa Física

            string codigo = null;
            int flagCodigo = 0;
            flagCodigo = verfDigitouCpf_Cnpj(ref codigo);
            //Valor 0---> Foi informado o codigo e ele se encontra em codigo
            //Valor 1---> Não foi informado cpf
            //Valor 2---> Não foi informado cnpj

            int flagLeitura = 0;
            double leituraAtual = 0, leituraAnterior = 0;
            flagLeitura = verfLeitura(ref leituraAnterior, ref leituraAtual);
            //Valor 0--->Ambos os campos foram preenchidos e os seus valores se encontram em leituraAtual e leituraAnterior
            //Valor 1--->O campo Leitura Atual não foi preenchido
            //Valor 2--->O campo Leitura Anterior não foi preenchido
            //Valor 3--->Ambos os campos não foram preenchidos
            //Valor 4--->Algum dos campos não foi preenchido com números

            int flagCodigoCadastrado = 1;
            string nomeLido = null;
            if (flagCodigo == 0)
                flagCodigoCadastrado = procuraCodigoTxt(ref nomeLido, pessoa, codigo);
            //flagcodigocadastrado=0---> O cliente foi cadastrado
            //flagcodigocadastrado=1---> O cliente ainda não foi cadastrado
            int erro = 0;
            erro = confErroSeHouverInforma(flagCodigo, flagLeitura, flagCodigoCadastrado);
            //imprime uma mensagem se houver algum erro que somente ocorrera se alguma flag não conter 0
            if (erro == 0)
            {
                pictureBox1.Visible = true;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
            }
        }
        public void cadastrarArq(int arq)
        {
            string pessoa = verfPessoa();
            //Pessoa--->Atribui a Pessoa a string Pessoa Jurídica ou Pessoa Física

            string codigo = null;
            int flagCodigo = 0;
            flagCodigo = verfDigitouCpf_Cnpj(ref codigo);
            //Valor 0---> Foi informado o codigo e ele se encontra em codigo
            //Valor 1---> Não foi informado cpf
            //Valor 2---> Não foi informado cnpj

            int flagLeitura = 0;
            double leituraAtual = 0, leituraAnterior = 0;
            flagLeitura = verfLeitura(ref leituraAnterior, ref leituraAtual);
            //Valor 0--->Ambos os campos foram preenchidos e os seus valores se encontram em leituraAtual e leituraAnterior
            //Valor 1--->O campo Leitura Atual não foi preenchido
            //Valor 2--->O campo Leitura Anterior não foi preenchido
            //Valor 3--->Ambos os campos não foram preenchidos
            //Valor 4--->Algum dos campos não foi preenchido com números

            int flagcodigocadastrado = 1;
            string nomeLido = null;
            if (flagCodigo == 0)
                flagcodigocadastrado = procuraCodigoTxt(ref nomeLido, pessoa, codigo);
            //flagcodigocadastrado=0---> O cliente foi cadastrado
            //flagcodigocadastrado=1---> O cliente ainda não foi cadastrado

            if (flagcodigocadastrado == 0 && flagLeitura == 0)
            //Se flagcodigocadastrado=0 então flagCodigo=0
            {
                double num = sincroniaConta_Consumidor(pessoa, codigo, nomeLido, leituraAtual, leituraAnterior);
                if (arq == 1)
                    cadastrarContaXml(pessoa, codigo, leituraAtual, leituraAnterior, num);
                else
                    cadastrarContaTxt(pessoa, codigo, leituraAtual, leituraAnterior, num);

                //cadastrarContaBanco(pessoa, codigo, leituraAtual, leituraAnterior, num);
            }
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
        public int verfDigitouCpf_Cnpj(ref string codigo)
        {
            //string codigo,pessoa;
            int flagcodigo = 0;
            if (rdbPessoaFisica.Checked)
            {
                if (txtMskCPF.Text.StartsWith("   ,   ,   -"))
                {
                    flagcodigo = 1;//não foi informado o cpf
                }
                else
                    codigo = "CPF: " + txtMskCPF.Text;
            }
            else
            {
                if (txtMskCNPJ.Text.StartsWith("  ,   ,   /    -"))
                {
                    flagcodigo = 2;//não foi informado o cnpj
                }
                else
                    codigo = "CNPJ: " + txtMskCNPJ.Text;
            }
            return flagcodigo;
        }
        public int verfLeitura(ref double leituraAnterior, ref double leituraAtual)
        {
            int flagLeitura = 0;
            if (txtLeituraAtual.Text == "")
                flagLeitura = 1;
            //if (txtLeituraAnterior.Text == "")
            // flagLeitura = 2;
            if (txtLeituraAnterior.Text == string.Empty)
                flagLeitura = 2;
            if (txtLeituraAnterior.Text == "" && txtLeituraAtual.Text == "")
                flagLeitura = 3;
            if (flagLeitura == 0)
            {
                try
                {
                    leituraAtual = double.Parse(txtLeituraAtual.Text);
                    leituraAnterior = double.Parse(txtLeituraAnterior.Text);
                }
                catch (FormatException)
                {
                    flagLeitura = 4;
                    //throw;pra qe isto?
                }
            }

            return flagLeitura;
        }

        //<pesquisa na memoria>
        public int procuraCodigoTxt(ref string nomeLido, string pessoa, string codigo)
        {
            int flagcodigocadastrado = 1;

            PessoaDAO consDAO = new PessoaDAO();
            if (pessoa == "Pessoa Física")
                flagcodigocadastrado = consDAO.procuraCodigoPesFisica(ref nomeLido, pessoa, codigo);
            else
                flagcodigocadastrado = consDAO.procuraCodigoPesJur(ref nomeLido, pessoa, codigo);

            return flagcodigocadastrado;
        }
        //public int procuraCodigoXml(ref string nomeLido, string pessoa, string codigo)
        //{
        //    int flagcodigocadastrado = 1;

        //    PessoaDAO consDAO = new PessoaDAO();
        //    flagcodigocadastrado = consDAO.pesquisaConsPraConta(ref nomeLido, pessoa, codigo);

        //    return flagcodigocadastrado;

        //}
        public int procuraCodigoBanco(ref string nomeLido, string pessoa, string codigo)
        {
            int flagcodigocadastrado = 1;

            PessoaFisDAO objPesFis = new PessoaFisDAO();
            PessoaJuriDAO objPesJur = new PessoaJuriDAO();

            if (pessoa == "Pessoa Física")
                flagcodigocadastrado = objPesFis.procuraCodigoPesFisica(ref nomeLido, pessoa, codigo);
            else
                flagcodigocadastrado = objPesJur.procuraCodigoPesJur(ref nomeLido, pessoa, codigo);

            return flagcodigocadastrado;
        }
        //<pesquisa na memoria>

        public double sincroniaConta_Consumidor(string pessoa, string codigo, string nomeLido, double leituraAtual, double leituraAnterior)
        {
            //referencias
            ITarifa trf;
            BaseConta bcnt;

            double num = 2;
            if (pessoa == "Pessoa Física")
            {
                bcnt = new Conta_Residencial(nomeLido, codigo, leituraAtual, leituraAnterior);
                //seto os valores das leituras na classe base
                trf = new TarifaResidencial();
                bcnt.setTarifa(trf);//tava sem o trf
                num = bcnt.tarifa_MtdBaseConta(bcnt);
            }
            else
            {
                bcnt = new Conta_Comercial(nomeLido, codigo, leituraAtual, leituraAnterior);
                trf = new TarifaComercial();
                bcnt.setTarifa(trf);
                num = bcnt.tarifa_MtdBaseConta(bcnt);
            }
            return num;//retorna um consumo
        }

        //<persistencia>
        public void cadastrarContaTxt(string pessoa, string codigo, double leituraAtual, double leituraAnterior, double num)
        {
            if (pessoa == "Pessoa Física")
            {
                ContaDAO contaDAO = new ContaDAO();
                contaDAO.escreverContaRes(codigo, leituraAtual, leituraAnterior, num);
            }
            else
            {
                ContaDAO contaDAO = new ContaDAO();
                contaDAO.escreverContaCom(codigo, leituraAtual, leituraAnterior, num);
            }
            MessageBox.Show("Conta cadastrada com sucesso no txt");
            Limpar();

        }
        public void cadastrarContaXml(string pessoa, string codigo, double leituraAtual, double leituraAnterior, double num)
        {

            if (pessoa == "Pessoa Física")
            {
                ContaResidencialDAO contaResidencial = new ContaResidencialDAO();
                contaResidencial.carregar_MtdContaResidencialDAO();
                Conta_Residencial cntRes = new Conta_Residencial()
                {
                    cpf = codigo,
                    leituraAtual_MtdConta = leituraAtual,
                    leituraAnterior_MtdConta = leituraAnterior,
                    tarifa_MtdContaResidencialXml = ("R$: " + Math.Round(num, 2))
                };
                contaResidencial.adicionar_MtdContaResidencialDAO(cntRes);
                contaResidencial.salvar_MtdContaResidencialDAO();
            }
            else
            {
                ContaComercialDAO cntComercial = new ContaComercialDAO();
                cntComercial.carregar_MtdContaComercialDAO();
                Conta_Comercial cntCom = new Conta_Comercial()
                {
                    cnpjJurid_MtdContaC = codigo,
                    leituraAtual_MtdConta = leituraAtual,
                    leituraAnterior_MtdConta = leituraAnterior,
                    tarifa_MtdContaComercialXml = ("R$: " + Math.Round(num, 2))
                };
                cntComercial.adicionar_MtdContaComercialDAO(cntCom);
                cntComercial.salvar_MtdContaComercialDAO();
            }
            MessageBox.Show("Conta cadastrada com sucesso no xml");
            Limpar();
        }
        public void cadastrarContaBanco(string pessoa, string codigo, double leituraAtual, double leituraAnterior, double num)
        {
            ContaResDAO objPessoaFis = new ContaResDAO();
            ContaComDAO objPessoaJur = new ContaComDAO();
            try
            {
                if (pessoa == "Pessoa Física")
                {
                    objPessoaFis.conectar();
                    num = Math.Round(num, 2);//valor final da conta arredondada para 2 casas decimais

                    string leituraAtual1 = "Leitura Atual: " + leituraAtual;
                    string leituraAnterior1 = "Leitura Anterior: " + leituraAnterior;
                    string num1 = "R$: " + num;

                    objPessoaFis.inserir(codigo, leituraAtual1, leituraAnterior1, num1);//(nome, pessoa, codigo);
                    MessageBox.Show("Conta cadastrada com sucesso no banco de dados");
                }
                else
                {
                    objPessoaJur.conectar();
                    num = Math.Round(num, 2);//valor final da conta arredondada para 2 casas decimais

                    string leituraAtual1 = "Leitura Atual: " + leituraAtual;
                    string leituraAnterior1 = "Leitura Anterior: " + leituraAnterior;
                    string num1 = "R$: " + num;
                    objPessoaJur.inserir(codigo, leituraAtual1, leituraAnterior1, num1);
                    MessageBox.Show("Conta cadastrada com sucesso no banco de dados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //</persistencia>
        public int confErroSeHouverInforma(int flagCodigo, int flagLeitura, int flagPessoaEncontrada)
        {
            int erro = 0;

            //17 combinações possiveis-->16 +1
            //flagCodigo==0&&flagLeitura==0&&flagPessoaEncontrada==0-->Cliente cadastrado
            if (flagCodigo == 0 && flagLeitura == 0 && flagPessoaEncontrada == 1)
            {
                MessageBox.Show("Cliente não cadastrado");
                erro = 1;
            }
            else if (flagCodigo == 0 && flagLeitura == 1 && flagPessoaEncontrada == 0)
            {
                MessageBox.Show("Informe a leitura atual");
                erro = 1;
            }
            else if (flagCodigo == 0 && flagLeitura == 1 && flagPessoaEncontrada == 1)
            {
                MessageBox.Show("Informe a leitura atual e o cliente não está cadastrado");
                erro = 1;
            }
            else if (flagCodigo == 0 && flagLeitura == 2 && flagPessoaEncontrada == 0)
            {
                MessageBox.Show("Informe a leitura anterior");
                erro = 1;
            }
            else if (flagCodigo == 0 && flagLeitura == 2 && flagPessoaEncontrada == 1)
            {
                MessageBox.Show("Informe a leitura anterior e o cliente não está cadastrado");
                erro = 1;
            }
            else if (flagCodigo == 0 && flagLeitura == 3 && flagPessoaEncontrada == 0)
            {
                MessageBox.Show("Informe ambas as leituras");
                erro = 1;
            }
            else if (flagCodigo == 0 && flagLeitura == 3 && flagPessoaEncontrada == 1)
            {
                MessageBox.Show("Informe ambas as leituras e o cliente não está cadastrado");
                erro = 1;
            }
            //sempre que flagPessoaEncontrada==0-->flagCodigo=0
            else if (flagCodigo == 1 && flagLeitura == 0)
            {
                MessageBox.Show("Informe o cpf");
                erro = 1;
            }
            else if (flagCodigo == 1 && flagLeitura == 1)
            {
                MessageBox.Show("Informe o cpf e a leitura Atual");
                erro = 1;
            }
            else if (flagCodigo == 1 && flagLeitura == 2)
            {
                MessageBox.Show("Informe o cpf e a leitura anterior");
                erro = 1;
            }
            else if (flagCodigo == 1 && flagLeitura == 3)
            {

                MessageBox.Show("Informe o cpf e ambas as leituras");
                erro = 1;
            }
            else if (flagCodigo == 2 && flagLeitura == 0)
            {
                MessageBox.Show("Informe o cnpj");
                erro = 1;
            }
            else if (flagCodigo == 2 && flagLeitura == 1)
            {
                MessageBox.Show("Informe o cnpj e a leitura atual");
                erro = 1;
            }
            else if (flagCodigo == 2 && flagLeitura == 2)
            {
                MessageBox.Show("Informe o cnpj e a leitura anterior");
                erro = 1;
            }
            else if (flagCodigo == 2 && flagLeitura == 3)
            {
                MessageBox.Show("Informe o cnpj e ambas as leituras");
                erro = 1;
            }
            else if (flagLeitura == 4)
            {
                {
                    MessageBox.Show("Os valores informados em leitura só podem ser números");
                    MessageBox.Show("Conta não cadastrada");
                    erro = 1;
                }
            }
            return erro;
        }

    }
}

