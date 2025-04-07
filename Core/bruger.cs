namespace Core;

public class bruger
{
    public int id { get; set; }
    public string navn { get; set; } = "";
    public string brugernavn { get; set; } = "";
    public string password { get; set; } = "";
    public string email { get; set; } = "";
    public int mobil { get; set; } = 0;
    public bruger ejer { get; set; }
    public int? ejerid { get; set; }
    public bruger låner { get; set; }
    public int? lånerid { get; set; }
    public DateOnly slutDag { get; set; }
}