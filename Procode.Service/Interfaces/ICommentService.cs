using Procode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Service.Interfaces
{
    public interface ICommentService
    {
        Task Create(CommentViewModel model);
        Task Update(CommentViewModel model);
        Task<bool> Delete(Guid Id);
        Task<IEnumerable<CommentViewModel>> GetAll();
        Task<CommentViewModel> GetById(Guid Id);
    }
}
