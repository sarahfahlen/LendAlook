using Core;
namespace LALapp;

public class ClosetServiceMock : IClosetService
{
   public static tøj test1 = new tøj { id = 1, type = "bluse", størrelse = "small", beskrivelse = "efe", farve = "blå"};
   public static tøj test2 = new tøj { id = 2, type = "bukser", størrelse = "medium", beskrivelse = "rth", farve = "sort"};
   
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
      
      tøj tøjOpdatering = altTøj.FirstOrDefault(t => t.id == item.id);

      //her skal kode til at opdatere tøjOpdatering skrives
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