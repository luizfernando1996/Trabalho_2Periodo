using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_View.Conta;
namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Model.DAL.Bloco_de_Notas.Consumidor
{
    class PessoaDAO
    {

        //caminho do arquivo
        private string strPathFile = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Bloco_de_Notas/Consumidor/PessoaFisica.txt";
        private string strPathFile1 = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Bloco_de_Notas/Consumidor/PessoaJuridica.txt";
        private string strPathFileTemp = @"C:/Users/Admin/Source/Repos/Trabalho_2Periodo/Trabalho Interdisciplinar/Trabalho Interdisciplinar/Contagem/Leonardo_Pedro_Luiz_Fabricio/MVC_Model/Arquivo/Bloco_de_Notas/Consumidor/Consumidor.tmp";

        public void escreverPessoaJuridica(string nome, string pessoa, string codigo)
        {
            using (StreamWriter sw = File.AppendText(strPathFile1))
            {
                sw.WriteLine(nome);
                sw.WriteLine(pessoa);
                sw.WriteLine(codigo);
                sw.WriteLine("______________________________");
            }
        }
        public void escreverPessoaFisica(string nome, string pessoa, string codigo)
        {
            using (StreamWriter sw = File.AppendText(strPathFile))
            {
                sw.WriteLine(nome);
                sw.WriteLine(pessoa);
                sw.WriteLine(codigo);
                sw.WriteLine("______________________________");
            }
        }
        public int pesquisaConsPraConta(ref string nomeLido, string pessoa, string codigo)
        {
            string pessoaLida, codigoLido;
            int flagcodigocadastrado = 1;

            //procura o cliente com o cpf/cnpj informado
            using (StreamReader ler = new StreamReader(strPathFile))
            {
                while (!ler.EndOfStream)
                {
                    nomeLido = ler.ReadLine();//nome
                    pessoaLida = ler.ReadLine();//Pessoa Física ou Juridica
                    codigoLido = ler.ReadLine();//cpf ou cnpj
                    ler.ReadLine();//_________
                    if (nomeLido != null && pessoaLida != null && codigoLido != null)
                        if (pessoaLida.Equals(pessoa))
                            if (codigoLido.Equals(codigo))
                                flagcodigocadastrado = 0;

                }//fim da procura do cliente
            }
            return flagcodigocadastrado;
        }
        public int pesquisaPesFis(string nome, string pessoa, string codigo)
        {
            int flagPessoaEncontrada = 1;
            using (FileStream arq = new FileStream(strPathFileTemp, FileMode.Create))
            {
                using (StreamWriter escrever = new StreamWriter(arq))
                {
                    using (StreamReader ler = new StreamReader(strPathFile))
                    {
                        string leitura1, leitura2, leitura3;
                        while (!ler.EndOfStream)
                        {
                            leitura1 = ler.ReadLine();//lê o nome
                            leitura2 = ler.ReadLine();//pessoa
                            leitura3 = ler.ReadLine();//codigo
                            ler.ReadLine();//_________
                            if (leitura1 != null && leitura2 != null && leitura3 != null)
                            {
                                //evita a falha do método StartsWith
                                if (leitura1.Equals(nome))//encontrou o nome
                                    if (leitura2.Equals(pessoa))//encontrou a pessoa
                                        if (leitura3.Equals(codigo))//Encontrou o código(cpf/cnpj)
                                        {
                                            flagPessoaEncontrada = 0;
                                            escrever.WriteLine(leitura1);
                                            escrever.WriteLine(leitura2);
                                            escrever.WriteLine(leitura3);

                                        }
                            }
                        }
                    }
                }
            }
            return flagPessoaEncontrada;
        }
        public int pesquisaPesJurid(string nome, string pessoa, string codigo)
        {
            int flagPessoaEncontrada = 1;
            using (FileStream arq = new FileStream(strPathFileTemp, FileMode.Create))
            {
                using (StreamWriter escrever = new StreamWriter(arq))
                {
                    using (StreamReader ler = new StreamReader(strPathFile1))
                    {
                        string leitura1, leitura2, leitura3;

                        while (!ler.EndOfStream)
                        {
                            leitura1 = ler.ReadLine();//lê o nome
                            leitura2 = ler.ReadLine();//pessoa
                            leitura3 = ler.ReadLine();//codigo
                            ler.ReadLine();//_________
                            if (leitura1 != null && leitura2 != null && leitura3 != null)//evita a falha do método StartsWith
                                if (leitura1.Equals(nome))//encontrou o nome
                                    if (leitura2.Equals(pessoa))//encontrou a pessoa
                                        if (leitura3.Equals(codigo))//Encontrou o código(cpf/cnpj)
                                        {
                                            flagPessoaEncontrada = 0;

                                            escrever.WriteLine(leitura1);
                                            escrever.WriteLine(leitura2);
                                            escrever.WriteLine(leitura3);

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
