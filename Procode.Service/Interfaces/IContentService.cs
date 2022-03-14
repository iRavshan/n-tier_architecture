using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Procode.Domain;
using Procode.ViewModel;

namespace Procode.Service.Interfaces
{
    public interface IContentService
    { 
        Task Create(ContentViewModel model);
        Task Update(ContentViewModel model);
        Task<bool> Delete(Guid Id);
        Task<IEnumerable<ContentViewModel>> GetAll();
        Task<ContentViewModel> GetById(Guid Id);
        Task<IEnumerable<ContentViewModel>> LastContents(int count);
        Task<ContentViewModel> LastContent();
    }
}
