using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Contas;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Tarifa;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Bloco_de_Notas.Conta
{
    public class ContaDAO
    {
        //caminhos dos arquivos
        private string strPathFile = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Bloco_de_Notas/Contas/ContaComercial.txt";
        private string strPathFile1 = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Bloco_de_Notas/Contas/ContaResidencial.txt";
        private string strPathFileTemp = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Bloco_de_Notas/Contas/Conta.tmp";

        public void escreverContaCom(string codigo, double leituraAtual, double leituraAnterior, double num)
        {
            using (StreamWriter sw = File.AppendText(strPathFile))
            {
                sw.WriteLine(codigo);
                sw.WriteLine("Leitura Atual: " + leituraAtual);
                sw.WriteLine("Leitura Anterior: " + leituraAnterior);
                sw.WriteLine("R$: " + Math.Round(num, 2));
                sw.WriteLine("______________________________");
            }
        }

        public void escreverContaRes(string codigo, double leituraAtual, double leituraAnterior, double num)
        {
            using (StreamWriter sw = File.AppendText(strPathFile1))
            {
                sw.WriteLine(codigo);
                sw.WriteLine("Leitura Atual: " + leituraAtual);
                sw.WriteLine("Leitura Anterior: " + leituraAnterior);
                sw.WriteLine("R$: " + Math.Round(num, 2));
                sw.WriteLine("______________________________");
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
                        string leitura, leitura2, leitura3;
                        while (!ler.EndOfStream)
                        {
                            leitura = ler.ReadLine();//lê o cpf ou cnpj
                            ler.ReadLine();//lê a leitura Atual
                            ler.ReadLine();//lê a leitura Anterior
                            leitura2 = ler.ReadLine();//lê o valor da conta
                            leitura3 = ler.ReadLine();//lê o _____
                                                      // if (String.IsNullOrEmpty(leitura3))
                            if (leitura3 != null)
                                if (leitura.Equals(codigo))
                                {
                                    flagCodigoEncontrado = 0;

                                    escrever.WriteLine(leitura);
                                    escrever.WriteLine(leitura2);
                                }
                        }
                    }
                }
            }//fim do 1°using
            return flagCodigoEncontrado;
        }
        public int pesquisarContaRes(string codigo)
        {
            int flagCodigoEncontrado = 1;
            using (FileStream arq = new FileStream(strPathFileTemp, FileMode.Create))
            {
                using (StreamWriter escrever = new StreamWriter(arq))
                {
                    using (StreamReader ler = new StreamReader(strPathFile1))
                    {
                        string leitura, leitura2, leitura3;
                        while (!ler.EndOfStream)
                        {
                            leitura = ler.ReadLine();//lê o cpf ou cnpj
                            ler.ReadLine();//lê a leitura Atual
                            ler.ReadLine();//lê a leitura Anterior
                            leitura2 = ler.ReadLine();//lê o valor da conta
                            leitura3 = ler.ReadLine();//lê o _____
                                                      // if (String.IsNullOrEmpty(leitura3))
                            if (leitura3 != null)
                                if (leitura.Equals(codigo))
                                {
                                    flagCodigoEncontrado = 0;
                                    escrever.WriteLine(leitura);
                                    escrever.WriteLine(leitura2);
                                }
                        }
                    }
                }
            }//fim do 1°using

            //File.Delete(strPathFileTemp+".temp");
            return flagCodigoEncontrado;
        }
        public void apagarArqTemp()
        {
            File.Delete(strPathFileTemp);
        }
    }
}

