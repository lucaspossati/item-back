using Application.Models;
using Data.Context;
using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext context;

        public ItemRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Item?> Get(string itemCode)
        {
            return await context.Items
                .AsNoTracking()
                .Where(c => c.ItemCode.Equals(itemCode))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetList(string? filter)
        {
            var list = await context.Items.AsNoTracking().ToListAsync();

            if (!string.IsNullOrEmpty(filter))
            {
                list = list.Where(x => x.ItemCode.ToLower().Contains(filter.ToLower()) || x.Description.ToLower().Contains(filter.ToLower())).ToList();
            }

            return list;
        }

        public async Task<Item> Post(Item model)
        {
            await context.Items.AddAsync(model);

            await context.SaveChangesAsync();

            return model;
        }

        public async Task<Item> Put(Item model)
        {
            context.Entry(model).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return model;
        }

        public async Task Delete(string itemCode)
        {
            var model = await context.Items.FindAsync(itemCode);

            if (model == null) return;

            context.Items.Remove(model);

            await context.SaveChangesAsync();
        }
    }
}
