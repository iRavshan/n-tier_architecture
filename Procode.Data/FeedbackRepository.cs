﻿using Microsoft.EntityFrameworkCore;
using Procode.Data.Interfaces;
using Procode.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procode.Data
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext dbContext;

        public FeedbackRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Create(Feedback content)
        {
            await dbContext.Feedbacks.AddAsync(content);
            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            var item = await dbContext.Feedbacks.FindAsync(Id);
            if(item != null)
            {
                dbContext.Feedbacks.Remove(item);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Feedback>> GetAll()
        {
            return await dbContext.Feedbacks.ToListAsync(); 
        }

        public async Task<Feedback> GetById(Guid Id)
        {
            return await dbContext.Feedbacks.FindAsync(Id);
        }

        public bool Update(Feedback content)
        {
            var item = dbContext.Feedbacks.Attach(content);
            item.State = EntityState.Modified;
            return true;
        }
    }
}
