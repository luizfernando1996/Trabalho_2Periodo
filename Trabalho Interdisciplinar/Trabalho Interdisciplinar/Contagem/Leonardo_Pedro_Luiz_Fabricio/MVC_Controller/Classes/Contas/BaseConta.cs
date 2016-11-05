using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Tarifa;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas
{
     class BaseConta//retirei o public
    {
        //atributos
        public ITarifa trf;
        private double tarifa;

        private double leituraAtual_AtrbConta;
        private double leituraAnterior_AtrbConta;
        private double consumo_AtrbConta;

        //get e set
        public void setLeituraAtual_MtdConta(double valor)
        {
            this.leituraAtual_AtrbConta = valor;
            Console.WriteLine(leituraAtual_AtrbConta);
        }
        public double getLeituraAtual_MtdConta()
        {
            return this.leituraAtual_AtrbConta;
        }
        public void setLeituraAnterior_MtdConta(double valor)
        {
            this.leituraAnterior_AtrbConta = valor;
            Console.WriteLine(leituraAnterior_AtrbConta);

        }
        public double getLeituraAnterior_MtdConta()
        {
            return this.leituraAnterior_AtrbConta;
        }

        //demais métodos
        public double consumo_MtdConta()
        {
            consumo_AtrbConta = getLeituraAtual_MtdConta() - getLeituraAnterior_MtdConta();
            return consumo_AtrbConta;
        }
        public void setTarifa(ITarifa trf2)
        {
            trf = trf2;
        }
        public double tarifa_Mtd(BaseConta bnt)
        {
            tarifa=trf.tarifaConta(bnt);
            return tarifa;
        }

    }
}