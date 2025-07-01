//Console.WriteLine("Hello, World!");
/*
Variables:

string libro = "C# Programming";
int numero = 42;
float decimalNumber = 3.14f;
bool isTrue = true;
bool isFalse = false;

*/

// Lista de numeros
int[] numeros = { 1, 2, 3, 4, 5 };
Console.WriteLine(numeros[0]);

// Listas dinamicas
List<int> listaNumeros = new List<int> { 1, 2, 3, 4, 5 };
Console.WriteLine(listaNumeros[0]);

Console.WriteLine(string.Join(",", listaNumeros));

// Listas de texto
List<string> listaTextos = new List<string> { "C#", "Java", "Python" };
Console.WriteLine(string.Join(",", listaTextos));

// Listas de datos dinamicos
List<dynamic> listaDinamica = new List<dynamic> { "C#", 42, 3.14f, true };
Console.WriteLine(string.Join(",", listaDinamica));

// Diccionario
Dictionary<string, int> diccionario = new Dictionary<string, int>
{
    { "C#", 1 },
    { "Java", 2 },
    { "Python", 3 }
};

diccionario.Add("JavaScript", 4);
Console.WriteLine("Diccionario:");
Console.WriteLine(diccionario["C#"]);

// constantes
const string CONSTANTE = "Valor constante";

// Operadores
int a = 10;
int b = 5;
Console.WriteLine($"Suma: {a + b}");