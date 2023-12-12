using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepairOfMachine.Abstractions.Interfaces;
using RepairOfMachine.Data;
using RepairOfMachine.Models.Entities;

namespace RepairOfMachine.Repositories
{
    public class UserRepository(DataContext context) : IUserRepository
    {
        public async Task<IEnumerable<IdentityUser>> GetAllAsync()
        {
            return await context.Users.OrderByDescending(u => u.UserName).ToListAsync();
        }

        public async Task BlockUsersAsync(string userId)
        {
            var user = await context.Users.FirstAsync(x => x.Id == userId);

            user.LockoutEnd = DateTime.UtcNow.AddMonths(1);
            await context.SaveChangesAsync();
        }

        public async Task UnBlockUsersAsync(string userId)
        {
            var user = await context.Users.FirstAsync(x => x.Id == userId);

            user.LockoutEnd = null;
            await context.SaveChangesAsync();
        }
    }
}
