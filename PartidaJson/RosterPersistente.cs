using System.Security.Cryptography;

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
        else if (ValidarOrden() && ValidarPersonaje(players.PartidaDatos))
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

        switch (subs[0])
        {
            case "alta":
                personaje.Add(new Partida(subs[1], 100, "Soldado"));
                break;
            case "baja":
                
                foreach (var p in personaje)
                {
                    if (p.Nombre == subs[1])
                    {
                        personaje.Remove(p);
                        break;
                    }
                }
                break;
        }

        return true;
    }


    public override string ToString()
    {
        return "trata personajes";
    }

}