using Microsoft.EntityFrameworkCore;
using Procode.Data.Interfaces;
using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext dbContext;

        public PostRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
           await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Create(Post post)
        {
            await dbContext.Posts.AddAsync(post);
            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var item = await dbContext.Posts.FindAsync(Id);

            if (item != null)
            {
                dbContext.Posts.Remove(item);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await dbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetById(Guid Id)
        {
            return await dbContext.Posts.FindAsync(Id);
        }

        public bool Update(Post post)
        {
            var item = dbContext.Posts.Attach(post);
            item.State = EntityState.Modified;
            return true;
        }
    }
}
