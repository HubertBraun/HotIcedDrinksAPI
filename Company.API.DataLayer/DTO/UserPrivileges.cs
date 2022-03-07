using Company.API.DataLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Company.API.DataLayer.DTO
{
    public class UserPrivileges : IDentity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public PrivilegeType Privilege { get; set; }
        public SecurableType Securable { get; set; }
    }
    public enum PrivilegeType
    {
        Read,
        Update,
        Insert,
        Delete,
    }
    public enum SecurableType
    {
        HotDrinks,
        IcedDrinks,
    }
}
