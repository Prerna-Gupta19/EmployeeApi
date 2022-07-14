using EmployeeApi.Models;

namespace EmployeeApi.Services
{
    public interface ITokenService
    {
        public string CreateToken(UserDTO user);
    }
}
