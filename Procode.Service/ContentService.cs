using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Procode.Data;
using Procode.Data.Interfaces;
using Procode.Domain;
using Procode.Service.Interfaces;
using Procode.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Service
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository repoManager;
        private readonly IWebHostEnvironment webHost;

        public ContentService(IContentRepository repoManager, IWebHostEnvironment webHost)
        {
            this.repoManager = repoManager;
            this.webHost = webHost;
        }

        public async Task Create(ContentViewModel model)
        {
            await repoManager.Create((Content)model);
            await repoManager.CompleteAsync();
        }

        public async Task<bool> Delete(Guid Id)
        {
            bool result = await repoManager.Delete(Id);

            if (result)
            {
                await repoManager.CompleteAsync();
                return true;
            }

            return false;    
        }

        public async Task<IEnumerable<ContentViewModel>> GetAll() =>
            (await repoManager.GetAll()).Select(w => (ContentViewModel)w);

        public async Task<ContentViewModel> GetById(Guid Id) => 
            (ContentViewModel)await repoManager.GetById(Id);

        public async Task<IEnumerable<ContentViewModel>> LastContents(int count)
        {
            var items = await repoManager.GetAll();

            return items.Take(count).Select(w => (ContentViewModel)w);
        }

        public async Task<ContentViewModel> LastContent()
        {
            var items = Enumerable.Reverse(await repoManager.GetAll());

            return (ContentViewModel)items.First();
        }

        public async Task Update(ContentViewModel model)
        { 
            repoManager.Update((Content)model);
            await repoManager.CompleteAsync();
        }

    }
}
