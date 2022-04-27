using Microsoft.EntityFrameworkCore;

namespace Advert_API.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;

        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SeedData()
        {
            _context.Database.Migrate();
            SeedAdvertisements();

        }

        private void SeedAdvertisements()
        {
            if (!_context.Advertisements.Any(a => a.Title == "Pers Päron"))
                _context.Advertisements.Add(new Advertisment
                {
                    Title = "Pers Päron",
                    Description = "Köp en påse med pärs perfekta päron",
                    Price = 49.99,
                    DateCreated = "15/03/2022",
                });
            if (!_context.Advertisements.Any(a => a.Title == "Köp en burk med Farfars berömda pepparkakor"))
                _context.Advertisements.Add(new Advertisment
                {
                    Title = "Köp en burk med Farfars berömda pepparkakor",
                    Description = "Burken innehåller åtminstone 50 pepparkakor av farfars berömda recept",
                    Price = 74.99,
                    DateCreated = "25/12/2021",
                });
            if (!_context.Advertisements.Any(a => a.Title == "Rolls Royce till salu"))
                _context.Advertisements.Add(new Advertisment
                {
                    Title = "Rolls Royce till salu",
                    Description = "Min fars rolls royce är till salu",
                    Price = 249999,
                    DateCreated = "02/02/2022",
                });
            if (!_context.Advertisements.Any(a => a.Title == "Sommarstuga i skåne säljes"))
                _context.Advertisements.Add(new Advertisment
                {
                    Title = "Sommarstuga i skåne säljes",
                    Description = "Sommarstugan har 3 sovrum, 2 badrum, ett kök och ett stort vardagsrum",
                    Price = 599000,
                    DateCreated = "24/04/2022",
                });
            if (!_context.Advertisements.Any(a => a.Title == "En låda Honduranska bananer"))
                _context.Advertisements.Add(new Advertisment
                {
                    Title = "En låda Honduranska bananer",
                    Description = "En hel låda med bananer från Honduras kan vara din för endast 249.99",
                    Price = 249.99,
                    DateCreated = "25/04/2022",
                });
        }
    }

}
