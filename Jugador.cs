// Clase que implementa atributos para poder definir un jugador nuevo.
namespace Jugador
{
    internal class Jugador
    {   // Atributos
        private string _nombre;
        private int _saldoInicial;
        private int _apuesta;
        // Constructor de la clase.
        public Jugador(string nombre)
        {
            _nombre = nombre;
            _saldoInicial = 300;
            _apuesta = apuesta;
        }
        // Getters and Setters.
        public string nombre { set; get; }
        public int saldo { set; get; }
        public int apuesta { set; get; }
        // Método para sobreescribir.
        public override string ToString()
        {
            return $"Jugador: {_nombre}.";
        }
    }
}