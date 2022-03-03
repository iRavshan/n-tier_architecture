using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    public interface ISpeakerRepository
    {
        IEnumerable<Speaker> GetAll();
        Task<Speaker> GetById(Guid Id);
        Task<bool> Create(Speaker content);
        Task<bool> Update(Speaker content);
        Task<bool> Delete(Guid Id);
    }
}
