using System;
using System.Collections.Generic;
using System.Text;
 

namespace ByteBank
{
    public class ContaCorrente
    {
        public ContaCorrente() { 
        }
        public ContaCorrente(Cliente titular, int senha)
        {
            this.Titular = titular;
            this.Senha = senha;
            this.Agencia = random.Next(100, 999);
            this.Conta = random.Next(10000, 99999);
            this.Saldo = 0;
            QuantidadeContas++;
            Taxa = 30.0 / QuantidadeContas;
        }

        public static double Taxa { get; private set; }
        public static int QuantidadeContas { get; private set;}

        private Cliente _titular = new Cliente();
        public Cliente Titular
        {
            get
            {
                return _titular;
            }
            set
            {
                _titular = value;
            }
        }
        public double Saldo { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public int Senha { get; set; }

        Random random = new Random();

        public void PrintarDados()
        {
            Console.WriteLine($"\nByteBank\n" +
                              $"\nTitular da conta: {Titular.Nome}" +
                              $"\nCpf: {Titular.CPF}" +
                              $"\nAgencia: {Agencia}" +
                              $"\nConta: {Conta}" +
                              $"\nSaldo Inicial: {Saldo}");
        }

        public void PrintarDadosTransferencia()
        {
            Console.WriteLine($"\nByteBank" +
                              $"\nTitular da conta: {Titular.Nome}" +
                              $"\nCpf: {Titular.CPF}" +
                              $"\nAgencia: {Agencia}" +
                              $"\nConta: {Conta}");
        }

    }
}
