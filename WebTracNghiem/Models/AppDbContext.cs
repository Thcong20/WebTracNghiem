using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebTracNghiem.Models;

namespace WebTracNghiem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }

        // Nếu sau này có thêm bảng, bạn khai báo ở đây.
        // public DbSet<User> Users { get; set; }
    }
}
