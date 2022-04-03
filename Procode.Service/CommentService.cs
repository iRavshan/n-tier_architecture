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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepo;

        public CommentService(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        public async Task Create(CommentViewModel model)
        {
            await commentRepo.Create((Comment)model);
            await commentRepo.CompleteAsync();
        }
            
        public async Task<bool> Delete(Guid Id)
        {
            if(await commentRepo.Delete(Id))
            {
                await commentRepo.CompleteAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<CommentViewModel>> GetAll() =>
            (await commentRepo.GetAll()).Select(w => (CommentViewModel)w);

        public async Task<CommentViewModel> GetById(Guid Id) =>
            (CommentViewModel)(await commentRepo.GetById(Id));

        public async Task Update(CommentViewModel model)
        {
            commentRepo.Update((Comment)model);
            await commentRepo.CompleteAsync();
        }

    }
}
