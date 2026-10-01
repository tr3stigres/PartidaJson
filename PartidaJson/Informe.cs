public class Informe
{
    public IEnumerable<Partida> PartidaDatos { get; }

    public Informe(IEnumerable<Partida> partidaDatos)
    {
        PartidaDatos = partidaDatos;
        GenerarInforme();
    }

    private void GenerarInforme()
    {
        bool vacia = PartidaDatos.Count() == 0;
        
        if (!vacia)
        {
            foreach (var j in PartidaDatos)
            {
                Console.WriteLine($"{j.Nombre}, {j.Vida }");
            }
        }
        else
        {
            Console.WriteLine("No hay datos para mostrar de la partida.");
        }

    }

    public override string ToString()
    {
        return PartidaDatos.ToString();
    }

}