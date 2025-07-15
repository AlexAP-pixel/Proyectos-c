using System; // Nombre del archivo: Program.cs
using System.Collections.Generic;

class Program
{
    static List<string> tareas = new List<string>(); // Lista tareas
    
    static void Main(string[] strings)
    {
        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Lista de Tareas");
            Console.WriteLine("---------------");
            Console.WriteLine("1. Ver tarea");
            Console.WriteLine("2. Agregar tarea");
            Console.WriteLine("3. Eliminar tarea");
            Console.WriteLine("4. Salir");
            Console.Write("\nSeleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    VerTareas();
                    break;
                case "2":
                    AgregarTarea();
                    break;
                case "3":
                    EliminarTarea();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar...");
                    break;
            }
        }
    }

    static void VerTareas()
    {
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas en la lista.");
        }
        else
        {
            Console.WriteLine("Tareas:");
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }
    }

    static void AgregarTarea()
    {
        Console.Write("Ingresa la nueva tarea: ");
        string tarea = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(tarea))
        {
            tareas.Add(tarea);
            Console.WriteLine("Tarea agregada con éxito!");
        }
        else
        {
            Console.WriteLine("La tarea no puede estar vacía");
        }
    }

    static void EliminarTarea()
    {
        VerTareas();
        if (tareas.Count > 0)
        {
            Console.Write("Ingresa el número de la tarea a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tareas.Count)
            {
                tareas.RemoveAt(indice - 1);
                Console.WriteLine("Tarea eliminada con éxito!");
            }
            else
            {
                Console.WriteLine("Número de tarea no válido.");
            }
        }
        else
        {
            Console.WriteLine("No hay tareas para eliminar.");
        }
    }
}
