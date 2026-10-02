public class Partida
{
    public string Nombre { get; }
    public int Vida { get; set; }
    public string Tipo { get; }

    public Partida(string nombre, int vida, string tipo)
    {
        Nombre = nombre;
        Vida = vida;
        Tipo = tipo;
    }

    public override string ToString()
    {
        return $"Partida: {Nombre}, Vida: {Vida}, Tipo: {Tipo}";
    }

}