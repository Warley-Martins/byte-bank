using System;

namespace ByteBank
{
    class Program
    {

        static void Main(string[] args)
        {
            CaixaEletronico caixaEletronico = new CaixaEletronico();

            int opcaoMenu;
            int opcaoCadastro;
            int opcaoMenuExterno;
            int senha;
            int testeSenha;
            int indice;
            int valorDeposito;
            int valorSaque;
            int agencia;
            int conta;
            int valorTransferencia;
            int opcaoTransferencia;
            int indiceTransferencia;

            string titularTransferencia;
            string titular;

            do
            {
                    do
                    {
                        Console.Write("\nDeseja se cadartrar no ByteBank?\n" +
                                      "(1) Sim\n" +
                                      "(2) Nao\n" +
                                      "(0). Sair\n" +
                                      "opcao: ");
                        opcaoCadastro = int.Parse(Console.ReadLine());
                        if (opcaoCadastro == 1)
                        {
                            Console.Write("\nDigite seu nome completo: ");
                            titular = Console.ReadLine();
                            do
                            {
                                Console.Write("\nDigite sua senha: ");
                                senha = int.Parse(Console.ReadLine());
                                Console.Write("Digite novamente sua senha: ");
                                testeSenha = int.Parse(Console.ReadLine());
                                if (senha != testeSenha)
                                    Console.WriteLine("\nAs senhas nao correspondem, tente novamente!");
                            } while (senha != testeSenha);

                            caixaEletronico.Cadastrar(titular, senha);
                        }
                        else if (opcaoCadastro == 0)
                            return;

                        Console.Write("\nLogin:\n" +
                                      "Titular: ");
                        titular = Console.ReadLine();

                        Console.Write("Senha: ");
                        senha = int.Parse(Console.ReadLine());

                        indice = caixaEletronico.Login(titular, senha);

                    } while (indice == -1);


                //menu
                do
                {
                    do
                    {
                        PrintaMenu();
                        opcaoMenu = int.Parse(Console.ReadLine());
                    } while (opcaoMenu > 4 || opcaoMenu < 0);

                    switch (opcaoMenu)
                    {

                        case 1:

                            caixaEletronico.VerSaldo(indice);
                            break;

                        case 2:

                            do
                            {
                                Console.WriteLine("\nDigite o valor a ser depositado: \n" +
                                              "(Nao coloque moedas, apenas notas)");
                                valorDeposito = int.Parse(Console.ReadLine());
                            } while (valorDeposito <= 0);

                            caixaEletronico.Depositar(indice, valorDeposito);
                            break;

                        case 3:

                            do
                            {
                                Console.WriteLine("\nDigite o valor a ser sacado: \n" +
                                              "(Nao há que em moedas, apenas notas)");
                                valorSaque = int.Parse(Console.ReadLine());
                            } while (valorSaque <= 0);

                            if (caixaEletronico.Sacar(indice, valorSaque) == true)
                                Console.WriteLine("\nValor sacado!");

                            else
                                Console.WriteLine("\nNao ha saldo suficiente!");
                            break;

                        case 4:
                            do
                            {
                                Console.Write("\nTransferencia Bancaria:\n" +
                                              "Digite a agencia: ");
                                agencia = int.Parse(Console.ReadLine());

                                Console.Write("\nDigite o numero da conta: ");
                                conta = int.Parse(Console.ReadLine());

                                Console.Write("\nDigite o nome do titular: ");
                                titularTransferencia = Console.ReadLine();

                                Console.WriteLine("\nDigite o valor da transferencia: ");

                                valorTransferencia = int.Parse(Console.ReadLine());

                                indiceTransferencia = caixaEletronico.acharPessoa(agencia, conta, titularTransferencia);

                                if (indiceTransferencia == -1)
                                {
                                    Console.WriteLine("\nEssa nao esta cadastrada no sistema");
                                    do
                                    {
                                        Console.WriteLine("\nDigite: (1) Digitar novamente (0) Sair\n" +
                                                          "opcao: ");
                                        opcaoTransferencia = int.Parse(Console.ReadLine());
                                    } while (opcaoTransferencia < 0 || opcaoTransferencia > 1);
                                }

                                else
                                {
                                    do
                                    {
                                        Console.WriteLine("\nDigite (1) Confirmar (2) Digitar novamente (0) Sair\n" +
                                                          "opcao: ");
                                        opcaoTransferencia = int.Parse(Console.ReadLine());
                                    } while (opcaoTransferencia < 0 || opcaoTransferencia > 2);
                                    switch (opcaoTransferencia)
                                    {
                                        case 1:
                                            caixaEletronico.Transferencia(indice, indiceTransferencia, valorTransferencia);
                                            opcaoTransferencia = 0;
                                            break;

                                        case 2:
                                            break;

                                        case 0:
                                            opcaoTransferencia = 0;
                                            break;
                                    }
                                }
                            } while (opcaoTransferencia != 0);

                            break;

                        case 0:
                            break;
                    }
                } while (opcaoMenu != 0);

                do
                {
                    Console.WriteLine("\nDigite: \n" +
                                      "(1). Realizar outra operacao: \n" +
                                      "(0). Sair\n");
                    opcaoMenuExterno = int.Parse(Console.ReadLine());
                } while (opcaoMenuExterno < 0 || opcaoMenuExterno > 1);

                switch (opcaoMenuExterno)
                {
                    case 1:
                        break;
                    case 0:
                        return;
                }
            } while (true);
        }

        static void PrintaMenu()
        {
            Console.Write("\nDigite a opcao desejada: \n" +
                  "(1). Saldo\n" +
                  "(2). deposito\n" +
                  "(3). Saque\n" +
                  "(4). Transferencia\n" +
                  "(0). Encerrar\n" +
                  "Opcao: ");
        }
    }
}
