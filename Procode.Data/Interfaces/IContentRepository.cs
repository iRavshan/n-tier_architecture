using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    public interface IContentRepository
    {
        IEnumerable<Content> GetAll();
        Task<Content> GetById(Guid Id);
        Task<bool> Create(Content content);
        Task<bool> Update(Content content);
        Task<bool> Delete(Guid Id);
    }
}
