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
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository repoManager;

        public SpeakerService(ISpeakerRepository repoManager)
        {
            this.repoManager = repoManager;
        }

        public async Task Create(SpeakerViewModel model)
        {
            await repoManager.Create((Speaker)model);
            await repoManager.CompleteAync();
        }

        public async Task<bool> Delete(Guid Id)
        {
            bool result = await repoManager.Delete(Id);

            if (result)
            {
                await repoManager.CompleteAync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<SpeakerViewModel>> GetAll() =>
            (await repoManager.GetAll()).Select(w => (SpeakerViewModel)w);

        public async Task<SpeakerViewModel> GetById(Guid Id) =>
            (SpeakerViewModel)await repoManager.GetById(Id);

        public async Task Update(SpeakerViewModel model)
        {
            repoManager.Update((Speaker)model);
            await repoManager.CompleteAync();
        }
    }
}
