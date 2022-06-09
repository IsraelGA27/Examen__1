// Israel Garcia Agüero 
// 09/06/2022
// Examen 1 - Versión 3.2
using System;

// Clase que implementa el método main para correr el programa.
namespace Apuesta
{
    class Program
    {
        static void Main (string[] args)
        {   // Declaración de algunas reglas del juego.
            Console.Clear();
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*- JUEGO DE RULETA -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-\n");
            Console.WriteLine("############################# REGLAS DEL JUEGO ####################################### ");
            Console.WriteLine("a) El jugador deberá iniciar con un monto de dinero inicial ($300).");
            Console.WriteLine("b) El jugador podrá apostar la cantidad de dinero que quiera en sus apuestas (OBLIGATORIO: múltiplos de 10).");
            Console.WriteLine("c) El jugador podrá elegir una de 3 formas diferentes de apostar.");
            Console.WriteLine("d) El jugador podrá retirarse en el momento que quiera.");
            Console.WriteLine("e) Si el jugador se queda sin dinero, el juego termina automáticamente.");
            Console.WriteLine();
            // Creación de un objeto nuevo.
            Apuesta juego = new Apuesta();
            juego.MenuPrincipalJugar();
        }
    }
}

