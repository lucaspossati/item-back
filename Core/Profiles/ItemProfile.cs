using Application.Models;
using AutoMapper;
using Manager.VM.ItemVM;

namespace api.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemVM, Item>();

            CreateMap<Item, ItemVM>();
        }
    }
}
