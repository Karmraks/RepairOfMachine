using Microsoft.EntityFrameworkCore;
using RepairOfMachine.Abstractions.Interfaces;
using RepairOfMachine.Data;
using RepairOfMachine.Models.Entities;

namespace RepairOfMachine.Repositories
{
    public class NewsRepository(DataContext context) : INewsRepository
    {
        public async Task<IEnumerable<News>> GetAllAsync()
        {
            return await context.News.ToListAsync();
        }

        public async Task<News> GetAsync(int id)
        {
            return await context.News.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<News>> GetIsActiveAsync()
        {
            return await context.News.Where(n => n.IsActive == true).ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var news = await GetAsync(id);

            context.News.Remove(news);
            await context.SaveChangesAsync();
        }

        public async Task<News> CreateAsync(News news)
        {
            await context.News.AddAsync(news);
            await context.SaveChangesAsync();

            return news;
        }

        public async Task UpdateAsync(News news)
        {
            context.News.Update(news);
            await context.SaveChangesAsync();
        }
    }
}
