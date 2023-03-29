using Manager.VM.ItemVM;

namespace api.Domain.Services.Interfaces
{
    public interface IItemService
    {
        Task<ItemVM> Get(string itemCode);
        Task<IEnumerable<ItemVM>> GetList(string? filter);
        Task<ItemVM> Post(ItemVM model);
        Task<ItemVM> Put(ItemVM model);
        Task<ItemVM> Delete(string itemCode);
    }
}
