namespace Advert_API.DTO
{
    public class CreateAdvertisementDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string DateCreated { get; set; }
    }
}
