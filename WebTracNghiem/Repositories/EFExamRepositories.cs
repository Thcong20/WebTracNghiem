using Microsoft.EntityFrameworkCore;
using System;
using WebTracNghiem.Data;
using WebTracNghiem.Models;

namespace WebTracNghiem.Repositories
{
    public class EFExamRepositories : IExamRepositories
    {
        private readonly AppDbContext _appDbContext;

        public EFExamRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _appDbContext.Questions.ToListAsync();
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _appDbContext.Questions.FindAsync(id);
        }

        public async Task AddAsync(Question question)
        {
            _appDbContext.Questions.Add(question);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _appDbContext.Questions.Update(question);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _appDbContext.Questions.FindAsync(id);
            if (question != null)
            {
                _appDbContext.Questions.Remove(question);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
