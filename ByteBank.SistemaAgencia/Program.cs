using System;
using ByteBank.Modelos;
using Humanizer;
using Humanizer.Localisation;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista Generica
            Lista<int> idades = new Lista<int>();

            idades.AdicionarVarios(1, 3, 5);

            Console.ReadLine();
        }

        static void TesteListaContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            lista.Adicionar(new ContaCorrente(111, 11111));
            lista.Adicionar(new ContaCorrente(222, 22222));
            lista.Adicionar(new ContaCorrente(333, 33333));
            lista.Adicionar(new ContaCorrente(444, 44444));
            lista.Adicionar(new ContaCorrente(555, 55555));

            lista.AdicionarVarios(
                new ContaCorrente(100, 40010),
                new ContaCorrente(101, 40011),
                new ContaCorrente(102, 40012),
                new ContaCorrente(103, 40013)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }

        static void Extractor()
        {
            string url = "http://www.bytebank.com.br/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(url);

            string valorOrigem = extrator.GetValor("moedaOrigem");
            string valorDestino = extrator.GetValor("moedaDestino");
            string valor = extrator.GetValor("valor");

            Console.WriteLine("Moeda Origem: " + valorOrigem);
            Console.WriteLine("Moeda Destino: " + valorDestino);
            Console.WriteLine("Valor: " + valor);
        }

        static void GetInterval()
        {
            DateTime dataFimPagamento = new DateTime(2022, 01, 17);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = dataFimPagamento - dataCorrente;

            // Humanizer - Biblioteca para trabalhar intervalos de tempos
            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca, 3, null, TimeUnit.Year);

            Console.WriteLine(mensagem);
        }
    }
}
