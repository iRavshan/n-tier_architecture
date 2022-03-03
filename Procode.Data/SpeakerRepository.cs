using Procode.Data.Interfaces;
using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly AppDbContext dbContext;

        public SpeakerRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Create(Speaker speaker)
        {
            await dbContext
        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Speaker> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Speaker> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Speaker speaker)
        {
            throw new NotImplementedException();
        }
    }
}
