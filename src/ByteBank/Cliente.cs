using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank
{
    class Cliente
    {
        
        public Cliente(string nome, string cpf)
        {
            this.Nome = nome;
            this.CPF = cpf;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }

    }
}
