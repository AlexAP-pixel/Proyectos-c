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
        Console.WriteLine("Estoy pensando en un número entre 1 y 100.");
        Console.WriteLine("Intenta adivinarlo. Tienes 10 intentos");
        Console.WriteLine("Ingresa el numero que estoy pensando: ");
        Console.WriteLine("Si quieres salir, escribe 'salir'.");

        // Bucle principal del juego
        while (intentos < 10)
        {
            string numeroIngresado = Console.ReadLine();
            int numeroAdivinado = random.Next(1, 101);

            if (numeroIngresado == "salir")
            {
                Console.WriteLine("Has salido del juego. ¡Chau!");
                return;
            }
            else if (int.Trypase(numeroIngresado, out numeroAdivinado))
            {
                intentosRealizados.Add(numeroAdivinado);
                intentos++;

                if (numeroAdivinado < numeroSecreto)
                {
                    Console.WriteLine("El número es mayor. Intenta de nuevo.");
                }
                else if (numeroAdivinado > numeroSecreto)
                {
                    Console.WriteLine("El número es menor. Intenta de nuevo.");
                }
                else
                {
                    Console.WriteLine($"¡Felicidades! Adivinaste el número {numeroSecreto} en {intentos} intentos.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingresa un número entre 1 y 100 o escribe 'salir' para terminar.");
            }

        }
    }
}
