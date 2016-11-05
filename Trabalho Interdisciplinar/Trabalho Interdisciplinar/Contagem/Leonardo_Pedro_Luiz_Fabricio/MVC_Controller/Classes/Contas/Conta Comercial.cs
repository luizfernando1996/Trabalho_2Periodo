using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas
{
    //arrumar as casas decimais do valor da conta

    class Conta_Comercial : BaseConta
    {
        //atributos
        private Pessoa_Juridica cnpjJurid_AtrbContaC;
        //construtor 

        public Conta_Comercial(string nome, string cnpj, double leituraAtual, double leituraAnterior)
        {
            cnpjJurid_AtrbContaC = new Pessoa_Juridica(nome, cnpj);
            setLeituraAtual_MtdConta(leituraAtual);
            setLeituraAnterior_MtdConta(leituraAnterior);
        }

    }
}
