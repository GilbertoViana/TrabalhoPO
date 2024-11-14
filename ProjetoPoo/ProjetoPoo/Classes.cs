using System;
using System.Collections.Generic;

namespace GestaoAlojamentoLocal
{
    // Classe abstrata que representa uma pessoa com propriedades comuns
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        // Método abstrato para mostrar detalhes, a ser implementado nas classes derivadas
        public abstract void MostrarDetalhes();
    }
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

    public class Cliente : Pessoa
    {
        // Implementação do método para mostrar detalhes do cliente
        public override void MostrarDetalhes()
        {
            Console.WriteLine($"Cliente: {Nome}, Email: {Email}, Telefone: {Telefone}");
        }
    }

    public class Proprietario : Pessoa
    {
        public string Morada { get; set; } // Morada do proprietário

        // Implementação do método para mostrar detalhes do proprietário
        public override void MostrarDetalhes()
        {
            Console.WriteLine($"Proprietário: {Nome}, Email: {Email}, Telefone: {Telefone}, Morada: {Morada}");
        }
    }

    public class Pagamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public Reserva Reserva { get; set; }
    }
}
   