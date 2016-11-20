using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Tarifa
{
    class TarifaResidencial:ITarifa
    {
        //atributos
        private double valorTotal_AtrbContaR;
        //métodos
        public double tarifaConta(BaseConta bcntRes)
        {
            //bcntRes-->o objeto que setou os valores de leituraAtual e leituraAnterior
            double consumo=bcntRes.consumo_MtdConta();
            valorTotal_AtrbContaR = (((0.4 * consumo) + 9.25) + (((0.4 * consumo) + 9.25) * 0.3));
            return valorTotal_AtrbContaR;
        }
    }
}
