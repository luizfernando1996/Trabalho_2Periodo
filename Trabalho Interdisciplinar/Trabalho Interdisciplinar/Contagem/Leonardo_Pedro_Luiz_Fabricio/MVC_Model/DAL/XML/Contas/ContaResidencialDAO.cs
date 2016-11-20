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
    class ContaResidencialDAO
    {
        //caminho do arquivo
        private string strPathFile = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Xml/Contas/ContaResidencial.xml";
        private string strPathFileTemp = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Xml/Contas/Conta.tmp";

        //atributos
        private List<Conta_Residencial> cntResidencial;

        public ContaResidencialDAO()
        {
            this.cntResidencial = new List<Conta_Residencial>();
        }
        public void remover_MtdContaResidencialDAO(Conta_Residencial _cons)
        {
            cntResidencial.Remove(_cons);
        }
        public void adicionar_MtdContaResidencialDAO(Conta_Residencial _cons)
        {
            cntResidencial.Add(_cons);
        }
        public void salvar_MtdContaResidencialDAO()
        {
            XmlSerializer objContaRes = new XmlSerializer(typeof(List<Conta_Residencial>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            objContaRes.Serialize(fs, cntResidencial);
            fs.Close();

        }
        public void carregar_MtdContaResidencialDAO()
        {
            XmlSerializer objContaRes = new XmlSerializer(typeof(List<Conta_Residencial>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            try
            {
                this.cntResidencial = objContaRes.Deserialize(fs) as List<Conta_Residencial>;
            }
            catch (InvalidOperationException) //não existe o arquivo
            {
                objContaRes.Serialize(fs, cntResidencial);
                //throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public int pesquisarContaRes(string codigo)
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
    }
}
