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
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Tarifa;


//Os nomes das pastas possuem MVC antes para evitar o erro de referencia
//Este erro de referencia ocorre porque um dos atributos da listView é um atrbituo chamado View e desta forma
//quando se coloca o nome da pasta de view o programa não consegue saber qual dos dois definir.

//Math.Round
//O método acima faz o arrendondamento do valor para quantas casas decimais o usuario desejar.

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Conta
{
    public partial class frmCadastrarConta : Form
    {
        //caminhos dos arquivos
        private string strPathFile = @"C:/Users/Admin/Desktop/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivos/Contas.txt";
        private string strPathFile2 = @"C:/Users/Admin/Desktop/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivos/Consumidores.txt";

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
            Cadastrar();
        }

        //------------------métodos
        private void Limpar()
        {
            txtMskCNPJ.Clear();
            txtMskCPF.Clear();
            txtLeituraAnterior.Clear();
            txtLeituraAtual.Clear();
        }
        private void Cadastrar()
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
                flagcodigocadastrado = procuraCodigo(ref nomeLido, pessoa, codigo);
            //flagcodigocadastrado=0---> O cliente foi cadastrado
            //flagcodigocadastrado=1---> O cliente ainda não foi cadastrado

            if (flagcodigocadastrado == 0 && flagLeitura == 0)
                //Se flagcodigocadastrado=0 então flagCodigo=0
                cadastrarConta(pessoa, codigo, ref nomeLido, leituraAtual, leituraAnterior);

            mensagemErro(flagCodigo, flagLeitura, flagcodigocadastrado);
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
        private int verfDigitouCpf_Cnpj(ref string codigo)
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
        private int verfLeitura(ref double leituraAnterior, ref double leituraAtual)
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
        private int procuraCodigo(ref string nomeLido, string pessoa, string codigo)
        {
            string pessoaLida, codigoLido;
            int flagcodigocadastrado = 1;

            //procura o cliente com o cpf/cnpj informado
            using (StreamReader ler = new StreamReader(strPathFile2))
            {
                while (!ler.EndOfStream)
                {
                    nomeLido = ler.ReadLine();//nome
                    pessoaLida = ler.ReadLine();//Pessoa Física ou Juridica
                    codigoLido = ler.ReadLine();//cpf ou cnpj
                    ler.ReadLine();//_________
                    if (nomeLido != null && pessoaLida != null && codigoLido != null)
                        if (pessoaLida.Equals(pessoa))
                            if (codigoLido.Equals(codigo))
                                flagcodigocadastrado = 0;
                }//fim da procura do cliente
            }
            return flagcodigocadastrado;
        }
        private void cadastrarConta(string pessoa, string codigo, ref string nomeLido, double leituraAtual, double leituraAnterior)
        {
            //referencias
            ITarifa trf;
            BaseConta bcnt;

            using (StreamWriter sw = File.AppendText(strPathFile))
            {
                double num = 2;
                if (pessoa == "Pessoa Física")
                {
                    bcnt = new Conta_Residencial(nomeLido, codigo, leituraAtual, leituraAnterior);
                    //seto os valores das leituras na classe base
                    trf = new TarifaResidencial();
                    bcnt.setTarifa(trf);//tava sem o trf
                    num = bcnt.tarifa_Mtd(bcnt);
                }
                else
                {
                    bcnt = new Conta_Comercial(nomeLido, codigo, leituraAtual, leituraAnterior);
                    trf = new TarifaComercial();
                    bcnt.setTarifa(trf);
                    num = bcnt.tarifa_Mtd(bcnt);
                }
                sw.WriteLine(codigo);
                sw.WriteLine("Leitura Atual: " + txtLeituraAtual.Text);
                sw.WriteLine("Leitura Anterior: " + txtLeituraAnterior.Text);
                sw.WriteLine("R$: " + Math.Round(num, 2));
                sw.WriteLine("______________________________");
                MessageBox.Show("Conta cadastrada com sucesso");
                Limpar();
            }
        }
        private void mensagemErro(int flagCodigo, int flagLeitura, int flagPessoaEncontrada)
        {
            //17 combinações possiveis-->16 +1
            //flagCodigo==0&&flagLeitura==0&&flagPessoaEncontrada==0-->Cliente cadastrado
            if (flagCodigo == 0 && flagLeitura == 0 && flagPessoaEncontrada == 1)
                MessageBox.Show("Cliente não cadastrado");
            else if (flagCodigo == 0 && flagLeitura == 1 && flagPessoaEncontrada == 0)
                MessageBox.Show("Informe a leitura atual");
            else if (flagCodigo == 0 && flagLeitura == 1 && flagPessoaEncontrada == 1)
                MessageBox.Show("Informe a leitura atual e o cliente não está cadastrado");
            else if (flagCodigo == 0 && flagLeitura == 2 && flagPessoaEncontrada == 0)
                MessageBox.Show("Informe a leitura anterior");
            else if (flagCodigo == 0 && flagLeitura == 2 && flagPessoaEncontrada == 1)
                MessageBox.Show("Informe a leitura anterior e o cliente não está cadastrado");
            else if (flagCodigo == 0 && flagLeitura == 3 && flagPessoaEncontrada == 0)
                MessageBox.Show("Informe ambas as leituras");
            else if (flagCodigo == 0 && flagLeitura == 3 && flagPessoaEncontrada == 1)
                MessageBox.Show("Informe ambas as leituras e o cliente não está cadastrado");
            //sempre que flagPessoaEncontrada==0-->flagCodigo=0
            else if (flagCodigo == 1 && flagLeitura == 0)
                MessageBox.Show("Informe o cpf");
            else if (flagCodigo == 1 && flagLeitura == 1)
                MessageBox.Show("Informe o cpf e a leitura Atual");
            else if (flagCodigo == 1 && flagLeitura == 2)
                MessageBox.Show("Informe o cpf e a leitura anterior");
            else if (flagCodigo == 1 && flagLeitura == 3)
                MessageBox.Show("Informe o cpf e ambas as leituras");
            else if (flagCodigo == 2 && flagLeitura == 0)
                MessageBox.Show("Informe o cnpj");
            else if (flagCodigo == 2 && flagLeitura == 1)
                MessageBox.Show("Informe o cnpj e a leitura atual");
            else if (flagCodigo == 2 && flagLeitura == 2)
                MessageBox.Show("Informe o cnpj e a leitura anterior");
            else if (flagCodigo == 2 && flagLeitura == 3)
                MessageBox.Show("Informe o cnpj e ambas as leituras");
            else if (flagLeitura == 4)
            {
                MessageBox.Show("Os valores informados em leitura só podem ser números");
                MessageBox.Show("Conta não cadastrada");
            }
        }
    }


}

