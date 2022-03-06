using Microsoft.EntityFrameworkCore;
using Procode.Data.Interfaces;
using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procode.Data
{
    public class ContentRepository : IContentRepository
    {
        private readonly AppDbContext dbContext;

        public ContentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Create(Content content)
        {
            await dbContext.Contents.AddAsync(content);
            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var item = await dbContext.Contents.FindAsync(Id);

            if(item != null)
            {
                dbContext.Contents.Remove(item);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Content>> GetAll()
        {
            return await dbContext.Contents.ToListAsync();
        }

        public async Task<Content> GetById(Guid Id)
        {
            return await dbContext.Contents.FindAsync(Id);
        }

        public bool Update(Content content)
        {
            var item = dbContext.Contents.Attach(content);
            item.State = EntityState.Modified;
            return true;
        }
    }
}
