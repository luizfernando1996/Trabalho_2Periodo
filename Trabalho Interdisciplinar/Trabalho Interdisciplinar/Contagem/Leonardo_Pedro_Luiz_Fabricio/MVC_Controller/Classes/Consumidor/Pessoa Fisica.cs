using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor
{
    class Pessoa_Fisica:Consumidor
    {
        //atributos
        private string cpf_PessoaF;


        //get e set
        public string getCpf_PessoaF()
        {
            return this.cpf_PessoaF;
        }
        public void setCpf_PessoaF(string cpf)
        {
            this.cpf_PessoaF = cpf;
        }

        //construtor
        public Pessoa_Fisica(string nome, string cpf_PessoaF)
        {
           setNome_Consumidor(nome);
           this.cpf_PessoaF = cpf_PessoaF;
       }


    }
}
