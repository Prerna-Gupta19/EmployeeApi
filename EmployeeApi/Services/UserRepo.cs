using EmployeeApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class UserRepo : IRepo<string, User>
    {
        private CompanyContext _context;
        private ILogger<EmployeeRepo> _logger;
        private ICollection<User> users;

        public UserRepo(CompanyContext context, ILogger<EmployeeRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<User> Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }

        public Task<User> Delete(string key)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Get(string key)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == key);
                if(user != null)
                    return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }

        public async Task<ICollection<User>> GetAll()
        {
            try
            {
                var user = _context.Users.ToList();
                if(users.Count()!=0)
                return users;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }

        public async Task<User> Update(User item)
        {
            try
            {
                var user = await Get(item.Username);
                if (user != null)
                {
                    user.Password=item.Password;
                    user.Role = item.Role;
                    _context.SaveChangesAsync().Wait();
                    return item;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }
    }
}
