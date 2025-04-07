using Core;
using static LALapp.Services.LoginServiceClientSide;
namespace LALapp;

public class ClosetServiceMock : IClosetService
{
    public static tøj test1 = new tøj { id = 1, type = "Overdele", størrelse = "Small", farve = "Navy", mærke = "H&M", beskrivelse = "Fin bluse fra H&M, med broderede ærmer", img = "https://images1.vinted.net/t/04_01117_ecEptDFqCNGYznpBeuLxkaCa/f800/1744020601.jpeg?s=9d2a74e4a3264d6657f2f4eeb9869c7e96f66b7e", ejer = rip};
    public static tøj test2 = new tøj { id = 2, type = "Bukser", størrelse = "38", beskrivelse = "Løse jeans fra Weekday", farve = "Blå", mærke = "Weekday", img = "https://images1.vinted.net/t/02_024f5_kxM8t9whpBSSU9FJaqVuVY5X/f800/1743883988.jpeg?s=9ecf658925ba03703ecdee21e11cc3937528e442", ejer = rap};
   
    public List<tøj> altTøj = new List<tøj>{test1, test2};


    public async Task<tøj[]> GetAll()
    {
        return altTøj.ToArray();
    }

    public async Task AddItem(tøj item)
    {
        int max = 0;
        if (altTøj.Count > 0)
        {
            max = altTøj.Select(t => t.id).Max();
        }
        item.id = max + 1;
        altTøj.Add(item);
    }
   
    public async Task DeleteById(int id)
    {
        altTøj.RemoveAll(t => t.id == id);
    }

    public async Task UpdateItem(tøj item)
    {
        var index = altTøj.FindIndex(t => t.id == item.id); //finder det objekt hvor ID matcher, og tjekker dets index (plads)
        if (index != -1) //hvis index =-1 betyder det at objektet ikke findes - derfor tjekkes der her om der er et match
        {
            altTøj[index] = item; //hvis der er match, laves det objekt vi fandt om til det vi sender med (det opdaterede)
        }
      
    }

    public async Task BookItem(tøj item, DateOnly slut)
    {
        tøj bookingItem = altTøj.FirstOrDefault(t => t.id == item.id);
        if (bookingItem != null)
        {
            bookingItem.reserveret = item.reserveret; //sætter status for det valgte item, til den status der ændres på page (vigtigt vi ændrer på page)
            bookingItem.slutDato = slut; //skal sendes fra siden også
        }
    }

    public Task FilterBy(string? type, string? farve, string? størrelse, bruger? udlåner, bool? ledig)
    {
        throw new NotImplementedException();
    }
   
}