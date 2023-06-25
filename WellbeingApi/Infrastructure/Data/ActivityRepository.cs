/*
MIT License

Copyright (c) 2022 Luis Ernesto Sustaita Loera

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using Domain.Dto;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _context;
        public ActivityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activity
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<IEnumerable<Activity>> GetByDateAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Activity
                    .Where(filter => filter.CreatedDate >= startDate && filter.CreatedDate <= endDate)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<IEnumerable<DailyMeditationTime>> GetDailyMeditationTimeByDateIntervalAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Activity
                    .Where(filter => filter.CreatedDate >= startDate && filter.CreatedDate <= endDate)
                    .GroupBy(group => group.CreatedDate.Date)
                    .Select(fields => new DailyMeditationTime { Date = fields.Key.Date, TotalTime = fields.Sum(m => m.Duration) })
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Activity> GetByIdAsync(int id)
        {
            return await _context.Activity
                    .Where(filter => filter.Id == id)
                    .AsNoTracking()
                    .FirstAsync();
        }

        public async Task<Activity> SaveAsync(Activity activity)
        {
            await _context.Activity.AddAsync(activity);
            await _context.SaveChangesAsync();

            return activity;
        }

        public async Task<Activity> UpdateAsync(Activity activity)
        {
            _context.Activity.Update(activity);
            await _context.SaveChangesAsync();

            return activity;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            Activity? activity = await _context.Activity.Where(filter => filter.Id == id).FirstOrDefaultAsync();
            
            if(activity is not null)
            {
                _context.Activity.Remove(activity);
                await _context.SaveChangesAsync();

                return true;
            }
            else
                return false;
            
        }
    }
}