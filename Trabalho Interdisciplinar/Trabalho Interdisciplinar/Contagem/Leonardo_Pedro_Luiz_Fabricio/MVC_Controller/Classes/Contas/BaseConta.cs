using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Tarifa;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas
{
    public abstract class BaseConta//retirei o public
    {
        //atributos
        private ITarifa trf;
        protected double tarifa;
        
        protected double leituraAtual_AtrbConta;
        protected double leituraAnterior_AtrbConta;
        private double consumo_AtrbConta;
        private string tarifa_AtrbContaComercialXml;


        //demais métodos
        public double consumo_MtdConta()
        {
            consumo_AtrbConta = leituraAtual_AtrbConta - leituraAnterior_AtrbConta;
            return consumo_AtrbConta;
        }
        public void setTarifa(ITarifa trf2)
        {
            trf = trf2;
        }
        public double tarifa_MtdBaseConta(BaseConta bnt)
        {
            tarifa = trf.tarifaConta(bnt);
            return tarifa;
        }
        //construtor
        public BaseConta() { }

    }
}