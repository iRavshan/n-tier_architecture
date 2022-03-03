using Procode.Data.Interfaces;
using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<bool> Create(Content content)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Content> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Content> GetById(Guid Id)
        {
            
        }

        public Task<bool> Update(Content content)
        {
            
        }
    }
}
