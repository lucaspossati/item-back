using Application.Models;

namespace Data.Repository.Interface
{
    public interface IItemRepository
    {
        Task<Item?> Get(string itemCode);

        Task<IEnumerable<Item>> GetList(string? filter);

        Task<Item> Post(Item model);

        Task<Item> Put(Item model);

        Task Delete(string id);
    }
}
