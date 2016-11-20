using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas
{
    public class Conta_Comercial : BaseConta
    //se alguma classe filha se tornar public então a classe mãe obrigatoriamente
    //deve se tornar também
    {
        //atributos
        private Pessoa_Juridica cnpjJurid_AtrbContaC;
        private Pessoa_Juridica cnpj = new Pessoa_Juridica();
        private string tarifa_AtrbContaComercialXml;

        //get e set
        public string cnpjJurid_MtdContaC
        {
            get
            {
                return cnpj.cnpj_MtdPessoaJ;
            }

            set
            {
                cnpj.cnpj_MtdPessoaJ = value;
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
        public string tarifa_MtdContaComercialXml
        {
            get
            {
                return tarifa_AtrbContaComercialXml;
            }

            set
            {
                tarifa_AtrbContaComercialXml = value;
            }
        }

        //construtor 
        public Conta_Comercial(string nome, string cnpj, double leituraAtual, double leituraAnterior)
        {
            cnpjJurid_AtrbContaC = new Pessoa_Juridica(nome, cnpj);
            leituraAtual_MtdConta = leituraAtual;
            leituraAtual_MtdConta = leituraAnterior;
        }
        public Conta_Comercial() { }

    }
}
