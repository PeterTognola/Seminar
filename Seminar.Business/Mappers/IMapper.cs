namespace Seminar.Business.Mappers
{
    public interface IMapper<TModel, TView>
    {
        TView MapToView(TModel model);
        TModel MapToModel(TView view);
    }
}
