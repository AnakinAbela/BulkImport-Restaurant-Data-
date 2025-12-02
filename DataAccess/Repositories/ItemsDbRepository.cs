using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ItemsDbRepository : IItemsRepository
    {
        private readonly ShoppingCartDbContext _context;

        public ItemsDbRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public IQueryable<IItemValidating> Get()
        {
            var restaurants = _context.Restaurants.ToList<IItemValidating>();
            var menuItems = _context.MenuItems.ToList<IItemValidating>();
            return restaurants.Concat(menuItems).AsQueryable();
        }

        public void Add(IItemValidating item)
        {
            if (item is Restaurant r)
            {
                _context.Restaurants.Add(r);
            }
            else if (item is MenuItem m)
            {
                _context.MenuItems.Add(m);
            }
            _context.SaveChanges();
        }
    }
}