using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Interdisciplinar.Contagem.Leonardo_Pedro_Luiz_Fabricio.MVC_Controller.Classes.Consumidor
{
    public class Pessoa_Juridica: Consumidor//public para serializar
    {
        //atributos
        private string cnpj_PessoaJ;

        //get e set na ordem do XML
        public string nome_MtdPessoaJ
        {
            get
            {
                return nome_AtrbConsumidor;
            }

            set
            {
                nome_AtrbConsumidor = value;
            }
        }
        public string cnpj_MtdPessoaJ
        {
            get
            {
                return cnpj_PessoaJ;
            }

            set
            {
                cnpj_PessoaJ = value;
            }
        }

        //construtor
        public Pessoa_Juridica(string nome,string cnpj)
        {
            nome_MtdPessoaJ=nome;
            cnpj_PessoaJ = cnpj;
        }
        public Pessoa_Juridica() { }//arquivo XML
    }
}
