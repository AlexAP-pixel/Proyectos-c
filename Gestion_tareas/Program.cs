// Gestor de Tareas
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Gestion_tareas
{
    public class Tareas // Clase que representa una tarea
    {
        public int Id { get; set; } // Incluye ID
        public string Nombre { get; set; } // Nombre de la tarea
        public string Descripcion { get; set; } // Descripción de la tarea
        public DateTime FechaCreacion { get; set; } // Fecha de creación
        public DateTime FechaVencimiento { get; set; } // Fecha de vencimiento
        public bool Completada { get; set; } // Estado de la tarea
        public Prioridad Prioridad { get; set; } // Prioridad de la tarea

        public Tareas() // Constructor
        {
            FechaCreacion = DateTime.Now; // Fecha de creación
            Completada = false;
        }

        public override string ToString() // Método para representar la tarea como una cadena
        {
            string estado = Completada ? "Completada" : "Pendiente"; // Estado de la tarea
            string FechaVencimiento = FechaVencimiento.ToString("dd/MM/yyyy"); // Formato de fecha para la fecha de vencimiento
            string Prioridad = this.Prioridad switch // Asignación de emoji según la prioridad
            {
                Prioridad.Baja => "Baja",
                Prioridad.Media => "Media",
                Prioridad.Alta => "Alta",
                _ => "Desconocida"
            };
            return $"ID: {Id}, Nombre: {Nombre}, Descripción: {Descripcion}, Fecha de Creación: {FechaCreacion:dd/MM/yyyy}, Fecha de Vencimiento: {FechaVencimiento}, Estado: {estado}, Prioridad: {Prioridad}";
        }
    } 
    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }

    public class GestorTareas // Clase para gestionar las tareas
    {
        private List<Tareas> tareas; // Lista de tareas
        private const string archivoTareas = "tareas.json"; // Archivo donde se guardan las tareas

        public GestorTareas() // Constructor
        {
            tareas = new List<Tareas>();
            CargarTareas(); // Cargar tareas desde el archivo al iniciar
        }

        public void AgregarTarea(Tareas tarea) // Método para agregar una tarea
        {
            tarea.Id = tareas.Count + 1; // Asignar ID a la tarea
            tareas.Add(tarea);
            GuardarTareas(); // Guardar cambios en el archivo
        }

        public void EliminarTarea(int id) // Método para eliminar una tarea por ID
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
                GuardarTareas(); // Guardar cambios en el archivo
            }
        }

        public void MarcarComoCompletada(int id) // Método para marcar una tarea como completada
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea != null)
            {
                tarea.Completada = true;
                GuardarTareas(); // Guardar cambios en el archivo
            }
        }

        public List<Tareas> ObtenerTareas() // Método para obtener todas las tareas
        {
            return tareas;
        }

        private void CargarTareas() // Método para cargar las tareas desde el archivo JSON
        {
            if (File.Exists(archivoTareas))
            {
                string json = File.ReadAllText(archivoTareas);
                tareas = JsonSerializer.Deserialize<List<Tareas>>(json) ?? new List<Tareas>();
            }
        }

        private void GuardarTareas() // Método para guardar las tareas en el archivo JSON
        {
            string json = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(archivoTareas, json);
        }
    }

    // --------------------------------------------------------------------------------------------------------------------------------------
    // Clase principal que contiene el menú y la lógica de interacción con el usuario
    // --------------------------------------------------------------------------------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            GestorTareas gestor = new GestorTareas(); // Crear una instancia del gestor de tareas
            bool continuar = true; // Variable para controlar el bucle del menú

            Console.WriteLine("=== GESTOR DE TAREAS ==="); // Escribimos el titulo en la consola
            Console.WriteLine();

            while (continuar) // Bucle para mostrar el menú y manejar las opciones
            {
                MostrarMenu(); // Mostrara el menu principal
                string opcion = Console.ReadLine(); // Leera la opción selecionada por el usuario

                switch (opcion)
                {
                    case "1":
                        AgregarTarea(gestor);
                        break;
                    case "2":
                        MostrarTareas(gestor);
                        break;
                    case "3":
                        MarcarTareaCompletada(gestor);
                        break;
                    case "4":
                        EliminarTarea(gestor);
                        break;
                    case "5":
                        continuar = false;
                        Console.WriteLine("¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Mostrar todas las tareas");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opción: ");
        }

        static void AgregarTarea(GestorTareas gestor)
        {
            Console.Clear();
            Console.WriteLine("=== AGREGAR NUEVA TAREA ===");

            Console.Write("Nombre de la tarea: ");
            string nombre = Console.ReadLine();

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            Console.Write("Fecha de vencimiento (dd/MM/yyyy): ");
            DateTime fechaVencimiento;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fechaVencimiento))
            {
                Console.Write("Formato incorrecto. Usa dd/MM/yyyy: ");
            }

            Console.WriteLine("Selecciona la prioridad:");
            Console.WriteLine("1. Baja");
            Console.WriteLine("2. Media");
            Console.WriteLine("3. Alta");
            Console.Write("Opción: ");

            Prioridad prioridad = Prioridad.Media;
            string prioridadOpcion = Console.ReadLine();
            switch (prioridadOpcion)
            {
                case "1": prioridad = Prioridad.Baja; break;
                case "2": prioridad = Prioridad.Media; break;
                case "3": prioridad = Prioridad.Alta; break;
                default: Console.WriteLine("Opción inválida, se asignará prioridad Media."); break;
            }

            Tareas nuevaTarea = new Tareas
            {
                Nombre = nombre,
                Descripcion = descripcion,
                FechaVencimiento = fechaVencimiento,
                Prioridad = prioridad
            };

            gestor.AgregarTarea(nuevaTarea);
            Console.WriteLine("¡Tarea agregada exitosamente!");
        }

        static void MostrarTareas(GestorTareas gestor)
        {
            Console.Clear();
            Console.WriteLine("=== LISTA DE TAREAS ===");

            var tareas = gestor.ObtenerTareas();

            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            Console.WriteLine();
            foreach (var tarea in tareas)
            {
                Console.WriteLine(tarea.ToString());
                Console.WriteLine(new string('-', 80));
            }
        }

        static void MarcarTareaCompletada(GestorTareas gestor)
        {
            Console.Clear();
            Console.WriteLine("=== MARCAR TAREA COMO COMPLETADA ===");

            MostrarTareas(gestor);

            Console.Write("Ingresa el ID de la tarea a completar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                gestor.MarcarComoCompletada(id);
                Console.WriteLine("¡Tarea marcada como completada!");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        static void EliminarTarea(GestorTareas gestor)
        {
            Console.Clear();
            Console.WriteLine("=== ELIMINAR TAREA ===");

            MostrarTareas(gestor);

            Console.Write("Ingresa el ID de la tarea a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                gestor.EliminarTarea(id);
                Console.WriteLine("¡Tarea eliminada exitosamente!");
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }
}

