namespace Core;

public class tøj
{
    public int id { get; set; }
    public string type { get; set; } = "";
    public string størrelse { get; set; } = "";
    public string farve { get; set; } = "";
    public string mærke { get; set; } = "";
    public bool reserveret { get; set; } = false;
    public string beskrivelse { get; set; } = "";
    public string img { get; set; } = "";
    public bruger? ejer { get; set; }
    public int? ejerId { get; set; } = 0;
    public bruger? låner { get; set; }
    public int? lånerId { get; set; } = 0;
    public DateTime? slutDato { get; set; }
}