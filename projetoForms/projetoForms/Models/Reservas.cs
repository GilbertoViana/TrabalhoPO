using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoForms.Models
{
    public class Reserva
     {
        // Variável estática para manter o último ID gerado
         private static int ultimoId = 0;
         private int id;

        // O ID agora é definido automaticamente
         public int Id { get; private set; } 
         public DateTime DataInicio { get; set; }
         public DateTime DataFim { get; set; }
         public Pessoas Cliente { get; set; }
         public Alojamento Alojamento { get; set; }
         public decimal ValorTotal { get; set; }

        // Construtor da classe, que recebe um id para inicializar a reserva
         public Reserva(int id)
         {
            // Define o ID da reserva com o valor passado no construtor
            Id = id;
         }

      }   
}
