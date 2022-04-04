using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid Id);
        Task<IEnumerable<User>> GetAll();
        void Update(User user);
        Task<bool> Delete(Guid Id);
        Task CompleteAsync();
    }
}
