using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnswerProject.Models
{
    public class AnswerContext: DbContext
    {
        public AnswerContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerItem> AnswerItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Text = "Введите имя", DataType = "text" },
                new Question { Id = 2, Text = "Введите возраст", DataType = "number" },
                new Question { Id = 3, Text = "Введите пол", DataType = "enum", Enumeration = "муж;жен;неопр" },
                new Question { Id = 4, Text = "Введите дату рождения", DataType = "date" },
                new Question { Id = 5, Text = "Введите семейное положение", DataType = "enum", 
                    Enumeration = "холост/не замужем;женат/замужем;разведен/а" },
                new Question { Id = 6, Text = "Любите ли вы программировать", DataType = "checkbox" }
                );
        }
    }
}
