namespace BankSystem.DAL.Interface.DTO
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
