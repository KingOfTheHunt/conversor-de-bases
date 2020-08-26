using System;
using System.Linq;
using System.Threading;

namespace ConversorDeBases
{
    class Program
    {
        static void Main(string[] args)
        {
            char d;
            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("Conversor de bases");
                    Console.WriteLine();
                    Console.Write("Informe o número na base decimal: ");
                    uint num = uint.Parse(Console.ReadLine());

                    Console.WriteLine();
                    Console.WriteLine("Convertendo...");
                    Thread.Sleep(500);
                    Console.WriteLine($"Binário: {Binario(num)}");
                    Console.WriteLine($"Octal: {Octal(num)}");
                    Console.WriteLine($"Hexadecimal: {Hexadecimal(num)}");
                    
                    Console.WriteLine();
                    do
                    {
                        Console.Write("Deseja realizar mais uma conversão (s/n)? ");
                        d = Console.ReadLine().ToLower()[0];
                    } while (d != 's' && d != 'n');

                    if (d == 'n')
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.Write("O valor informado está em um formato incorreto!");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Obrigado por usar o Conversor de Base.");
            Console.ReadKey();
        }

        static string Binario(uint valor)
        {
            string novoValor = "";

            do
            {
                novoValor += (valor % 2).ToString();
                valor /= 2;
            } while (valor >= 1);
            return Reverter(novoValor);
        }

        static string Reverter(string valor)
        {
            string novoValor = "";

            for (int i = valor.Length - 1; i >= 0; i--)
            {
                novoValor += valor[i];
            }
            return novoValor;
        }

        static string Octal(uint valor)
        {
            string novoValor = "";

            do
            {
                novoValor += (valor % 8).ToString();
                valor /= 8;
            } while (valor >= 1);
            return Reverter(novoValor);
        }

        static string Hexadecimal(uint valor)
        {
            string novoValor = "";

            do
            {
                novoValor += (valor % 16) switch
                {
                    10 => "A",
                    11 => "B",
                    12 => "C",
                    13 => "D",
                    14 => "E",
                    15 => "F",
                    _ => (valor % 16).ToString(),
                };
                valor /= 16;
            } while (valor >= 1);
            return Reverter(novoValor);
        }
    }
}
