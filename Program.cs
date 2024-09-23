using System;
using System.Collections.Generic;
using System.Linq;

class Estudiante
{
    public string Nombre { get; set; }
    private int Edad { get; set; }
    public double Promedio { get; set; }

    
    public Estudiante(string nombre, int edad, double promedio)
    {
        Nombre = nombre;
        Edad = edad;
        Promedio = promedio;
    }

    
    public bool EsMayorDeEdad()
    {
        return Edad >= 18;
    }

    
    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Promedio: {Promedio}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Estudiante> estudiantes = new List<Estudiante>();

        
        int cantidad;
        while (true)
        {
            Console.Write("Ingrese la cantidad de estudiantes a registrar: ");
            string entradaCantidad = Console.ReadLine();

            if (int.TryParse(entradaCantidad, out cantidad) && cantidad > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Entrada no válida. Ingrese un número entero positivo.");
            }
        }

        
        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\nEstudiante {i + 1}:");

            
            string nombre;
            while (true)
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();

                
                if (nombre.All(char.IsLetter))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("El nombre no es válido. Solo se permiten letras. Intente de nuevo.");
                }
            }

            
            int edad;
            while (true)
            {
                Console.Write("Edad: ");
                string entradaEdad = Console.ReadLine();

                if (int.TryParse(entradaEdad, out edad) && edad > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Ingrese un número entero positivo.");
                }
            }

            
            double promedio;
            bool valido;
            do
            {
                Console.Write("Promedio: ");
                string entradaPromedio = Console.ReadLine();
                valido = double.TryParse(entradaPromedio, out promedio);

                if (!valido)
                {
                    Console.WriteLine("El promedio debe ser un número. Intente de nuevo.");
                }
                else if (promedio < 70)
                {
                    Console.WriteLine("El promedio debe ser igual o mayor a 70. Intente de nuevo.");
                }
            } while (!valido || promedio < 70);

            
            Estudiante estudiante = new Estudiante(nombre, edad, promedio);
            estudiantes.Add(estudiante);
        }

       
        int index = 0;
        Console.WriteLine("\n===============================");
        while (index < estudiantes.Count)
        {
            // Mostrar información del estudiante
            estudiantes[index].MostrarInfo();
            Console.WriteLine($"{estudiantes[index].Nombre} tiene un promedio de {estudiantes[index].Promedio}.");

            // Verifica si es mayor de edad
            if (estudiantes[index].EsMayorDeEdad())
            {
                Console.WriteLine($"{estudiantes[index].Nombre} es mayor de edad.");
            }
            else
            {
                Console.WriteLine($"{estudiantes[index].Nombre} es menor de edad.");
            }
            Console.WriteLine("\n===============================");
            index++;
        }
    }
}
