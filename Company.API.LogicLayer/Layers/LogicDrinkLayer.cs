using Company.API.DataLayer.DTO;
using Company.API.DataLayer.Interfaces;
using Company.API.DataLayer.Layers;
using Company.API.LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.API.LogicLayer.Layers
{
    public class LogicDrinkLayer
    {
        IDataDrinkLayer _drinkLayer;
        IDataUserLayer _userLayer;
        public LogicDrinkLayer(IDataDrinkLayer drinkLayer, IDataUserLayer userLayer)
        {
            _drinkLayer = drinkLayer;
            _userLayer = userLayer;
        }
        public IEnumerable<DrinkLogic> GetAllDrinks()
        {
            var drinks = _drinkLayer.GetAllDrinks();
            var result = drinks.Select(x => new DrinkLogic(x)).ToList();
            return result;
        }
        public DrinkLogic GetDrink(int id)
        {
            var drink = _drinkLayer.GetDrinkById(id);
            if (drink != null)
            {
                var result = new DrinkLogic(drink);
                return result;
            }
            else
            {
                return null;
            }
        }

        public int InsertDrink(DrinkLogic drink)
        {
            return _drinkLayer.InsertDrink(drink.ToDrink());
        }

        public int UpdateDrink(DrinkLogic drink)
        {
            return _drinkLayer.UpdateDrink(drink.ToDrink());
        }

        public int DeleteDrink(int id)
        {
            return _drinkLayer.DeleteDrink(id);
        }

    }
}
