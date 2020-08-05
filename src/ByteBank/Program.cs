using System;

namespace ByteBank
{
    class Program
    {
        private static CaixaEletronico caixaEletronico = new CaixaEletronico();


        static void Main(string[] args)
        {
            int opcaoMenu;
            int opcaoCadastro;
            int opcaoMenuExterno;

            var usuario = new ContaCorrente();

            do      // Inicio do programa
            {
                do // Inicio Loop login e cadastro
                {
                    do      // Inicio Loop opções iniciais para cadastrar/ pular cadastro/ sair
                    {
                        PrintarMenuCadastro();
                        opcaoCadastro = int.Parse(Console.ReadLine());
                        // Fim Loop opções iniciais para cadastrar/ pular cadastro/ sair
                    } while (opcaoCadastro < 0 || opcaoCadastro > 2);

                    if (opcaoCadastro == 1)     //Abrir conta no ByteBank
                    {
                        CadastrarCliente();
                    }
                    else if (opcaoCadastro == 0)    //Encerrar Programa
                        return;
                    // se diferente de 0 e 1 continua o fluxo
                    usuario = RealizarLogin();  // Realiza o login do usuario

                } while (usuario == null); // Fim Loop login e cadastro

                do      // Inicio Loop Funcionalidades do programa
                {
                    do // Inicio Loop opções menu
                    {
                        PrintaMenuOpcoesUsuario();
                        opcaoMenu = int.Parse(Console.ReadLine());
                    } while (opcaoMenu > 4 || opcaoMenu < 0); // Fim Loop opções menu


                    switch (opcaoMenu)
                    {

                        case 1: // Printar saldo do usuario
                            caixaEletronico.VerSaldo(usuario);
                            break;

                        case 2: // Realizar deposito do usuario
                            RealizarDeposito(usuario);
                            break;

                        case 3: // realizar Saque do usuario
                            RealizarSaque(usuario);
                            break;

                        case 4: // Realizar transferencia do usuario
                            RealizarTransferencia(usuario);
                            break;

                        case 0:
                            break;
                    }
                } while (opcaoMenu != 0); // Fim Loop Funcionalidades do programa

                do      // Inicio Loop Validacao menu Realizar novamente
                {
                    PrintarMenuRealizarNovaOperacao();
                    opcaoMenuExterno = int.Parse(Console.ReadLine());
                } while (opcaoMenuExterno < 0 || opcaoMenuExterno > 1); // Fim Loop Validacao menu Realizar novamente

                switch (opcaoMenuExterno)
                {
                    case 1:     // Realiza nova operacao
                        break;
                    case 0:     // Encerra programa
                        return;
                } // Opcao nova opracao

            } while (true); // Fim do Programa
        }

        public static void PrintarMenuCadastro()
        {
            Console.Write("\nDeseja se cadartrar no ByteBank?\n" +
                          "(1) Sim\n" +
                          "(2) Nao\n" +
                          "(0). Sair\n" +
                          "opcao: ");
        }

        public static void CadastrarCliente()
        {
            int senha;

            string cpf;
            string nome;

            Console.Write("\nDigite seu nome completo: ");
            nome = Console.ReadLine();

            senha = CadastrarSenha();
            Console.Write("Digite seu cpf: ");

            cpf = Console.ReadLine();
            caixaEletronico.Cadastrar(new Cliente(nome, cpf), senha);

        }
        public static int CadastrarSenha()
        {
            int senha;
            int testeSenha;
            do
            {
                Console.Write("\nDigite sua senha: ");
                senha = int.Parse(Console.ReadLine());
                Console.Write("Digite novamente sua senha: ");
                testeSenha = int.Parse(Console.ReadLine());
                if (senha != testeSenha)
                    Console.WriteLine("\nAs senhas nao correspondem, tente novamente!");
            } while (senha != testeSenha);
            return senha;

        }

        public static ContaCorrente RealizarLogin()
        {
            string cpfTitular;
            int senha;

            Console.Write("\nLogin:\n" +
              "Cpf: ");
            cpfTitular = Console.ReadLine();

            Console.Write("Senha: ");
            senha = int.Parse(Console.ReadLine());

            return caixaEletronico.Login(cpfTitular, senha);

        }

        static void PrintaMenuOpcoesUsuario()
        {
            Console.Write("\nDigite a opcao desejada: \n" +
                  "(1). Saldo\n" +
                  "(2). deposito\n" +
                  "(3). Saque\n" +
                  "(4). Transferencia\n" +
                  "(0). Encerrar\n" +
                  "Opcao: ");
        }

        public static void RealizarDeposito(ContaCorrente usuario)
        {
            int valorDeposito;

            do
            {
                Console.WriteLine("\nDigite o valor a ser depositado: \n" +
                              "(Nao coloque moedas, apenas notas)");
                valorDeposito = int.Parse(Console.ReadLine());
            } while (valorDeposito <= 0);
            caixaEletronico.Depositar(usuario, valorDeposito);
        }

        public static void RealizarSaque(ContaCorrente usuario)
        {
            int valorSaque;
            do
            {
                Console.WriteLine("\nDigite o valor a ser sacado: \n" +
                              "(Nao há saque que em moedas, apenas notas)");
                valorSaque = int.Parse(Console.ReadLine());
            } while (valorSaque <= 0);

            if (caixaEletronico.Sacar(usuario, valorSaque) == true)
                Console.WriteLine("\nValor sacado!");

            else
                Console.WriteLine("\nNao há saldo suficiente!");
        }

        public static void RealizarTransferencia(ContaCorrente usuario)
        {
            ContaCorrente destinatario = new ContaCorrente();

            int agencia;
            int conta;
            int valorTransferencia;
            int opcaoTransferencia;

            string cpfTitularTransferencia;
            do
            {
                Console.Write("\nTransferencia Bancaria:\n" +
                              "Digite a agencia: ");
                agencia = int.Parse(Console.ReadLine());

                Console.Write("\nDigite o numero da conta: ");
                conta = int.Parse(Console.ReadLine());

                Console.Write("\nDigite o Cpf do titular: ");
                cpfTitularTransferencia = Console.ReadLine();

                Console.WriteLine("\nDigite o valor da transferencia: ");

                valorTransferencia = int.Parse(Console.ReadLine());

                destinatario = caixaEletronico.ProcurarDestinatario(agencia, conta, cpfTitularTransferencia);

                if (destinatario == null)
                {
                    Console.WriteLine("\nEssa conta nao esta cadastrada no sistema");
                    do
                    {
                        Console.Write("\nDigite:" +
                                      "\n(1) Digitar novamente" +
                                      "\n(0) Sair" +
                                      "\nOpcao: ");
                        opcaoTransferencia = int.Parse(Console.ReadLine());
                    } while (opcaoTransferencia < 0 || opcaoTransferencia > 1);
                }

                else
                {
                    do      // Inicio Loop confirmacao da transferencia
                    {
                        // Se localizado o destinatario, o metodo printa os dados dele
                        Console.Write("\nDigite:" +
                                      "\n(1) Confirmar" +
                                      "\n(2) Digitar novamente" +
                                      "\n(0) Sair\n" +
                                      "Opcao: ");
                        opcaoTransferencia = int.Parse(Console.ReadLine());
                        // Fim Loop confirmacao da transferencia
                    } while (opcaoTransferencia < 0 || opcaoTransferencia > 2);

                    switch (opcaoTransferencia)
                    {
                        case 1:     // Realizar Transferencia
                            caixaEletronico.Transferencia(usuario, destinatario, valorTransferencia);
                            opcaoTransferencia = 0;
                            break;

                        case 2:     // Digitar dados Novamente
                            break;

                        case 0:     // Cancelar
                            opcaoTransferencia = 0;
                            break;
                    }
                }
            } while (opcaoTransferencia != 0);
        }

        public static void PrintarMenuRealizarNovaOperacao()
        {
            Console.Write("\nDigite: " +
                                      "\n(1). Realizar outra operacao: " +
                                      "\n(0). Sair" +
                                      "\nOpção: ");
        }

    }
}
