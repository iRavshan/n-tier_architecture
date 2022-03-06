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
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly AppDbContext dbContext;

        public SpeakerRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CompleteAync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Create(Speaker content)
        {
            await dbContext.Speakers.AddAsync(content);
            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var item = await dbContext.Speakers.FindAsync(Id);

            if(item != null)
            {
                dbContext.Speakers.Remove(item);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Speaker>> GetAll()
        {
            return await dbContext.Speakers.ToListAsync();
        }

        public async Task<Speaker> GetById(Guid Id)
        {
            return await dbContext.Speakers.FindAsync(Id);
        }

        public bool Update(Speaker content)
        {
            var item = dbContext.Speakers.Attach(content);
            item.State = EntityState.Modified;
            return true;
        }
    }
}
