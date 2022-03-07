using Company.API.DataLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Company.API.DataLayer.DTO
{
    public class Drink : IDentity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DrinkType Type { get; set; }
    }

    public enum DrinkType
    {
        Hot,
        Iced,
    }
}
