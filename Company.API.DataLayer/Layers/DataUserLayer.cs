using Company.API.DataLayer.DataContext;
using Company.API.DataLayer.DTO;
using Company.API.DataLayer.Helper;
using Company.API.DataLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Company.API.DataLayer.Layers
{
    public class DataUserLayer : IDataUserLayer
    {
        private readonly DatabaseContext _context;
        public DataUserLayer(DatabaseContext context)
        {
            _context = context;
        }
        public User GetUserByLogin(string login)
        {
            var user = _context.Users.Where(x => x.Login == login).SingleOrDefault();
            return user;
        }

        public int InsertUser(string login, string password)
        {
            var user = new User
            {
                Login = login,
                Password = PasswordHelper.StringToPassword(password),
                Privileges = new List<UserPrivileges>(),
            };
            using var transaction = _context.Database.BeginTransaction();
            _context.Users.Add(user);
            var result = _context.SaveChanges();
            return result;
        }

        public int DeleteUser(int userId)
        {
            using var transaction = _context.Database.BeginTransaction();
            var user = _context.Users.Where(x => x.Id == userId).SingleOrDefault();
            if (user != null)
            {
                _context.Users.Remove(user);
                var result = _context.SaveChanges();
                return result;
            }
            else
            {
                return -1;
            }
        }

        public int AddPrivilegeToUser(int userId, IEnumerable<UserPrivileges> privileges)
        {
            var user = _context.Users.Where(x => x.Id == userId).SingleOrDefault();
            using var transaction = _context.Database.BeginTransaction();
            foreach (var p in privileges)
            {
                if (!user.Privileges.Any(x => x.Privilege == p.Privilege && x.Securable == p.Securable))
                {
                    user.Privileges.Add(p);
                }
            }
            var result = _context.SaveChanges();
            return result;
        }
    }
}
