using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.XML.Consumidor
{
    class PessoaFisicaDAO
    {
        //caminho do arquivo
        private string strPathFile = @"C:/Users/Admin/Desktop/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Xml/Cliente/PessoaFisica.xml";

        //atributos
        private List<Pessoa_Fisica> cons;

        public PessoaFisicaDAO()
        {
            this.cons = new List<Pessoa_Fisica>();
        }
        public void remover_MtdPessoaFisicaDAO(Pessoa_Fisica _cons)
        {
            cons.Remove(_cons);
        }
        public void adicionar_MtdPessoaFisicaDAO(Pessoa_Fisica _cons)
        {
            cons.Add(_cons);
        }
        public void salvar_MtdPessoaFisicaDAO()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Pessoa_Fisica>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            ser.Serialize(fs, cons);

            fs.Close();

        }
        public void carregar_MtdPessoaFisicaDAO()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Pessoa_Fisica>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            try
            {
                this.cons = ser.Deserialize(fs) as List<Pessoa_Fisica>;
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
