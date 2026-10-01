class Program
{


    public static void Main()
    {

        try
        {

            do
            {
                string accion = "";
                Console.Write("accion (alta,vida, baja) > ");
                string? resposta = Console.ReadLine() ?? "";
                if (resposta != null)
                    accion = resposta;
                try
                {
                    RoosterPersistente valor = new RoosterPersistente(accion);
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine($"{error.Message}");
                    continue;
                }



                break;

            } while (true);

            /*var jugadores = new List<Partida>
            {
                new ("Ada", 80, "Mago"),
                new ("Bruno", 0, "Guerrero"),
                new ("Carla", 50, "Mago"),
                new ("Diego", 100, "Guerrero"),
                new ("Eva", 100, "Mago")
            };

            jugadores = new List<Partida>{};
            var fichero = new Guardar(jugadores);

            var players = new Cargar();
            var informe = new Informe(players.PartidaDatos);*/




        }
        catch (Exception error)
        {
            Console.WriteLine($"Se ha producido el siguiente error: {error.Message}");
        }
    }



}
