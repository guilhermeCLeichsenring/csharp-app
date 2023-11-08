using CSharp_App.Interfaces;
using CSharp_App.Models;

namespace CSharp_App.Services
{
    public class ShelfService
    {
        private readonly IRepository<ShelfModel> _shelfRepository;

        public ShelfService(IRepository<ShelfModel> shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }


        public void AddShelf(ShelfModel shelf)
        {
            _shelfRepository.Add(shelf);
        }

        public void UpdateShelf(ShelfModel shelf)
        {
            _shelfRepository.Update(shelf);
        }

        public void DeleteShelf(ShelfModel shelf)
        {
            _shelfRepository.Delete(shelf);
        }

        public ShelfModel GetProductById(int id)
        {
            return _shelfRepository.GetById(id);
        }

        public IEnumerable<ShelfModel> GetAllShelfs()
        {
            return _shelfRepository.GetAll();
        }
    }
}
