using System;
using System.Collections.Generic;

namespace GestaoAlojamentoLocal
{
    public class GestaoAlojamentoService
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Reserva> reservas = new List<Reserva>();

        // Método para adicionar um cliente
        public Cliente AdicionarCliente(int id, string nome, string email, string telefone)
        {
            Cliente novoCliente = new Cliente
            {
                Id = id,
                Nome = nome,
                Email = email,
                Telefone = telefone
            };

            clientes.Add(novoCliente);
            return novoCliente;
        }

        // Método para adicionar uma reserva
        public Reserva AdicionarReserva(int id, DateTime dataInicio, DateTime dataFim, Cliente cliente, Alojamento alojamento)
        {
            int diasReservados = (dataFim - dataInicio).Days;
            decimal valorTotal = diasReservados * alojamento.PrecoPorNoite;

            Reserva novaReserva = new Reserva
            {
                Id = id,
                DataInicio = dataInicio,
                DataFim = dataFim,
                Cliente = cliente,
                Alojamento = alojamento,
                ValorTotal = valorTotal
            };

            reservas.Add(novaReserva);
            return novaReserva;
        }
    }
}
