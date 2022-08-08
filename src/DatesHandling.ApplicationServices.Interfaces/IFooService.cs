namespace DatesHandling.ApplicationServices.Interfaces
{
    public interface IFooService
    {
        FooDto Create(DateTime timestamp);
        FooDto? Find(int id);
    }
}
