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
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepos;

        public PostService(IPostRepository postRepos)
        {
            this.postRepos = postRepos;
        }

        public async Task Create(PostViewModel model)
        {
            await postRepos.Create((Post)model);
            await postRepos.CompleteAsync();
        }

        public async Task<bool> Delete(Guid Id)
        {
            if (await postRepos.Delete(Id))
            {
                await postRepos.CompleteAsync();
                return true;
            }
                
            return false;
        }

        public async Task<IEnumerable<PostViewModel>> GetAll() =>
            (await postRepos.GetAll()).Select(w => (PostViewModel)w);

        public async Task<PostViewModel> GetById(Guid Id) =>
            (PostViewModel)await postRepos.GetById(Id);

        public async Task<PostViewModel> LastContent()
        {
            var items = Enumerable.Reverse(await postRepos.GetAll());

            return (PostViewModel)items.First();
        }

        public async Task<IEnumerable<PostViewModel>> LastContents(int count)
        {
            var items = Enumerable.Reverse(await postRepos.GetAll());

            return items.Take(count).Select(w => (PostViewModel)w);
        }

        public async Task Update(PostViewModel model)
        {
            postRepos.Update((Post)model);
            await postRepos.CompleteAsync();
        }
    }
}
