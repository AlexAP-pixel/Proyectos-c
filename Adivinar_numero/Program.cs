using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Variables
        Random random = new Random();
        int numeroSecreto = random.Next(1, 101);
        int intentos = 0;
        List<int> intentosRealizados = new List<int>();

        // Instrucciones
        Console.WriteLine("¡Juego de Adivinar el Número!");
        Console.WriteLine("===================================");
        Console.WriteLine("Estoy pensando en un número entre 1 y 100.");
        Console.WriteLine("Intenta adivinarlo. Tienes 10 intentos");
        Console.WriteLine("- Ingresa el numero que estoy pensando: ");
        Console.WriteLine("- Si quieres salir, escribe 'salir'.");

        // Bucle principal del juego
        while (intentos < 10)
        {
            Console.Write("Entrada: ");
            string numeroIngresado = Console.ReadLine();

            if (numeroIngresado?.ToLower() == "salir")
            {
                Console.WriteLine("Has salido del juego. ¡Chau!");
                return;
            }


            if (int.TryParse(numeroIngresado, out int numeroIngresadoInt))
            {
                if (numeroIngresadoInt > numeroSecreto)
                {
                    Console.WriteLine("El número es menor. Intenta de nuevo.");
                    intentos++;
                }
                else if (numeroIngresadoInt < numeroSecreto)
                {
                    Console.WriteLine("El número es mayor. Intenta de nuevo");
                    intentos++;
                }
                else if (numeroIngresadoInt == numeroSecreto)
                {
                    Console.WriteLine($"Felicidades el numero era {numeroSecreto} lo adivinaste en {intentos + 1} intentos.");
                    return;
                }
                else
                {
                    Console.WriteLine("Ese dato no es valido.");
                    Console.WriteLine("Ingrese otro numero");
                }

            }
            else
            {
                Console.WriteLine("Entrada no valida");
            }
        }
        Console.WriteLine("Se terminarion tus intentos el numero era " + numeroSecreto);
    }
}
