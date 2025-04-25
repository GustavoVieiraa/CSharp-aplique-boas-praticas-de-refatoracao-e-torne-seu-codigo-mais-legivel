using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercicios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numero1 = LerNumero();
            int numero2 = LerNumero();

            int soma = SomarNumeros(numero1, numero2);
            Console.WriteLine($"A soma é: {soma}");

            int subtracao = SubtrairNumeros(numero1, numero2);
            Console.WriteLine($"A subtração é: {subtracao}");

            int multiplicacao = MultiplicarNumeros(numero1, numero2);
            Console.WriteLine($"A multiplicação é: {multiplicacao}");

            double divisao = DividirNumeros(numero1, numero2);
            if (divisao != 0)
            {
                Console.WriteLine($"A divisão é: {divisao}");
            }
            else
            {
                Console.WriteLine($"Não é possível dividir por zero.");
            }

            Console.ReadLine();

        }


        static int LerNumero()
        {
            Console.WriteLine("Digite um número: ");
            int numero = int.Parse(Console.ReadLine());
            return numero;
        }

        static int SomarNumeros(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        static int SubtrairNumeros(int numero1, int numero2)
        {
            return numero1 - numero2;
        }

        static int MultiplicarNumeros(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        static double DividirNumeros(int numero1, int numero2)
        {
            if (numero2 != 0)
            {
                return (double)numero1 / numero2;
            }
            else
            {
                return 0;
            }
        }
    }
}
