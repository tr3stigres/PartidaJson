class Program
{
    public static void Main()
    {
        try
        {
            
            do
            {
                string accion = "";
                Console.Write("\n\naccion (alta,vida, baja, salir) > ");
                string? resposta = Console.ReadLine() ?? "";
                if (resposta != null)
                    accion = resposta;
                
                if (accion.ToLower().Trim() == "salir")
                    break;

                try
                {
                    RoosterPersistente valor = new RoosterPersistente(accion);
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine($"{error.Message}");
                    continue;
                }

            } while (true);
        }
        catch (Exception error)
        {
            Console.WriteLine($"Se ha producido el siguiente error: {error.Message}");
        }
    }
}
