using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Banco_de_Dados.Consumidor
{
    public class PessoaFisDAO
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
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void inserir(string nome,string pessoa,string cpf)
        {
            if (bdConn.State == ConnectionState.Open)
            {
                MySqlCommand commS = new MySqlCommand("INSERT INTO consumidores VALUES(nome,pessoa,cpf);", bdConn);
                commS.BeginExecuteNonQuery();
            }
        }
        public int pesqPessoaFis(string nome,string pessoa,string cpf)
        {
            int flagPessoaEncontrada = 1;
            //se na procura encotrar a pessoa deve ser retornado 0 na variavel flagPessoaEncotrada
            //o nome da pessoa, a string "Pessoa Juridica" e o cnpj dela devem ser lidos do arquivo e mandados pro data gried view
            return flagPessoaEncontrada;
        }
        public int procuraCodigoPesFisica(ref string nomeLido, string pessoa, string codigo)
        {
            int flagcodigocadastrado = 1;
            //deve procurar o codigo do cliente e se encontrar o codigo do cliente deve setar a flag acima para 0
            //alem de setar a flag acima para 0 ele também deve pegar o nome do cliente com tal codigo e mandar para a ref nomeLido
            return flagcodigocadastrado;
        }


    }
    }