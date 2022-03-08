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
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository repoManager;

        public FeedbackService(IFeedbackRepository repoManager)
        {
            this.repoManager = repoManager;
        }
        public async Task Create(FeedbackViewModel model)
        {
            await repoManager.Create((Feedback)model);
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

        public async Task<IEnumerable<FeedbackViewModel>> GetAll() =>
            (await repoManager.GetAll()).Select(w => (FeedbackViewModel)w);

        public async Task<FeedbackViewModel> GetById(Guid Id) =>
            (FeedbackViewModel)await repoManager.GetById(Id);

        public async Task<bool> isDelete(Guid Id)
        {
            bool response = await repoManager.isDelete(Id);
            if (response)
            {
                await repoManager.CompleteAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> isRead(Guid Id)
        {
            bool response = await repoManager.isRead(Id);
            if (response)
            {
                await repoManager.CompleteAsync();
                return true;
            }
            return false;
        }
    }
}
