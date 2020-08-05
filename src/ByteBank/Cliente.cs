using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank
{
    public class Cliente
    {
        public Cliente()
        {

        }
        public Cliente(string nome, string cpf)
        {
            this.Nome = nome;
            this.CPF = cpf;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }

    }
}
