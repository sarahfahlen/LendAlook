namespace Core;

public class bruger
{
    public int id { get; set; }
    public string navn { get; set; } = "";
    public string brugernavn { get; set; } = "";
    public string password { get; set; } = "";
    public string email { get; set; } = "";
    public int mobil { get; set; } = 0;
    
    public DateTime? slutDag { get; set; }
}