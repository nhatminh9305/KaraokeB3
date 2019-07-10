using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace B3.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions <DatabaseContext> options) : base(options)
        {
        }
        public DbSet<NewModel> News { get; set; }
        public DbSet<MediaModel> Medias { get; set; }
        public DbSet<ConfigModel> Configs { get; set; }
        public DbSet<SlideModel> Slides { get; set; }
        public DbSet<ContactModel> Contact { get; set; }
        public DbSet<UserModel> User { get; set; }
        

    }
}
