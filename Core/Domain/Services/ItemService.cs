using api.Domain.Services.Interfaces;
using Application.Models;
using AutoMapper;
using Core.Validator;
using Core.Validator.User;
using Data.Repository.Interface;
using FluentValidation.Results;
using Manager.VM.ItemVM;

namespace api.Domain.Services
{
    public class ItemService : IItemService
    {
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;

        public ItemService(IMapper mapper, IItemRepository ItemRepository)
        {
            this.mapper = mapper;
            this.itemRepository = ItemRepository;
        }

        public async Task<ItemVM> Get(string itemCode)
        {
            var response = await itemRepository.Get(itemCode);

            return mapper.Map<ItemVM>(response);
        }

        public async Task<IEnumerable<ItemVM>> GetList(string? filter = null)
        {
            var response = await itemRepository.GetList(filter);

            return mapper.Map<List<ItemVM>>(response);
        }

        public async Task<ItemVM> Post(ItemVM model)
        {
            var validator = new CreateItemValidator();

            ValidationResult results = validator.Validate(model);

            Validation.AddErrors(model, results);

            var itemAlreadyExistsByCode = await itemRepository.Get(model.ItemCode);

            if (itemAlreadyExistsByCode != null)
            {
                model.AddError("ItemCode already registered", "ItemCode");
            }

            if (model.Errors != null && model.Errors.Count > 0) return mapper.Map<ItemVM>(model);

            var vmToModel = mapper.Map<Item>(model);

            var item = await itemRepository.Post(vmToModel);

            return mapper.Map<ItemVM>(item);
        }

        public async Task<ItemVM> Put(ItemVM model)
        {
            var validator = new CreateItemValidator();

            ValidationResult results = validator.Validate(model);

            Validation.AddErrors(model, results);

            var modelOld = await itemRepository.Get(model.ItemCode);

            if (modelOld == null)
            {
                model.AddError("ItemCode not found", "ItemCode");
            }

            if (model.Errors != null && model.Errors.Count > 0) return model;

            await itemRepository.Put(mapper.Map<Item>(model));

            return model;
        }

        public async Task<ItemVM> Delete(string itemCode)
        {
            var model = await itemRepository.Get(itemCode);

            if (model == null) return null;

            await itemRepository.Delete(itemCode);

            return mapper.Map<ItemVM>(model); ;
        }
    }
}
