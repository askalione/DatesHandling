namespace DatesHandling.ApplicationServices.Interfaces
{
    public interface IBazService
    {
        BazDto Create(DateOnly date, TimeOnly time);
        BazDto? Find(int id);
    }
}
