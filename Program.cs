using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        int maquina1 = 150;
        int maquina2 = 200;
        bool sistemaAtivo = true; // Variável para controlar o loop do sistema

        string usuario = LerUsuario();
        // Menu inicial do sistema
        while (sistemaAtivo) // O loop continuará enquanto sistemaAtivo for verdadeiro
        {
            MostrarCabecalho($"{usuario} TESTANDO");
            Console.WriteLine("===== SISTEMAS DE MAQUINAS =====");
            Console.WriteLine("1 - Relátórios.");
            Console.WriteLine("2 - Fazer fechamento das máquinas.");
            Console.WriteLine("3 - Sair.");
            //Criei um método e estou usando para ler o número digitado pelo usuário, 
            // assim evitando que o sistema quebre caso o usuário digite uma letra ou símbolo
            int decisao = LerNumero();

            //Condição para verificar se o usuário digitou um número inteiro válido
            if (decisao < 1 || decisao > 3)
            {
                Console.WriteLine("Opção inválida. Por favor, digite um número entre 1 e 3.");
                continue; // Retorna ao início do loop para solicitar a entrada novamente
            }

            //Estrutura de decisão para o menu inicial
            switch (decisao)
            {
                case 1:
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("|             RELATÓRIO                |");
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine($"| Máquina 1 | Saldo: R${maquina1},00          |");
                    Console.WriteLine($"| Máquina 2 | Saldo: R${maquina2},00          |");
                    Console.WriteLine("+--------------------------------------+");
                    Console.WriteLine("");
                    sistemaAtivo = FecharSistema(sistemaAtivo);
                    break;

                //Menu de fechamento das máquinas
                case 2:
                    int maquinaEscolhaFechamento;
                    do
                    {
                        Console.WriteLine($"Selecione qual máquina você deseja fechar:");
                        Console.WriteLine("1 - Máquina 1");
                        Console.WriteLine("2 - Máquina 2");
                        maquinaEscolhaFechamento = LerNumero();
                        //Validando se o usuário digitou um número inteiro válido para a escolha da máquina
                        if (maquinaEscolhaFechamento < 1 || maquinaEscolhaFechamento > 2)
                        {
                            Console.WriteLine("Opção inválida. Por favor, digite 1 ou 2.");
                        }
                    } while (maquinaEscolhaFechamento < 1 || maquinaEscolhaFechamento > 2); // Loop para garantir que o usuário escolha uma máquina válida
                    //Fechamento da máquina 1
                    if (maquinaEscolhaFechamento == 1)
                    {
                        FecharMaquina(maquinaEscolhaFechamento, maquina1);
                        Console.WriteLine("");
                        sistemaAtivo = FecharSistema(sistemaAtivo);

                    }

                    // Fechamento da segunda máquina
                    else if (maquinaEscolhaFechamento == 2)
                    {
                        FecharMaquina(maquinaEscolhaFechamento, maquina2);
                        Console.WriteLine("");
                        sistemaAtivo = FecharSistema(sistemaAtivo);

                    }
                    break;
                case 3:
                    sistemaAtivo = false; // Define a variável como falsa para sair do loop
                    break;
            }
        }
    }

    static void MostrarCabecalho(string titulo)
    {
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine($"|{titulo.PadLeft(27).PadRight(38)}|");
        Console.WriteLine("+--------------------------------------+");
    }

    static int LerNumero()
    {
        int numero;

        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Digite apenas números:");
        }

        return numero;


    }
    static void FecharMaquina(int maquinaEscolhaFechamento, int MaquinaN)
    {
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine($"| MÁQUINA {maquinaEscolhaFechamento.ToString()} ESCOLHIDA PARA FECHAMENTO |");
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine($"Saldo anterior: R${MaquinaN},00");
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine("Qual saldo atual?");
        int maquinaatual = LerNumero();
        int lucro = maquinaatual - MaquinaN;
        Console.WriteLine("Quanto ela pagou?");
        int pagamentoMaquina = LerNumero();
        Console.WriteLine("+--------------------------------------+");
        Console.WriteLine($"+--------RELATÓRIO MAQUINA {maquinaEscolhaFechamento}------------+");
        Console.WriteLine($"| Saldo anterior: R${MaquinaN},00");
        Console.WriteLine($"| Saldo atual: R${maquinaatual},00");
        Console.WriteLine($"| Pagamento: R${pagamentoMaquina},00");
        Console.WriteLine($"| Lucro: R${lucro},00");
        Console.WriteLine("+---------------------------------------+");

    }

    static string LerUsuario()
    {
        while (true)
        {
            Console.WriteLine("Digite seu nome de usuário: ");
            string usuario = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(usuario) && !usuario.Any(char.IsDigit)) //Esse método verifica se o usuário digitou algo diferente de espaço em 
            // branco ou vazio e o método Any verifica se o usuário digitou algum número, caso tenha digitado algum número, o sistema não aceitará e pedirá para digitar novamente
            {
                Console.WriteLine($"Bem-vindo, {usuario}!");
                return usuario;
            }
            else
            {
                Console.WriteLine("Nome de usuário não pode ser vazio ou conter números.");
            }
        }
    }

    static bool FecharSistema(bool sistemaAtivo)
    {
        Console.WriteLine("[1] Retornar");
        Console.WriteLine("[2] Sair");
        int decisao = LerNumero();
        if (decisao == 2)
        {
            Console.WriteLine("Saindo do sistema...");
            sistemaAtivo = false;
        }
        else if (decisao == 1)
        {
            Console.WriteLine("Retornando ao menu principal...");
        }
        else
        {
            Console.WriteLine("Opção inválida. Retornando ao menu principal...");
        }
        return sistemaAtivo;
    }
}
