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
            contas = new List<ContaCorrente>();
        }

        private List<ContaCorrente> contas;

        public void Cadastrar(Cliente titular, int senha)
        {
            ContaCorrente ContaGenerica = new ContaCorrente(titular, senha);
            contas.Add(ContaGenerica);
            ContaGenerica.PrintarDados();
        }


        /*   Na junção dos codigos utilizar interface IAutenticar ou ILogar   */
        public ContaCorrente Login(string cpfTestado, int senha)
        {
            foreach (var contacorrente in contas)
                if (contacorrente.Titular.CPF == cpfTestado && contacorrente.Senha == senha)
                    return contacorrente;
            return null;
        }

        public void VerSaldo(ContaCorrente usuario)
        {
            Console.WriteLine($"\nConta: {usuario.Agencia} {usuario.Conta}\n" +
                              $"Saldo: R${usuario.Saldo}");
        }

        public void Depositar(ContaCorrente usuario, int valorDeposito)
        {
            usuario.Saldo += valorDeposito;
            Console.WriteLine($"\nConta: {usuario.Agencia} {usuario.Conta}\n" +
                              $"Novo saldo: R${usuario.Saldo}");
        }

        public bool Sacar(ContaCorrente usuario, int valorSaque)
        {
            if (usuario.Saldo >= valorSaque)
            {
                usuario.Saldo -= valorSaque;
                return true;
            }
            return false;
        }

        public ContaCorrente ProcurarDestinatario(int agencia, int conta, string cpfTitularTransferencia)
        {
            foreach(var usuario in contas)
            {
                if (usuario.Agencia == agencia && usuario.Conta == conta && usuario.Titular.CPF == cpfTitularTransferencia)
                {
                    usuario.PrintarDadosTransferencia();
                    return usuario;
                }
            }
            return null;
        }

        public void Transferencia(ContaCorrente origem, ContaCorrente destinatario, int valorTransferencia)
        {
            if (origem.Saldo >= valorTransferencia)
            {
                Sacar(origem, valorTransferencia);
                Depositar(destinatario, valorTransferencia);
                Console.WriteLine($"\nConta: {origem.Agencia} {origem.Conta}\n" +
                                  $"Novo saldo: R${origem.Saldo}");
            }
            else
                Console.WriteLine("\nNao ha saldo disponivel!");
        }
    }
}
