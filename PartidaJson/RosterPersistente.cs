using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class RoosterPersistente
{

    public string Accion { get; }
    

    public RoosterPersistente(string accion)
    {
        var players = new Cargar();
        Accion = accion.ToLower().Trim();
        if (Accion == "")
        {
            
            var informe = new Informe(players.PartidaDatos);
        }
        else if (ValidarOrden())
        {
            realizarAccion(players.PartidaDatos);            
        }
    }

    private bool ValidarOrden()
    {
        string[] subs = Accion.Split(' ');
        if (subs[0] != "alta" && subs[0] != "vida" && subs[0] != "baja")
            throw new ArgumentException("Acción no válida. Debe ser 'alta', 'vida' o 'baja'.");
        

        return true;
    }

    private bool ValidarPersonaje(List<Partida> personaje)
    {
        string[] subs = Accion.Split(' ');
        if (!personaje.Any(p => subs[1].Contains(p.Nombre.ToLower().Trim())))
            throw new ArgumentException("El personaje no existe en la lista.");
        
        return true;
    }

    private bool realizarAccion(List<Partida> personaje)
    {
        string[] subs = Accion.Split(' ');
        bool cambioRealizado = false;

        switch (subs[0])
        {
            case "alta":
                personaje.Add(new Partida(subs[1], 100, "Soldado"));
                cambioRealizado = true;
                break;
            case "baja":
                if (ValidarPersonaje(personaje))
                {
                    foreach (var p in personaje)
                    {
                        if (p.Nombre == subs[1])
                        {
                            personaje.Remove(p);
                            cambioRealizado = true;
                            break;
                        }
                    }
                }
                
                break;
        }

        if (cambioRealizado)
        {
            try
            {
                new Guardar(personaje);
                Console.WriteLine("Cambio guardado con éxito.");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Se ha producido el siguiente error: {error.Message}");
            }
            
        }
            


        return true;
    }


    public override string ToString()
    {
        return "trata personajes";
    }

}