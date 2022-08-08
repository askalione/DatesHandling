namespace DatesHandling.ApplicationServices.Interfaces
{
    public record BarDto
    {
        public int Id { get; init; }
        public DateTime Timestamptz { get; init; }
    }
}
