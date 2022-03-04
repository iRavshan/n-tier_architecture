using Procode.Data.Interfaces;
using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public Task<bool> Create(Feedback content)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Feedback> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Feedback content)
        {
            throw new NotImplementedException();
        }
    }
}
