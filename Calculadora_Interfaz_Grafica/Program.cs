using System;
using System.Windows.Forms;

namespace CalculadoraApp
{
    public partial class Form1 : Form // Clase principal del formulario
    {
        private double resultado = 0; // Almacenamos el resultado
        private string operacion = ""; // Almacenamos la operación actual
        private bool operacionPresionada = false; // Bandera p

        // La cabeza del programa
        public Form1() // Constructor del formulario
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del formulario
            this.Text = "Calculadora";
            this.Size = new System.Drawing.Size(300, 400); // Tamaño del formulario

            // Configurar el textbox para mostrar el resultado
            TextBox resultadoTextBox = new TextBox
            {
                ReadOnly = true, // Solo lectura
                Size = new System.Drawing.Size(280, 50), // Tamaño del textbox
                Dock = DockStyle.Top, // Ocupa todo el ancho del formulario
                Font = new System.Drawing.Font("Arial", 24), // Fuente del texto
                TextAlign = HorizontalAlignment.Right // Alineación del texto a la derecha
            };
        }
    }
}