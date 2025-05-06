using estacionamento.Models;


// Instancia um objeto da classe Estacionamento
Estacionamento estacionar = new Estacionamento();

// Exibe uma mensagem de boas-vindas ao usuário
Console.WriteLine("bem vindo ao sistema de estacionamento!");

// Chama o método Total para definir valores do estacionamento
estacionar.Total();

// Limpa a tela após a definição dos valores iniciais
Console.Clear();

// Declara uma variável booleana que controla a execução do menu
bool menu = true;

// Declara uma variável para armazenar a opção escolhida pelo usuário
string opcao;

// Início do loop que mantém o menu ativo até que o usuário escolha sair
do
{
    // Limpa a tela a cada iteração do menu
    Console.Clear();

    // Exibe as opções disponíveis no sistema
    Console.WriteLine("Digite uma opção: ");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Sair");

    // Recebe a opção digitada pelo usuário
    opcao = Console.ReadLine();

    // Limpa a tela antes de processar a opção escolhida
    Console.Clear();

    // Verifica se a entrada do usuário é um número inteiro válido
    if (int.TryParse(opcao, out int menuOpcao))
    {
        // Se for um número válido, executa o código correspondente à opção escolhida
        switch (menuOpcao)
        {
            // Opção 1: Chama o método para cadastrar um veículo
            case 1:
                estacionar.CadastraVeiculo();
                break;

            // Opção 2: Chama o método para remover um veículo
            case 2:
                estacionar.RemoverVeiculo();
                break;

            // Opção 3: Chama o método para buscar usuários
            case 3:
                estacionar.BuscarUsuarios();
                break;

            // Opção 4: Finaliza a execução do programa
            case 4:
                menu = false;
                Console.WriteLine("Programa encerrado!");
                break;

            // Caso o usuário digite uma opção inválida
            default:
                Console.WriteLine("Operação inválida!");
                break;
        }
    }
    else
    {
        // Caso o usuário não digite um número válido
        Console.WriteLine("Operação inválida");
    }

    // O loop continua enquanto a variável 'menu' for verdadeira
} while (menu);