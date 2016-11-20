using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Tarifa
{
    class TarifaComercial:ITarifa
    {
        
        //atributos
        private double valorTotal_AtrbContaC;

        //métodos
        public double tarifaConta(BaseConta bcnCom)
        {
            double consumo = bcnCom.consumo_MtdConta();
            valorTotal_AtrbContaC = (((0.35 * consumo) + 9.25) + (((0.35 * consumo) + 9.25) * 0.18));
            return valorTotal_AtrbContaC;
        }
    }
}
