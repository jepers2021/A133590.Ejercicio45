using System;
using System.Collections.Generic;

namespace A133590.Ejercicio45
{
    class Program
    {
        static int validarEntero(string ingreso)
        {
            int resultado;

            bool exito = Int32.TryParse(ingreso, out resultado);

            while(!exito || resultado < 0)
            {
                Console.Write("Ingreso incorrecto, por favor intente de nuevo: ");
                exito = Int32.TryParse(Console.ReadLine(), out resultado);
            }

            return resultado;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 45");
            Dictionary<int, string> registros = new Dictionary<int, string>();
            while(true)
            {
                Console.Write("Por favor, ingrese un número de registro (ingrese 0 para terminar): ");
                int registro = validarEntero(Console.ReadLine());
                if (registro == 0) break;
                if(registros.ContainsKey(registro))
                {
                    Console.WriteLine("Registro ya existente, ingrese otro.");
                    continue;
                }

                Console.Write("Ahora ingrese un nombre de alumno: ");
                string alumno = Console.ReadLine();
                bool exito = true;
                foreach (char c in alumno) exito &= Char.IsLetter(c);
                while(!exito)
                {
                    Console.Write("Nombre inválido, por favor ingrese un nombre válido: ");
                    
                    alumno = Console.ReadLine();
                    exito = true;
                    foreach (char c in alumno) exito &= Char.IsLetter(c);

                }

                registros.Add(registro, alumno);
                Console.WriteLine($"registro: {registro} asociado a nombre {alumno} exitosamente.");
            }
            Console.Clear();
            while (true)
            {
                Console.Write("Ingrese un número de registro: ");
                int registro = validarEntero(Console.ReadLine());
                if (registro == 0) break;
                if(registros.ContainsKey(registro))
                {
                    Console.WriteLine($"Nombre asociado: {registros.GetValueOrDefault(registro)}");
                }
                else
                {
                    Console.WriteLine($"No existe nombre asociado a este registro.")
                }

            }

            Console.WriteLine("Presione cualquier tecla para continuar..");
            Console.ReadKey();
        }
    }
}
