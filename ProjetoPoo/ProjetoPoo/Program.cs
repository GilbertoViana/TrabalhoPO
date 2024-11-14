using System;

namespace GestaoAlojamentoLocal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Utilizado para chamar métodos das classes e guardar dados em "gestão"
            GestaoAlojamentoService gestao = new GestaoAlojamentoService(); 

            // Adicionar um cliente
            Cliente cliente = gestao.AdicionarCliente(1, "João Silva", "joao@email.com", "123456789");

            // Mostra os detalhes do cliente
            cliente.MostrarDetalhes();

            // Adiciona um alojamento para a reserva
            Alojamento alojamento = new Alojamento
            {
                Id = 1,
                Nome = "Casa no Centro",
                Endereco = "Rua Principal, 123",
                Capacidade = 4,
                PrecoPorNoite = 75.00m
            };

            // Adiciona um Proprietario
            Proprietario proprietario = new Proprietario
            {
                Id = 1,
                Nome = "Ana Sousa",
                Email = "ana@email.com",
                Telefone = "987654321",
                Morada = "Rua da Liberdade, 100"
            };

            // Mostra os detalhes do Proprietario
            proprietario.MostrarDetalhes();

            // Define as datas de início e fim da reserva
            DateTime dataInicio = new DateTime(2024, 12, 20);
            DateTime dataFim = new DateTime(2024, 12, 25);

            // Adicionar uma reserva para o cliente
            Reserva reserva = gestao.AdicionarReserva(1, dataInicio, dataFim, cliente, alojamento);

            //Mostra as informações da reserva
            Console.WriteLine($"Cliente: {cliente.Nome} fez uma reserva no {alojamento.Nome}.");
            Console.WriteLine($"Data de Início: {reserva.DataInicio.ToShortDateString()}, Data de Fim: {reserva.DataFim.ToShortDateString()}");
            Console.WriteLine($"Valor Total: {reserva.ValorTotal}");
        }
    }
}
