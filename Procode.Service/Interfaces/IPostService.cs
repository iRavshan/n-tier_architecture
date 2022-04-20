using Procode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Service.Interfaces
{
    public interface IPostService
    {
        Task Create(PostViewModel model);
        Task Update(PostViewModel model);
        Task<bool> Delete(Guid Id);
        Task<IEnumerable<PostViewModel>> GetAll();
        Task<PostViewModel> GetById(Guid Id);
        Task<IEnumerable<PostViewModel>> LastContents(int count);
        Task<PostViewModel> LastContent();
    }
}
