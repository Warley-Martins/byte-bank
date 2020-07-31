using System;
using System.Collections.Generic;
using System.Text;
 

namespace ByteBank
{
    public class ContaCorrente
    {

        public ContaCorrente(string nome, string cpf, int senha)
        {
            this.Titular = new Cliente(nome, cpf);
            this.Senha = senha;
            this.Agencia = random.Next(100, 999);
            this.Conta = random.Next(10000, 99999);
            this.Saldo = 0;
            QuantidadeContas++;
        }

        public static int QuantidadeContas { get; private set;}

        internal Cliente Titular { get; set; }
        public double Saldo { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public int Senha { get; set; }

        Random random = new Random();

        public void printarDados()
        {
            Console.WriteLine($"\nByteBank\n" +
                              $"Titular da conta: {Titular.Nome}\n" +
                              $"Cpf: {Titular.CPF}" +
                              $"Agencia: {Agencia}\n" +
                              $"Conta: {Conta}\n" +
                              $"Saldo Inicial: {Saldo}");
        }

        public void printarDadosTransferencia()
        {
            Console.WriteLine($"\nByteBank\n" +
                              $"Titular da conta: {Titular.Nome}\n" +
                              $"Cpf: {Titular.CPF}" +
                              $"Agencia: {Agencia}\n" +
                              $"Conta: {Conta}\n");
        }

    }
}
