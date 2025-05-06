using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
namespace estacionamento.Models
{

    public class Estacionamento
    {
        // Lista utilizada para adicionar NOME DO CLIENTE, CPF CLIENTE, MODELO VEICULAR E PLACA DO VEÍCULO.
        List<string> listaVeiculo = new List<string>();

        // Lista utilizada para adicionar um Horário.
        List<DateTime> listaHora = new List<DateTime>();

        // Variáveis para armazenar informações do cliente e veículo.
        string nomeCliente;
        string cpfCliente;
        string modeloVeicular;
        string placaVeiculo;

        // Variáveis relacionadas ao cálculo do estacionamento.
        decimal valorInicial;
        decimal valorHora;
        decimal qtdHora;

        // Método para definir o preço inicial e o valor por hora do estacionamento.
        public void Total()
        {
            Console.WriteLine("Informe o preço inicial: ");
            valorInicial = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o valor do preço por hora: ");
            valorHora = Convert.ToInt32(Console.ReadLine());
        }

        // Método para cadastrar um veículo no sistema.
        public void CadastraVeiculo()
        {
            Console.Clear();

            Console.WriteLine("Informe o nome do Cliente: ");
            nomeCliente = Console.ReadLine();

            Console.WriteLine("Informe o CPF do Cliente: ");
            cpfCliente = Console.ReadLine();

            Console.WriteLine("Informe o Modelo Veicular: ");
            modeloVeicular = Console.ReadLine();

            Console.WriteLine("Informe a Placa do Veiculo: ");
            placaVeiculo = Console.ReadLine();

            Console.Clear();

            // Exibe as informações cadastradas.
            Console.WriteLine($"Nome Cliente: {nomeCliente}\n" +
            $"CPF Cliente: {cpfCliente}\n" +
            $"Modelo do Veiculo: {modeloVeicular}\n" +
            $"Placa do Veiculo: {placaVeiculo}");

            // Adiciona as informações na lista de veículos.
            listaVeiculo.Add($"Nome Cliente: {nomeCliente}");
            listaVeiculo.Add($"Cpf Cliente: {cpfCliente}");
            listaVeiculo.Add($"Modelo Veiculo: {modeloVeicular}");
            listaVeiculo.Add($"Placa Veiculo: {placaVeiculo}");

            // Obtém o horário atual e exibe conforme o período do dia.
            DateTime horaEntrada = DateTime.Now;
            if (horaEntrada.Hour >= 5 && horaEntrada.Hour <= 12)
            {
                Console.WriteLine($"Entrada do veiculo: {horaEntrada.ToString("HH:mm") + " da manhã"}");
            }
            else if (horaEntrada.Hour >= 13 && horaEntrada.Hour <= 17)
            {
                Console.WriteLine($"Entrada do veiculo: {horaEntrada.ToString("HH:mm") + " da tarde"}");
            }
            else if (horaEntrada.Hour >= 18 && horaEntrada.Hour <= 23)
            {
                Console.WriteLine($"Entrada do veiculo: {horaEntrada.ToString("HH:mm") + " da noite"}");
            }
            else
            {
                Console.WriteLine($"Entrada do veiculo: {horaEntrada.ToString("HH:mm") + " da madrugada"}");
            }

            // Adiciona o horário na lista de horários.
            listaHora.Add(horaEntrada);

            // Pergunta ao usuário se deseja cadastrar outro veículo.
            Console.WriteLine("Deseja cadastrar outro usuário? [SIM] ou [NAO]");
            string opcaoVerificacao = Console.ReadLine();

            // Se SIM, reinicia o cadastro.
            if (opcaoVerificacao == "SIM" || opcaoVerificacao == "sim")
            {
                Console.Clear();
                CadastraVeiculo();
            }
            else
            {
                // Retorna ao menu.
                Console.Clear();
                
                Console.WriteLine("Retornando ao MENU");
                Console.WriteLine("Pressione qualquer tecla para retornar ao MENU");
                
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Método para remover um veículo do estacionamento.
        public void RemoverVeiculo()
        {
            Console.WriteLine("Informe a Placa do veiculo: ");
            string verificarPlacaVeiculo = Console.ReadLine();

            // Verifica se a placa informada corresponde a um veículo cadastrado.
            if (verificarPlacaVeiculo == placaVeiculo)
            {
                listaVeiculo.Remove(nomeCliente);

                Console.WriteLine("Informe por quantas horas o veiculo ficou no ESTACIONAMENTO");
                qtdHora = Convert.ToInt32(Console.ReadLine());

                // Calcula o valor total a pagar.
                decimal total = valorHora * qtdHora + valorInicial;
                Console.WriteLine($"Cliente removido com sucesso, valor total a pagar: {total}");

                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Placa {verificarPlacaVeiculo} não encontrada");
                Console.WriteLine("Pressione qualquer tecla para retornar ao MENU");
                Console.ReadKey();
            }
        }

        // Método para buscar um usuário pelo nome.
        public void BuscarUsuarios()
        {
            Console.Clear();

            Console.WriteLine("Informe o nome do cliente: ");
            string opcaoVerificarNomeUsuario = Console.ReadLine();

            // Verifica se o nome informado corresponde a um cliente cadastrado.
            if (opcaoVerificarNomeUsuario == nomeCliente)
            {
                Console.WriteLine("Buscando usuario cadastrado:\n");
                foreach (string buscarCliente in listaVeiculo)
                {
                    Console.WriteLine($"{buscarCliente}");
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine($"Desculpe, não encontramos nenhum usuário com o nome: {opcaoVerificarNomeUsuario}");
            }

            Console.WriteLine("Pressione qualquer tecla para retornar ao MENU");
            Console.ReadKey();
            Console.Clear();
        }
    }
}