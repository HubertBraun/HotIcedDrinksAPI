using Company.API.DataLayer.DataContext;
using Company.API.DataLayer.DTO;
using Company.API.DataLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Company.API.DataLayer.Layers
{
    public class DataDrinkLayer : IDataDrinkLayer
    {
        private readonly DatabaseContext _context;
        private readonly DrinkType _type;
        public DataDrinkLayer(DatabaseContext context, DrinkType type)
        {
            _context = context;
            _type = type;
        }
        public IEnumerable<Drink> GetAllDrinks()
        {
            var drinkFromDatabase = _context.Drinks.Where(x => x.Type == _type).ToList();
            return drinkFromDatabase.ToList();
        }
        public Drink GetDrinkById(int id)
        {
            var drinkFromDatabase = _context.Drinks.Where(x => x.Type == _type && x.Id == id).SingleOrDefault();
            return drinkFromDatabase;
        }

        public int InsertDrink(Drink drink)
        {
            if (drink.Type != _type)
            {
                return -1;
            }

            using var transaction = _context.Database.BeginTransaction();
            _context.Drinks.Add(drink);
            var result = _context.SaveChanges();
            return result;
        }
        public int UpdateDrink(Drink drink)
        {
            if (drink.Type != _type)
            {
                return -1;
            }
            using var transaction = _context.Database.BeginTransaction();
            var drinkFromDatabase = _context.Drinks.Where(x => x.Id == drink.Id).SingleOrDefault();
            if (drink != null)
            {
                _context.Entry(drinkFromDatabase).CurrentValues.SetValues(drink);
                var result = _context.SaveChanges();
                return result;
            }
            else
            {
                return -1;
            }

        }

        public int DeleteDrink(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            var drink = _context.Drinks.Where(x => x.Id == id && x.Type == _type).SingleOrDefault();
            if (drink != null)
            {
                _context.Drinks.Remove(drink);
                var result = _context.SaveChanges();
                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}
