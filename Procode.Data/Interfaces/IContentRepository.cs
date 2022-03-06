using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    public interface IContentRepository
    {
        Task<IEnumerable<Content>> GetAll();
        Task<Content> GetById(Guid Id);
        Task<bool> Create(Content content);
        bool Update(Content content);
        Task<bool> Delete(Guid Id);
        Task CompleteAsync();
    }
}
