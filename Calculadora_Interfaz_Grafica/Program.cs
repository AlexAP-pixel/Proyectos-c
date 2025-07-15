using System;
using System.Windows.Forms;

namespace CalculadoraApp
{
    public partial class Form1 : Form
    {
        private double resultado = 0;
        private string operacion = "";
        private bool operacionPresionada = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Configuración del formulario
            this.Text = "Calculadora";
            this.Size = new System.Drawing.Size(300, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // TextBox para mostrar resultados
            TextBox txtDisplay = new TextBox
            {
                Name = "txtDisplay",
                Size = new System.Drawing.Size(250, 30),
                Location = new System.Drawing.Point(20, 20),
                Font = new System.Drawing.Font("Arial", 12),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                Text = "0"
            };
            this.Controls.Add(txtDisplay);

            // Botones numéricos
            string[] numeros = { "7", "8", "9", "4", "5", "6", "1", "2", "3", "0" };
            int x = 20, y = 70;
            
            for (int i = 0; i < numeros.Length; i++)
            {
                Button btn = new Button
                {
                    Text = numeros[i],
                    Size = new System.Drawing.Size(50, 50),
                    Location = new System.Drawing.Point(x, y),
                    Font = new System.Drawing.Font("Arial", 12),
                    Name = "btn" + numeros[i]
                };
                
                btn.Click += NumeroClick;
                this.Controls.Add(btn);
                
                x += 60;
                if ((i + 1) % 3 == 0)
                {
                    x = 20;
                    y += 60;
                }
            }

            // Botón 0 más ancho
            this.Controls["btn0"].Size = new System.Drawing.Size(110, 50);

            // Botones de operaciones
            string[] operaciones = { "+", "-", "*", "/" };
            y = 70;
            
            for (int i = 0; i < operaciones.Length; i++)
            {
                Button btn = new Button
                {
                    Text = operaciones[i],
                    Size = new System.Drawing.Size(50, 50),
                    Location = new System.Drawing.Point(200, y),
                    Font = new System.Drawing.Font("Arial", 12),
                    Name = "btn" + operaciones[i].Replace("*", "Mult").Replace("/", "Div")
                };
                
                btn.Click += OperacionClick;
                this.Controls.Add(btn);
                y += 60;
            }

            // Botón igual
            Button btnIgual = new Button
            {
                Text = "=",
                Size = new System.Drawing.Size(50, 50),
                Location = new System.Drawing.Point(140, 250),
                Font = new System.Drawing.Font("Arial", 12),
                Name = "btnIgual"
            };
            btnIgual.Click += IgualClick;
            this.Controls.Add(btnIgual);

            // Botón limpiar
            Button btnLimpiar = new Button
            {
                Text = "C",
                Size = new System.Drawing.Size(50, 50),
                Location = new System.Drawing.Point(80, 250),
                Font = new System.Drawing.Font("Arial", 12),
                Name = "btnLimpiar"
            };
            btnLimpiar.Click += LimpiarClick;
            this.Controls.Add(btnLimpiar);

            // Botón punto decimal
            Button btnPunto = new Button
            {
                Text = ".",
                Size = new System.Drawing.Size(50, 50),
                Location = new System.Drawing.Point(140, 190),
                Font = new System.Drawing.Font("Arial", 12),
                Name = "btnPunto"
            };
            btnPunto.Click += PuntoClick;
            this.Controls.Add(btnPunto);
        }

        private void NumeroClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox display = (TextBox)this.Controls["txtDisplay"];
            
            if (display.Text == "0" || operacionPresionada)
            {
                display.Text = "";
                operacionPresionada = false;
            }
            
            display.Text += btn.Text;
        }

        private void OperacionClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox display = (TextBox)this.Controls["txtDisplay"];
            
            if (resultado != 0)
            {
                IgualClick(sender, e);
            }
            else
            {
                resultado = double.Parse(display.Text);
            }
            
            operacion = btn.Text;
            operacionPresionada = true;
        }

        private void IgualClick(object sender, EventArgs e)
        {
            TextBox display = (TextBox)this.Controls["txtDisplay"];
            
            switch (operacion)
            {
                case "+":
                    display.Text = (resultado + double.Parse(display.Text)).ToString();
                    break;
                case "-":
                    display.Text = (resultado - double.Parse(display.Text)).ToString();
                    break;
                case "*":
                    display.Text = (resultado * double.Parse(display.Text)).ToString();
                    break;
                case "/":
                    if (double.Parse(display.Text) != 0)
                        display.Text = (resultado / double.Parse(display.Text)).ToString();
                    else
                        display.Text = "Error";
                    break;
            }
            
            resultado = 0;
            operacion = "";
        }

        private void LimpiarClick(object sender, EventArgs e)
        {
            TextBox display = (TextBox)this.Controls["txtDisplay"];
            display.Text = "0";
            resultado = 0;
            operacion = "";
            operacionPresionada = false;
        }

        private void PuntoClick(object sender, EventArgs e)
        {
            TextBox display = (TextBox)this.Controls["txtDisplay"];
            
            if (!display.Text.Contains("."))
            {
                display.Text += ".";
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}