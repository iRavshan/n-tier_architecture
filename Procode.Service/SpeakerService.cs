﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository repoManager;
        private readonly IWebHostEnvironment webHost;

        public SpeakerService(ISpeakerRepository repoManager, IWebHostEnvironment webHost)
        {
            this.repoManager = repoManager;
            this.webHost = webHost;
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

        public async Task SetImage(Guid Id, IFormFile file)
        {
            var speaker = await repoManager.GetById(Id);

            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string path = Path.Combine(webHost.WebRootPath, $"Images/Speakers/{fileName}");
            FileStream fileStream = File.Open(path, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fileStream);

            if (!string.IsNullOrEmpty(speaker.PhotoUrl))
            {
                File.Delete(path);
            }

            await fileStream.FlushAsync();
            fileStream.Close();

            speaker.PhotoUrl = fileName;
            await repoManager.CompleteAync();
        }
    }
}
