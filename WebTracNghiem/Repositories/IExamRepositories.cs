using WebTracNghiem.Models;

namespace WebTracNghiem.Repositories
{
    public interface IExamRepositories
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> GetByIdAsync(int id);
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(int id);
    }
}
