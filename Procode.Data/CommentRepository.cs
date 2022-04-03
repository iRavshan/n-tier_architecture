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
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Create(Comment comment)
        {
            await dbContext.Comments.AddAsync(comment);
            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var comment = await dbContext.Comments.FindAsync(Id);

            if(comment is not null)
            {
                dbContext.Comments.Remove(comment);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await dbContext.Comments.ToListAsync();
        }

        public async Task<Comment> GetById(Guid Id)
        {
            return await dbContext.Comments.FindAsync(Id);
        }

        public bool Update(Comment comment)
        {
            var item = dbContext.Comments.Attach(comment);
            item.State = EntityState.Modified;
            return true;
        }
    }
}
