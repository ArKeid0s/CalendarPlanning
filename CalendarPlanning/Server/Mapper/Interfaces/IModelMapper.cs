namespace CalendarPlanning.Server.Mapper.Interfaces
{
    public interface IModelMapper<T, Y>
    {
        T Map(Y model);
    }
}
