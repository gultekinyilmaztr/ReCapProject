namespace Core.Entities
{
    public interface IDto
    {
        public int CarId { get; set; }

        public string BrandName { get; set; }

        public string ColorName { get; set; }

        public Decimal DailyPrice { get; set; }

        public string Description { get; set; }
    }
}