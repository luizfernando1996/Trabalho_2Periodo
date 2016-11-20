using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Banco_de_Dados.Conta
{
    class ContaResDAO
    {
        private MySqlConnection bdConn; //MySQL
        private MySqlDataAdapter bdAdapter;
        private DataSet bdDataSet; //MySQL


        public void conectar()
        {
            bdDataSet = new DataSet();
            bdConn = new MySqlConnection("Persist Security Info=True;server=localhost;database=trabalho_poo;uid=root;pwd=''");

            try
            {
                bdConn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void inserir(string codigo, string leituraAtual, string leituraAnterior, string num)
        {
            //escreva no banco de dados os parametros acima 
            if (bdConn.State == ConnectionState.Open)
            {
                MySqlCommand commS = new MySqlCommand("INSERT INTO consumidores VALUES(cpf,'0000000000','Leonardo');", bdConn);
                commS.BeginExecuteNonQuery();
            }
        }
        public int pesquisarContaRes(string codigo)
        {
            int flagCodigoEncontrado = 1;
            //deve procurar o codigo do cliente e se encontrar o codigo do cliente deve armazena-lo junto com o valor da tarifa da conta
            //estas duas informações(codigo do cliente e tarifa da conta) devem ser mandados para o data gried view
           
            //sete flagCodigoEncontrado para 0 se você encontrar o codigo do cliente.

            return flagCodigoEncontrado;
        }

    }
}
