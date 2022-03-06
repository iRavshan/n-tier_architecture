using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Procode.Domain;
using Procode.ViewModel;

namespace Procode.Service.Interfaces
{
    public interface IContentService
    {
        void Create(ContentViewModel model);
        void Update(ContentViewModel model);
        void Delete(Guid Id);
        Task<IEnumerable<ContentViewModel>> GetAll();
        Task<ContentViewModel> GetById(Guid Id);
        Task<IEnumerable<ContentViewModel>> LastContents(int count);

    }
}
