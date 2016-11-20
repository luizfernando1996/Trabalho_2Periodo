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
    class PessoaJuridicaDAO
    {
        //caminho do arquivo
        private string strPathFile = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Xml/Cliente/PessoaJuridica.xml";
        private string strPathFileTemp = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Xml/Cliente/Consumidor.tmp";

        //atributos
        private List<Pessoa_Juridica> pessoaJurid;

        public PessoaJuridicaDAO()
        {
            this.pessoaJurid = new List<Pessoa_Juridica>();
        }
        public void remover_MtdPessoaJuridicaDAO(Pessoa_Juridica _cons)
        {
            pessoaJurid.Remove(_cons);
        }
        public void adicionar_MtdPessoaJuridicaDAO(Pessoa_Juridica _cons)
        {
            pessoaJurid.Add(_cons);
        }
        public void salvar_MtdPessoaJuridicaDAO()
        {
            XmlSerializer objctSeriaJurid = new XmlSerializer(typeof(List<Pessoa_Juridica>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            objctSeriaJurid.Serialize(fs, pessoaJurid);

            fs.Close();

        }
        public void carregar_MtdPessoaJuridicaDAO()
        {
            XmlSerializer objctSeriaJurid = new XmlSerializer(typeof(List<Pessoa_Juridica>));
            FileStream fs = new FileStream(strPathFile, FileMode.OpenOrCreate);
            try
            {
                this.pessoaJurid = objctSeriaJurid.Deserialize(fs) as List<Pessoa_Juridica>;
            }
            catch (InvalidOperationException) //não existe o arquivo
            {
                objctSeriaJurid.Serialize(fs, pessoaJurid);
                //throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public int pesqPessoaJur(string nome, string pessoa, string codigo)
        {
            int flagPessoaEncontrada = 1;
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
                                string[] leitura2 = leituraFimPag.Split('<', '>');//lê o nome
                                string[] leitura3 = ler.ReadLine().Split('<', '>');// lê o codigo

                                leitura1 = ler.ReadLine();//lê o rodapé 
                                if (leitura2[2].Equals(nome))//encontrou o nome
                                    if (leitura3[2].Equals(codigo))//Encontrou o código(cpf/cnpj)
                                    {
                                        flagPessoaEncontrada = 0;
                                        escrever.WriteLine(leitura2[2]);
                                        escrever.WriteLine("Pessoa Jurídica");
                                        escrever.WriteLine(leitura3[2]);

                                    }
                            }

                        }
                    }
                }
            }//fim da leitura do arquivo

            return flagPessoaEncontrada;
        }
        public void apagarArqTemp()
        {
            File.Delete(strPathFileTemp);
        }
    }
}
