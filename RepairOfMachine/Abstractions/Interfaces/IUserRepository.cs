using Microsoft.AspNetCore.Identity;
using RepairOfMachine.Models.Entities;

namespace RepairOfMachine.Abstractions.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAllAsync();
    }
}
