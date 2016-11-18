using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas
{
    //arrumar as casas decimais do valor da conta
    class Conta_Residencial:BaseConta
    {
        //atributos
        private Pessoa_Fisica cpf_AtrbContaR;

        //construtor 
        public Conta_Residencial(string nome,string cpf, double leituraAtual, double leituraAnterior) {
            this.cpf_AtrbContaR = new Pessoa_Fisica(nome,cpf);
            setLeituraAtual_MtdConta(leituraAtual);
            setLeituraAnterior_MtdConta(leituraAnterior);
        }


    }
}
