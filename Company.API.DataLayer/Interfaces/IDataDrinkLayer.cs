using Company.API.DataLayer.DTO;
using System.Collections.Generic;

namespace Company.API.DataLayer.Interfaces
{
    public interface IDataDrinkLayer
    {
        public IEnumerable<Drink> GetAllDrinks();
        public Drink GetDrinkById(int id);
        public int InsertDrink(Drink drink);
        public int UpdateDrink(Drink drink);
        public int DeleteDrink(int id);
    }
}
