using EmployeeApi.Models;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class UserService : IUService
    {
        private ILogger<EmployeeRepo> _logger;
        private readonly IRepo<string, User> _repo;
        private readonly ITokenService _tokenService;

        public UserService(IRepo<string, User> userRepo, ITokenService tokenService, ILogger<EmployeeRepo> logger)
        {
            _logger = logger;
            _repo = userRepo;
            _tokenService = tokenService;
        }
        public async Task<UserDTO> Login(UserDTO user)
        {
            var myUser = await _repo.Get(user.Username);
            if(myUser != null)
            {
                var hmac = new HMACSHA512(myUser.HashKey);
                var checkPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i=0; i<checkPass.Length; i++)
                {
                    if (checkPass[i] != myUser.Password[i])
                        return null;
                }
                user.Token = _tokenService.CreateToken(user);
                return user;
            }
            return null;
        }

        public async Task<UserDTO> Register(UserDTO user)
        {
            var hmac = new HMACSHA512();
            var userEn = new User
            {
                Username = user.Username,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                HashKey = hmac.Key,
                Role = user.Role,
            };
            var myUser = await _repo.Add(userEn);
            if (myUser != null)
            {
                user.Password = "";
                user.Token = _tokenService.CreateToken(user);
                return user;
            }
            return null;
        }

        public async Task<UserDTO> UpdatePassword(UserDTO user)
        {
            var myUser = await Login(user);
            if (myUser != null)
            {

                var hmac = new HMACSHA512();
                var userEn = new User
                {
                    Username = user.Username,
                    Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                    HashKey = hmac.Key,
                    Role = user.Role,
                };
                var updatedUser = await _repo.Add(userEn);
                if (updatedUser != null)
                {
                    user.Password = "";
                    return user;
                }
                return null;
            }
            return null;
        }

        public Task<UserDTO> UpdateRole(UserDTO user)
        {
            throw new System.NotImplementedException();
        }
    }
}
