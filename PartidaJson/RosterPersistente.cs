using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class RoosterPersistente
{

    public string Accion { get; }
    

    public RoosterPersistente(string accion)
    {
        var players = new Cargar();
        Accion = accion.Trim();
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
        if (!personaje.Any(p => p.Nombre.ToLower().Trim().Contains(subs[1].ToLower().Trim())))
            throw new ArgumentException("El personaje no existe en la lista.");
        
        return true;
    }

    private bool realizarAccion(List<Partida> personaje)
    {
        string[] subs = Accion.Split(' ');
        bool cambioRealizado = false;
        var registro = personaje.Find(j => j.Nombre.ToLower().Trim() == subs[1].ToLower().Trim());

        switch (subs[0].ToLower())
        {
            case "alta":
                
                if (registro == null)
                {
                    personaje.Add(new Partida(subs[1], 100, "Soldado"));
                    cambioRealizado = true;
                }
                    
                break;
            case "baja":
                if (ValidarPersonaje(personaje))
                {
        
                    if (registro != null)
                    {
                        personaje.Remove(registro);
                        cambioRealizado = true;
                    }
                }
                
                break;
            case "vida":
                if (ValidarPersonaje(personaje))
                {                    
                    if(subs[2] != null && int.TryParse(subs[2], out int valor) && valor >= 1 && valor <= 100)
                    {        

                        if (registro != null)
                        {
                            registro.Vida = valor;
                            cambioRealizado = true;
                        }                        
                    }
                    else
                    {
                        throw new ArgumentException("El valor de vida debe ser un número entero entre 1 y 100.");
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