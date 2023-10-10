namespace GomokuApp.Model.Interface
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
    }
}
