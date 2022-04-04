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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid Id)
        {
            var exUser = await dbContext.Users.FindAsync(Id.ToString());

            if(exUser is not null)
            {
                dbContext.Users.Remove(exUser);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<User>> GetAll() =>
            await dbContext.Users.ToListAsync();

        public async Task<User> GetById(Guid Id) =>
            await dbContext.Users.FindAsync(Id);

        public void Update(User user)
        {
            var item = dbContext.Users.Attach(user);
            item.State = EntityState.Modified;
        }
    }
}
