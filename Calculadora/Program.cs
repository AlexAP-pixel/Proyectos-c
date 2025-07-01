using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n\nCalculadora");
            Console.WriteLine("---------------");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Sumar();
                    break;
                case "2":
                    Restar();
                    break;
                case "3":
                    Multiplicar();
                    break;
                case "4":
                    Dividir();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                    break;
            }
        }
        
    }

    static void Sumar()
    {
        Console.Write("Ingresa el primer número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingresa el segundo número:");
        double num2 = Convert.ToDouble(Console.ReadLine());
        double resultado = num1 + num2;
        Console.WriteLine($"El resultado de la suma es: {resultado}");
    }

    static void Restar()
    {
        Console.Write("Ingresa el primer número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingresa el segundo número:");
        double num2 = Convert.ToDouble(Console.ReadLine());
        double resultado = num1 - num2;
        Console.WriteLine($"El resultado de la resta es: {resultado}");
    }

    static void Multiplicar()
    {
        Console.Write("Ingresa el primer número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingresa el segundo número:");
        double num2 = Convert.ToDouble(Console.ReadLine());
        double resultado = num1 * num2;
        Console.WriteLine($"El resultado de la multiplicacion es: {resultado}");
    }

    static void Dividir()
    {
        Console.Write("Ingresa el primer número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Ingresa el segundo número:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        if (num2 == 0)
        {
            Console.WriteLine("Error: No se puede dividir entre cero.");
        }
        else
        {
            double resultado = num1 / num2;
            Console.WriteLine($"El resultado de la división es: {resultado}");
        }
    }
}
