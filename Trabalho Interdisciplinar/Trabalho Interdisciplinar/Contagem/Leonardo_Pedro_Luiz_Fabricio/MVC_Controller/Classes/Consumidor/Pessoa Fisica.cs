using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//deletar o get e set de cpf_PessoaF

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor
{
    public class Pessoa_Fisica:Consumidor
    {
        //atributos
        private string cpf_PessoaF;

        //get e set na ordem do XML
        public string nome_MtdPessoaF
        {
            get
            {
                return nome_AtrbConsumidor;
                //tive que retirar os metodos de encapsulamento do atributo nome da classe consumidor
            }

            set
            {
                nome_AtrbConsumidor = value;
            }
        }
        public string cpf_MtdPessoaF
        {
            get
            {
                return cpf_PessoaF;
            }

            set
            {
                cpf_PessoaF = value;
            }
        }
        //o metodo nome deve ser escrito antes do método cpf_PessoaF para que o arquivo xml respeite esta ordem

        //construtor
        public Pessoa_Fisica(string nome, string cpf_PessoaF)
        {
           nome_AtrbConsumidor=nome;
           this.cpf_PessoaF = cpf_PessoaF;
       }
        public Pessoa_Fisica() { }//para o arquivo XML


    }
}
