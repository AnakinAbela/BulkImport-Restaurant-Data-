using Domain.Interfaces;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ItemsInMemoryRepository : IItemsRepository
    {
        private List<IItemValidating> _items = new List<IItemValidating>();

        public IQueryable<IItemValidating> Get()
        {
            return _items.AsQueryable();
        }

        public void Add(IItemValidating item)
        {
            _items.Add(item);
        }
    }
}