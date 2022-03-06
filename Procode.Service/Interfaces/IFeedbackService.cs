using Procode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Service.Interfaces
{
    public interface IFeedbackService
    {
        Task Create(FeedbackViewModel model);
        Task<bool> Delete(Guid Id);
        Task<IEnumerable<FeedbackViewModel>> GetAll();
        Task<FeedbackViewModel> GetById(Guid Id);
    }
}
