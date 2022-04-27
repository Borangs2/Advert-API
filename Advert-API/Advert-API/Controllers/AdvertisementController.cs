using Advert_API.Data;
using Advert_API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Advert_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvertisementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllAdvertisments()
        {
            return Ok(_context.Advertisements.Select(a => new AdvertisementDTO
            {
                Title = a.Title,
                Description = a.Description,
                Price = a.Price,
                DateCreated = a.DateCreated,
            }));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAdvertismentById(int id)
        {
            var advert = _context.Advertisements.FirstOrDefault(a => a.Id == id);


            if (advert == null)
                return NotFound();

            return Ok(new AdvertisementDTO
            {
                Title = advert.Title,
                Description = advert.Description,
                Price = advert.Price,
                DateCreated = advert.DateCreated,
            });
        }

        [HttpPost]
        public IActionResult CreateAdvertisement(CreateAdvertisementDTO advert)
        {
            var newAdvert = new Advertisment
            {
                Title = advert.Title,
                Description = advert.Description,
                Price = advert.Price,
                DateCreated = advert.DateCreated
            };

            _context.Advertisements.Add(newAdvert);
            _context.SaveChanges();

            var lagDTO = new Advertisment()
            {
                Title = advert.Title,
                Description = advert.Description,
                Price = advert.Price,
                DateCreated = advert.DateCreated
            };

            return CreatedAtAction(nameof(GetAdvertismentById), new { id = newAdvert.Id }, lagDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateAdvertisement(int id, UpdateAdvertisementDTO updateAdvert)
        {
            var team = _context.Advertisements.FirstOrDefault(t => t.Id == id);

            if (team == null)
                return NotFound();

            team.Title = updateAdvert.Title;
            team.Description = updateAdvert.Description;
            team.Price = updateAdvert.Price;
            team.DateCreated = updateAdvert.DateCreated;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAdvertisement(int id)
        {
            var advert = _context.Advertisements.FirstOrDefault(t => t.Id == id);

            if (advert == null)
                return NotFound();
            _context.Advertisements.Remove(advert);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
