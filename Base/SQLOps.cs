using Microsoft.EntityFrameworkCore;
using PersonalBlogMVC.Models;

namespace PersonalBlogMVC.Base
{
    public static class SQLOps
    {
        public static List<PostModel> GetPostList()
        {
            using (var db = new BlogDbContext())
            {
                var _posts = db.Post
                    .OrderBy(x => x.Id)
                    .ToList();
                return _posts;
            }
        }
        public static PostModel GetPost(int PostId)
        {
            using (var db = new BlogDbContext())
            {
                var _post = db.Post
                    .Single(a => a.Id == PostId);
                return _post;
            }
        }

        public static AuthorModel GetAuthorById(int AuthorId)
        {
            using (var db = new BlogDbContext())
            {
                var _authors = db.Author
                    .Single(a => a.Id == AuthorId);
                return _authors;
            }
        }
    }

    public class BlogDbContext : DbContext
    {
        public DbSet<AuthorModel>? Author { get; set; }
        public DbSet<PostModel>? Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Blogg;User ID=sa;Password=tamam123");
        }

    }
}


