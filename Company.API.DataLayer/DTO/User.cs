using Company.API.DataLayer.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Company.API.DataLayer.DTO
{
    public class User : IDentity
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<UserPrivileges> Privileges { get; set; }
    }
}
