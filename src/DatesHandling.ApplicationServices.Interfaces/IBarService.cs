namespace DatesHandling.ApplicationServices.Interfaces
{
    public interface IBarService
    {
        BarDto Create(DateTime timestamptz);
        BarDto? Find(int id);
    }
}
