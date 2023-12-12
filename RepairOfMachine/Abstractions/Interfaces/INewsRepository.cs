using RepairOfMachine.Models.Entities;

namespace RepairOfMachine.Abstractions.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAllAsync();
        Task<News> GetAsync(int id);
        Task<IEnumerable<News>> GetIsActiveAsync();
        Task DeleteAsync(int id);
        //Task<IEnumerable<News>> GetAsync(int id);
        Task<News> CreateAsync(News news);
        Task UpdateAsync(News news);
    }
}
