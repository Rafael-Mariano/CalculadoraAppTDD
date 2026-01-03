using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using CalculadoraApp;
public class Program
{
    public static void Main(string[] args)
    {
        string dataAtual = DateTime.Now.ToString("dd/MM/yyyy");

        Calculadora calculadora = new Calculadora(dataAtual);

        while (true)
        {
            Console.WriteLine("=== MENU DA CALCULADORA ===");
            Console.WriteLine("Selecione a operação desejada:");
            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Subtrair");
            Console.WriteLine("3 - Multiplicar");
            Console.WriteLine("4 - Dividir");
            Console.WriteLine("5 - Histórico");

            string escolha = Console.ReadLine();

            int resultado = 0;

            switch (escolha)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    (int numero1, int numero2) = ColetaDados();

                    if (escolha == "1")
                    {
                        resultado = calculadora.somar(numero1, numero2);
                    }
                    else if (escolha == "2")
                    {
                        resultado = calculadora.subtrair(numero1, numero2);
                    }
                    else if (escolha == "3")
                    {
                        resultado = calculadora.multiplicar(numero1, numero2);
                    }
                    else if (escolha == "4")
                    {
                        try
                        {
                            resultado = calculadora.dividir(numero1, numero2);
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Erro: Divisão por zero não é permitida.");
                            Console.ReadKey();
                            continue;
                        }
                    }

                    Console.WriteLine("O resultado é: " + resultado);
                    break;
                case "5":
                    Console.WriteLine("Histórico das últimas operações:");
                    List<string> historicoOperacoes = calculadora.historico();
                    foreach (string registro in historicoOperacoes)
                    {
                        Console.WriteLine(registro);
                    }
                    break;
                default:
                    Console.WriteLine("Operação inválida.");
                    break;
            }
        }
    }

    private static (int, int) ColetaDados()
    {
        Console.WriteLine("Digite o primeiro número: ");
        int numero1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite o segundo número: ");
        int numero2 = Convert.ToInt32(Console.ReadLine());

        return (numero1, numero2);
    }

}

