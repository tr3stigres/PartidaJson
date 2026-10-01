using System.Diagnostics;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Cargar : TratarFichero
{

    public List<Partida> PartidaDatos { get; set; }


    public Cargar(string? nombreFichero = null, string? dir = null) : base(nombreFichero, dir)
    {
        CargarDatos();
    }

    private void CargarDatos()
    {

        string path = Path.Combine(Dir, NombreFichero);
        StreamReader? lector = null;
        Console.WriteLine($"Leyendo lista en la ruta: {path}");
        PartidaDatos = new List<Partida>();

        if (!File.Exists(path))
        {
            Console.WriteLine($"El fichero no existe");

        }
        else
        {
            try
            {
                lector = File.OpenText(path);
                string json = lector.ReadToEnd();
                var datosCargados = JsonSerializer.Deserialize<List<Partida>>(json);
                if (datosCargados is null || datosCargados.Any(p => p is null || string.IsNullOrWhiteSpace(p.Nombre) || p.Vida < 0))
                {
                    Console.WriteLine("La estructura o los valores del json son incorrectos."); 
                }
                else
                {
                    PartidaDatos = datosCargados;
                }
            }
            catch (System.Text.Json.JsonException)
            {
                Console.WriteLine("Se ha producido un error al cargar los datos del fichero.");
            }
            finally
            {
                lector?.Dispose();
            }
        }
    }

    public override string ToString()
    {
        return "Carga Datos";
    }
}