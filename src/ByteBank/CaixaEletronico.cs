using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ByteBank
{
    class CaixaEletronico
    {
        public CaixaEletronico()
        {

        }

        private List<ContaCorrente> contas = new List<ContaCorrente>();
        private ContaCorrente ContaGenerica;

        public void Cadastrar(string nome, string cpf, int senha)
        {
            ContaGenerica = new ContaCorrente(nome, cpf, senha);
            contas.Add(ContaGenerica);
            ContaGenerica.printarDados();
        }

        public int Login(string cpf, int senha)
        {
            int tamList = contas.Count;
            for (int i = 0; i < tamList; i++)
                if (contas[i].Titular.CPF == cpf && contas[i].Senha == senha)
                    return i;
            return -1;
        }

        public void VerSaldo(int i)
        {
            Console.WriteLine($"\nConta: {contas[i].Agencia} {contas[i].Conta}\n" +
                              $"Saldo: R${contas[i].Saldo}");
        }

        public void Depositar(int i, int valorDeposito)
        {
            contas[i].Saldo += valorDeposito;
            Console.WriteLine($"\nConta: {contas[i].Agencia} {contas[i].Conta}\n" +
                              $"Novo saldo: R${contas[i].Saldo}");
        }

        public bool Sacar(int i, int valorSaque)
        {
            if (contas[i].Saldo >= valorSaque)
            {
                contas[i].Saldo -= valorSaque;
                return true;
            }
            return false;
        }

        public int acharPessoa(int agencia, int conta, string CpftitularTransferencia)
        {
            int tamList = contas.Count;
            for (int i = 0; i < tamList; i++)
            {
                if (contas[i].Agencia == agencia && contas[i].Conta == conta && contas[i].Titular.CPF == CpftitularTransferencia)
                {
                    contas[i].printarDadosTransferencia();
                    return i;
                }
            }
            return -1;
        }

        public void Transferencia(int i, int i2, int valorTransferencia)
        {
            if (contas[i].Saldo >= valorTransferencia)
            {
                contas[i].Saldo -= valorTransferencia;
                contas[i2].Saldo += valorTransferencia;
                Console.WriteLine($"\nConta: {contas[i].Agencia} {contas[i].Conta}\n" +
                                  $"Novo saldo: R${contas[i].Saldo}");
            }
            else
                Console.WriteLine("\nNao ha saldo disponivel!");
        }
    }
}
