using Microsoft.AspNetCore.Http;
using Procode.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Service.Interfaces
{
    public interface ISpeakerService
    {
        Task Create(SpeakerViewModel model);
        Task Update(SpeakerViewModel model);
        Task<bool> Delete(Guid Id);
        Task<IEnumerable<SpeakerViewModel>> GetAll();
        Task<SpeakerViewModel> GetById(Guid Id);
        Task SetImage(Guid Id, IFormFile file);
    }
}
