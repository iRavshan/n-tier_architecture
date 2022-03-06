using Procode.Data;
using Procode.Data.Interfaces;
using Procode.Domain;
using Procode.Service.Interfaces;
using Procode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Service
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository repoManager;

        public ContentService(IContentRepository repoManager)
        {
            this.repoManager = repoManager;
        }

        public async void Create(ContentViewModel model)
        {
            await repoManager.Create((Content)model);
            await repoManager.CompleteAsync();
        }

        public async void Delete(Guid Id)
        {
            await repoManager.Delete(Id);
            await repoManager.CompleteAsync();
        }

        public async Task<IEnumerable<ContentViewModel>> GetAll() => 
            (IEnumerable<ContentViewModel>)await repoManager.GetAll();

        public async Task<ContentViewModel> GetById(Guid Id) => 
            (ContentViewModel)await repoManager.GetById(Id);

        public Task<IEnumerable<ContentViewModel>> LastContents(int count)
        {
            throw new NotImplementedException();
        }

        public async void Update(ContentViewModel model)
        {
            repoManager.Update((Content)model);
            await repoManager.CompleteAsync();
        }
    }
}
