using System;
using System.Collections.Generic;

namespace GestaoAlojamentoLocal
{
    public class Alojamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Capacidade { get; set; }
        public decimal PrecoPorNoite { get; set; }
    }

    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Cliente Cliente { get; set; }
        public Alojamento Alojamento { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }

    public class Proprietario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Morada { get; set; }
    }

    public class Pagamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public Reserva Reserva { get; set; }
    }
}
   