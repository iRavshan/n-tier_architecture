using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetById(Guid Id);
        Task<bool> Create(Post post);
        bool Update(Post post);
        Task<bool> Delete(Guid Id);
        Task CompleteAsync();
    }
}
