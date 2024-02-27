using Domain.Entities;
using Domain.Services;
using FluentValidation;
using Infrastructure.Validators;

namespace API.Services
{
    /// <summary>
    /// Handles validation and operations concerning DDDItems.
    /// </summary>
    public class DDDService : IDDDService
    {
        private IRepository<DDDItem> _repository;

        private DDDItemValidator _validator;

        public DDDService(IRepository<DDDItem> repository)
        {
            _repository = repository;
            _validator = new DDDItemValidator();
        }

        public void CreateDDD(DDDItem DDD)
        {
            _validator.ValidateAndThrow(DDD);
            _repository.Insert(DDD);
        }

        public bool DeleteDDD(int id) => _repository.Delete(id);

        public IEnumerable<DDDItem> GetAllDDDs() => _repository.GetAll();

        public DDDItem GetDDD(int Id) => _repository.GetById(Id);

        public bool UpdateDDD(DDDItem DDD)
        {
            _validator.ValidateAndThrow(DDD);
            return _repository.Upsert(DDD);
        }
    }
}
