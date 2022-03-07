using Company.API.DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.API.LogicLayer.Models
{
    public class DrinkLogic
    {
        public DrinkLogic()
        {

        }

        public DrinkLogic(Drink drink)
        {
            Id = drink.Id;
            Name = drink.Name;
            Price = drink.Price;
            Type = (DrinkLogicType)drink.Type;
        }

        public Drink ToDrink()
        {
            return new Drink
            {
                Id = Id,
                Name = Name,
                Price = Price,
                Type = (DrinkType)Type,
            };
        }
        

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DrinkLogicType Type { get; set; }
    }

    public enum DrinkLogicType
    {
        Hot,
        Iced,
    }

}
