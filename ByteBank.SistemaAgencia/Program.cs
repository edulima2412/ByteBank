using System;
using Humanizer;
using Humanizer.Localisation;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dataFimPagamento = new DateTime(2022, 01, 17);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = dataFimPagamento - dataCorrente;

            // Humanizer - Biblioteca para trabalhar intervalos de tempos
            string mensagem = "Vencimento em "+ TimeSpanHumanizeExtensions.Humanize(diferenca,3,null, TimeUnit.Year);

            Console.WriteLine(mensagem);

            Console.ReadLine();
        }

        
    }
}
