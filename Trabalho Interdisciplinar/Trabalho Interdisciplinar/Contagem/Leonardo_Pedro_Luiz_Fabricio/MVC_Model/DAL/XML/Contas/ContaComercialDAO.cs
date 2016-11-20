using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.XML.Contas
{
    class ContaComercialDAO
    {
        //caminho do arquivo
        private string strPathFile = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Xml/Contas/ContaComercial.xml";
        private string strPathFileTemp = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Xml/Contas/Conta.tmp";

        //atributos
        private List<Conta_Comercial> cntComercial;

        public ContaComercialDAO()
        {
            this.cntComercial = new List<Conta_Comercial>();
        }
        public void remover_MtdContaComercialDAO(Conta_Comercial _cons)
        {
            cntComercial.Remove(_cons);
        }
        public void adicionar_MtdContaComercialDAO(Conta_Comercial _cons)
        {
            cntComercial.Add(_cons);
        }
        public void salvar_MtdContaComercialDAO()
        {
            XmlSerializer objcContaCOm = new XmlSerializer(typeof(List<Conta_Comercial>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            objcContaCOm.Serialize(fs, cntComercial);

            fs.Close();

        }
        public void carregar_MtdContaComercialDAO()
        {
            XmlSerializer objcContaCOm = new XmlSerializer(typeof(List<Conta_Comercial>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            try
            {
                this.cntComercial = objcContaCOm.Deserialize(fs) as List<Conta_Comercial>;
            }
            catch (InvalidOperationException) //não existe o arquivo
            {
                objcContaCOm.Serialize(fs, cntComercial);
                //throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public int pesquisarContaCom(string codigo)
        {
            int flagCodigoEncontrado = 1;
            using (FileStream arq = new FileStream(strPathFileTemp, FileMode.Create))
            {
                using (StreamWriter escrever = new StreamWriter(arq))
                {
                    using (StreamReader ler = new StreamReader(strPathFile))
                    {
                        string leitura1, leituraFimPag;
                        ler.ReadLine();//a 1°linha do xml
                        ler.ReadLine();//a 2°linha do xml
                        while (!ler.EndOfStream)
                        {
                            leitura1 = ler.ReadLine();//lê o cabeçalho
                            leituraFimPag = ler.ReadLine();
                            if (leituraFimPag != null)
                            {
                                string[] leitura2 = leituraFimPag.Split('<', '>');//lê  o codigo
                                ler.ReadLine();//lê a leitura atual
                                ler.ReadLine();// lê a leitura anterior
                                string[] leitura3 = ler.ReadLine().Split('<', '>');// lê a tarifa

                                leitura1 = ler.ReadLine();//lê o rodapé 
                                if (leitura2[2].Equals(codigo))
                                {
                                    flagCodigoEncontrado = 0;

                                    escrever.WriteLine(leitura2[2]);
                                    escrever.WriteLine(leitura3[2]);


                                }
                            }
                        }
                    }
                }
            }//fim da leitura do arquivo

            return flagCodigoEncontrado;
        }
        public void apagarArqTemp()
        {
            File.Delete(strPathFileTemp);
        }

    }
}
