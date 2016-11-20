using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas
{
    //arrumar as casas decimais do valor da conta
    public class Conta_Residencial:BaseConta
    {
        //atributos
        private Pessoa_Fisica cpf_AtrbContaR;
        private Pessoa_Fisica cpfObj=new Pessoa_Fisica();//tenho que instanciar o cpf_AtrbContaR devido o get e set do cpf
        //se eu não instanciar a referencia acima tem valor null e desta forma ela não consegue atribuir um value ao método cpf_MtdPessoaF
        private string tarifa_AtrbContaResidencialXml;

        //get e set
        public string cpf 
        {
            get
            {
                return cpfObj.cpf_MtdPessoaF; 
            }

            set
            {
                cpfObj.cpf_MtdPessoaF = value;
            }
        }
        public double leituraAtual_MtdConta
        {
            get
            {
                return leituraAtual_AtrbConta;
            }

            set
            {
                leituraAtual_AtrbConta = value;
            }
        }
        public double leituraAnterior_MtdConta
        {
            get
            {
                return leituraAnterior_AtrbConta;
            }

            set
            {
                leituraAnterior_AtrbConta = value;
            }
        }
        public string tarifa_MtdContaResidencialXml
        {
            get
            {
                return tarifa_AtrbContaResidencialXml;
            }

            set
            {
                tarifa_AtrbContaResidencialXml = value;
            }
        }



        //construtor 
        public Conta_Residencial() { }

        public Conta_Residencial(string nome,string cpf, double leituraAtual, double leituraAnterior) {
            this.cpf_AtrbContaR = new Pessoa_Fisica(nome,cpf);
            leituraAtual_MtdConta=leituraAtual;
            leituraAnterior_MtdConta=leituraAnterior;
        }


    }
}
