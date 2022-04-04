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
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepos;

        public UserService(IUserRepository userRepos)
        {
            this.userRepos = userRepos;
        }

        public async Task<bool> Delete(Guid Id)
        {
            if (await userRepos.Delete(Id))
            {
                await userRepos.CompleteAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll() =>
             (await userRepos.GetAll()).Select(w => (UserViewModel)w);

        public async Task<UserViewModel> GetById(Guid Id) =>
            (UserViewModel)(await userRepos.GetById(Id));

        public void Update(UserViewModel model)
        {
            userRepos.Update((User)model);
            userRepos.CompleteAsync();
        }
    }
}
