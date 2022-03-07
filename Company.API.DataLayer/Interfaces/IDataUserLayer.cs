using Company.API.DataLayer.DTO;
using System.Collections.Generic;

namespace Company.API.DataLayer.Interfaces
{
    public interface IDataUserLayer
    {
        public User GetUserByLogin(string login);
        public int InsertUser(string login, string password);
        public int DeleteUser(int userId);
        public int AddPrivilegeToUser(int userId, IEnumerable<UserPrivileges> privileges);
    }
}
