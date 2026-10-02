using System.Text.Json;

public class Guardar : TratarFichero
{

    public IEnumerable<Partida> PartidaDatos { get; }

    public Guardar(IEnumerable<Partida> partidaDatos, string? nombreFichero = null, string? dir = null) : base(nombreFichero, dir)
    {
        PartidaDatos = partidaDatos;
        GuardarDatos();
    }

    private void GuardarDatos()
    {

        if (PartidaDatos.Count() > 0 && !PartidaDatos.Any(p => p is null || string.IsNullOrWhiteSpace(p.Nombre) || p.Vida < 0))
        {
            string path = Path.Combine(Dir, NombreFichero);
            StreamWriter? escritor = null;
            //Console.WriteLine($"Guardando lista en la ruta: {path}");
            try
            {
                escritor = new StreamWriter(path);

                var opciones = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(PartidaDatos, opciones);
                escritor.WriteLine(json);
                escritor.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine($"Se ha producido el siguiente error: {error.Message}");
            }
            finally
            {
                escritor?.Dispose();
            }
        }
        else
        {
            Console.WriteLine("Los datos son incorrectos y la partida no se guardará.");
        }
        
    }

    public override string ToString()
    {
        return "Guarda Datos";
    }


}
