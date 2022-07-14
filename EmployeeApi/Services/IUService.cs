using EmployeeApi.Models;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public interface IUService
    {
        Task<UserDTO> Login(UserDTO user);
        Task<UserDTO> Register(UserDTO user);
        Task<UserDTO> UpdatePassword(UserDTO user);
        Task<UserDTO> UpdateRole(UserDTO user);
    }
}
