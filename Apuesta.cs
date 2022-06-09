namespace Apuesta
{
    using Jugador;
    internal class Apuesta
    {   // Atributos / colores de la ruleta / saldo / jugadores
        private List<int> _colorNegro;
        private List<int> _colorRojo;  
        private int _saldoActual; 
        private Jugador _jugador1;
        private List<Jugador> _jugadores;

        // Constructor de la clase.
        public Apuesta() 
        {
            this._jugadores = new List<Jugador>();
            this._saldoActual = 300; // concición obligatoria
            this._colorRojo = new List<int>();
            this._colorNegro = new List<int>();
        }

        // Método para mostrar el menu del usuario - cambiado por lo que tenia del ciclo while
        public void MenuPrincipalJugar()
        {
            obtenerJugador();
            int opcionElegida = 0; 
            do
            {
                Console.WriteLine("*-*-*-*-*-*-*-*- MENÚ PRINCIPAL -*-*-*-*-*-*-*-*-*");
                Console.WriteLine("1: Apostar por un NÚMERO ESPECIFICO.");
                Console.WriteLine("2: Apostar Por COLOR.");
                Console.WriteLine("3: Apostar Por Número PAR o IMPAR.");
                Console.WriteLine("4: SALIR DEL JUEGO");
                Console.WriteLine(":    Escoje una opción   :");
            } while (!opcionValidada(4, ref opcionElegida));
            switch (opcionElegida) 
            {   
                case 1: ApostarNumeroEspecifico(); break;
                case 2: ApostarPorColor(); break;
                case 3: ApostarParImpar(); break;
                case 4: break;
            }
        }

        // Método que nos ayuda a obtener un nombre para el jugador
        public void obtenerJugador()
        {
            string nombre;
            do
            {
                Console.WriteLine();
                Console.Write("Introduce tu nombre: ");

                nombre = Console.ReadLine();

                if (nombre == null || nombre == "")
                {
                    Console.Write("Nombre invalido... ¿Eso es posible?...");
                }
            } while (nombre == null || nombre == "");
            _jugador1 = new Jugador(nombre);
            _jugadores.Add(_jugador1);
            Console.WriteLine(">>> " + nombre + " tu saldo actual es de $" + _saldoActual);
            
            Console.WriteLine("Oprime 'ENTER' para continuar...");
            Console.ReadLine();
        }

        // Método que inicia la apuesta con un número dado por el usuario
        public void ApostarNumeroEspecifico()
        {
            Console.WriteLine("###### Selecciona 0 para SALIR.");
            Console.Write("¿Cuál es la cantidad que desas apostar?: $"); // Hacemos que el iluso apueste y pierda todo si dinero, así es como buen casino.
            int dineroApuesta = int.Parse(Console.ReadLine()); // Se checa que sea entera.
            if (dineroApuesta == 0) // Sale si le da 0.
            {
                Console.WriteLine("Vuelve pronto... Pero con más dinero :D");
                Console.WriteLine();
                MenuPrincipalJugar();
            }
            if ((dineroApuesta > _saldoActual) || (!MultiploDiez(dineroApuesta))) // Validamos la cantidad de la apuesta.
            {
                Console.WriteLine("No puedes jugar... Tu apuesta es inválida.");
            } else 
            {
                Console.Write("Número PERMITIDO para apostar (1-36): ");
                int numero = int.Parse(Console.ReadLine());
                Random numeroRuleta = new Random(); // generamos numeros aleatorios
                int numeroGenerado = numeroRuleta.Next(0, 37);
                if (numero == numeroGenerado) // si se acertó el número. menuda suerte chaval
                {
                    Console.WriteLine("¡HAS ACERTADO! Tu saldo se multiplica x10...");
                    _saldoActual += dineroApuesta * 10; // al saldo actual se le suma la apuesta * 10. (condición)
                    Console.WriteLine("Saldo Actual: $: " + _saldoActual);
                    ApostarNumeroEspecifico();
                }
                else // no se acertó, diosito no lo quizo 
                {
                    Console.WriteLine("¡TIENES MALA SUERTE!... Se obtuvo el número " + numeroGenerado);
                    _saldoActual -= dineroApuesta;
                    Console.WriteLine("Saldo Actual: $" + _saldoActual);
                    ApostarNumeroEspecifico();
                }
            }
        }
        // Método para generar apuesta a partir de la palabra 'par' o 'impar' ingresado por el usuario.
        public void ApostarParImpar()
        {
            Console.WriteLine("###### Selecciona 0 para SALIR.");
            Console.Write("¿Cuál es la cantidad que desas apostar?: $"); 
            int dineroApuesta = int.Parse(Console.ReadLine()); 
            if (dineroApuesta == 0) 
            {
                Console.WriteLine("Vuelve pronto... Pero con más dinero :D");
                Console.WriteLine();
                MenuPrincipalJugar();
            }
            if ((dineroApuesta > _saldoActual) || (!MultiploDiez(dineroApuesta))) // Se valida la cantidad apostada
            {
                Console.WriteLine("No puedes jugar... Tu apuesta es inválida.");
            }
            else
            {
                Console.Write("Número a apostar (Par o Impar): "); // Lo mismo pero mas barato
                string numero = Console.ReadLine();
                Random numeroRuleta = new Random(); 
                int numeroGenerado = numeroRuleta.Next(0, 37);
                if (MultiploDos(numeroGenerado)) // Si es par
                {
                    Console.WriteLine("¡HAS ACERTADO! Se obtuvo el número "+ numeroGenerado + " y es PAR..."); // Suerte pero es 50/50 no me sorpende
                    Console.WriteLine("Tu saldo se multiplica x2 :O");
                    _saldoActual += dineroApuesta * 2; // al saldo actual se le suma la apuesta * 10.
                    Console.WriteLine("Saldo Actual: $" + _saldoActual);
                    ApostarParImpar();
                }
                else  // Si es impar
                {
                    Console.WriteLine("¡HAS ACERTADO! Se obtuvo el número "+ numeroGenerado + " y es IMPAR...");
                    Console.WriteLine("Tu saldo se multiplica x2 :O");
                    _saldoActual += dineroApuesta * 2; // al saldo actual se le suma la apuesta * 10.
                    Console.WriteLine("Saldo Actual: $" + _saldoActual);
                    ApostarParImpar();
                }
            }    
        }
        // Método para generar apuesta a partir de un color ingresado por el usuario.
        public void ApostarPorColor()
        {   // Asignamos los números pertenecientes al color rojo.
            _colorRojo.Add(1);
            _colorRojo.Add(3);
            _colorRojo.Add(5);
            _colorRojo.Add(7);
            _colorRojo.Add(9);
            _colorRojo.Add(12);
            _colorRojo.Add(14);
            _colorRojo.Add(16);
            _colorRojo.Add(18);
            _colorRojo.Add(19);
            _colorRojo.Add(21);
            _colorRojo.Add(23);
            _colorRojo.Add(25);
            _colorRojo.Add(27);
            _colorRojo.Add(30);
            _colorRojo.Add(32);
            _colorRojo.Add(34);
            _colorRojo.Add(36);
            // Asignamos los números pertenecientes al color negro.
            _colorNegro.Add(2);
            _colorNegro.Add(4);
            _colorNegro.Add(6);
            _colorNegro.Add(8);
            _colorNegro.Add(10);
            _colorNegro.Add(11);
            _colorNegro.Add(13);
            _colorNegro.Add(15);
            _colorNegro.Add(17);
            _colorNegro.Add(20);
            _colorNegro.Add(22);
            _colorNegro.Add(24);
            _colorNegro.Add(26);
            _colorNegro.Add(28);
            _colorNegro.Add(29);
            _colorNegro.Add(31);
            _colorNegro.Add(33);
            _colorNegro.Add(35);
            
            Console.WriteLine("###### Selecciona 0 para SALIR."); // Lo mismo pero aún mas barato 
            Console.Write("¿Cuál es la cantidad que desas apostar?: $"); 
            int dineroApuesta = int.Parse(Console.ReadLine()); 
            if (dineroApuesta == 0) 
            {
                Console.WriteLine("Vuelve pronto... Pero con más dinero :D");
                Console.WriteLine();
                MenuPrincipalJugar();
            }
            if ((dineroApuesta > _saldoActual) || (!MultiploDiez(dineroApuesta))) 
            {
                Console.WriteLine("No puedes jugar... Tu apuesta es inválida.");
            }
            else
            {
                Console.Write("Color al que deseas apostar (Rojo o Negro): ");
                string color = Console.ReadLine(); 
                Random numeroRuleta = new Random();
                int numeroGenerado = numeroRuleta.Next(0, 37);
                if (_colorRojo.Contains(numeroGenerado)) // Si es color Rojo.
                {
                    Console.WriteLine("¡HAS ACERTADO! Se obtuvo el número "+ numeroGenerado + " y es de color Rojo...");
                    Console.WriteLine("Tu saldo se multiplica x5 :O");
                    _saldoActual += dineroApuesta * 5; // el saldo se multiplica x5.
                    Console.WriteLine("Saldo Actual: $" + _saldoActual);
                    ApostarPorColor();
                }
                else if (_colorNegro.Contains(numeroGenerado)) // Si es color Negro.
                {
                    Console.WriteLine("¡HAS ACERTADO! Se obtuvo el número " + numeroGenerado + " y es de color Negro...");
                    Console.WriteLine("Tu saldo se multiplica x5 :O");
                    _saldoActual += dineroApuesta * 5; // el saldo se multiplica x5.
                    Console.WriteLine("Saldo Actual: $" + _saldoActual);
                    ApostarPorColor();
                }
                else
                {
                    Console.WriteLine("¡TIENES MALA SUERTE!... Se obtuvo el número " + numeroGenerado);
                    _saldoActual -= dineroApuesta;
                    Console.WriteLine("Saldo Actual: $" + _saldoActual);
                    ApostarPorColor();
                }
            }    
        }

        // Método para saber si la apuesta es múltiplo de 10.
        private bool MultiploDiez(int numero)
        {
            if (numero % 10 == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
        // Método para saber si el número generado es par o impar.
        private bool MultiploDos(int numero)
        {
            if (numero % 2 == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        // Método para validar las opciones que ingrese el usuario al tomar una operación.     
        public bool opcionValidada(int opciones, ref int opcionElegida)
        {
            int num;
            if (int.TryParse(Console.ReadLine(), out num)) // convertir numero lo que se ingrese.
            {
                if (num <= opciones) // 
                {
                    opcionElegida = num;
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Tu opción es inválida...");
                    return false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Opción ingresada es inválido... Ingresa un NUMERO.");
                return false;
            }
        }
    }    
}