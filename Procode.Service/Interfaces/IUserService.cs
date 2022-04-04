using Procode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetById(Guid Id);
        Task<IEnumerable<UserViewModel>> GetAll();
        void Update(UserViewModel model);
        Task<bool> Delete(Guid Id);

    }
}
