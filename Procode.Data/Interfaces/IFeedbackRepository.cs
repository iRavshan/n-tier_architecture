using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data.Interfaces
{
    interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAll();
        Task<Feedback> GetById(Guid Id);
        Task<bool> Create(Feedback content);
        Task<bool> Update(Feedback content);
        Task<bool> Delete(Guid Id);
    }
}
