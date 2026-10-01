public abstract class TratarFichero
{

    public string NombreFichero { get; set; } = "partida.json";
    public string Dir { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    public TratarFichero(string? nombreFichero = null, string? dir = null)
    {
        NombreFichero = nombreFichero ?? NombreFichero;
        Dir = dir ?? Dir;
    }


    public override string ToString()
    {
        return "trata ficheros";
    }

}