using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Banco_de_Dados
{
     public class DAL
    {
        private MySqlConnection bdConn; //MySQL
        private MySqlDataAdapter bdAdapter;
        private DataSet bdDataSet; //MySQL
       

        public void Conectar()
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
        public void Inserir(string cpf,string cnpj,string nome)
        {
            if (bdConn.State == ConnectionState.Open)
            {
                MySqlCommand commS = new MySqlCommand("INSERT INTO consumidores VALUES('12225603165','0000000000','Leonardo');", bdConn);
                commS.BeginExecuteNonQuery();
            }
        }
        
        
        }
    }