using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAll();
        Task<Comment> GetById(Guid Id);
        Task<bool> Create(Comment comment);
        bool Update(Comment comment);
        Task<bool> Delete(Guid Id);
        Task CompleteAsync();
    }
}
