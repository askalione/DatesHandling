namespace DatesHandling.ApplicationServices.Interfaces
{
    public record BazDto
    {
        public int Id { get; init; }
        public DateOnly Date { get; init; }
        public TimeOnly Time { get; init; }
    }
}
