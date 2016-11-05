using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor
{
    class Pessoa_Juridica:Consumidor
    {
        //atributos
        private string cnpj_PessoaJ;

        //get e set
        public string getCnpj_PessoaJ()
        {
            return this.cnpj_PessoaJ;
        }
        public void setCnpj_PessoaJ(string cnpj)
        {
            this.cnpj_PessoaJ = cnpj;
        }

        //construtor
        public Pessoa_Juridica(string nome,string cnpj)
        {
           setNome_Consumidor(nome);
           this.cnpj_PessoaJ = cnpj;
        }
    }
}
