using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL
{
    class ClienteDAO
    {
        //caminho do arquivo
        private string strPathFile = @"C:/Users/Admin/Desktop/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivos/Clientes.xml";

        //atributos
        private List<Consumidor> cons;

        public ClienteDAO()
        {
            this.cons = new List<Consumidor>();
        }
        public void remover_MtdClienteDAO(Consumidor _cons)
        {
            cons.Remove(_cons);
        }
        public void adicionar_MtdClienteDAO(Consumidor _cons)
        {
            cons.Add(_cons);
        }
        public void salvar_MtdClienteDAO()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Consumidor>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            ser.Serialize(fs, cons);
            fs.Close();
        }
        public void carregar_MtdClienteDAO()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Consumidor>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            try
            {
                this.cons = ser.Deserialize(fs) as List<Consumidor>;
            }
            catch (InvalidOperationException) //não existe o arquivo
            {
                ser.Serialize(fs, cons);
                //throw;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
