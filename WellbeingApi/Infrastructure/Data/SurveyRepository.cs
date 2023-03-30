/*
MIT License

Copyright (c) 2023 Luis Ernesto Sustaita Loera

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

using Domain.Entities;
using System.Data.Entity;

namespace Infrastructure.Data
{
    public class SurveyRepository
    {
        private readonly ApplicationDbContext _context;
        public SurveyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Survey>> GetAllAsync()
        {
            return await _context.Survey
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Survey> GetByIdAsync(int id)
        {
            return await _context.Survey
                    .Where(filter => filter.Id == id)
                    .AsNoTracking()
                    .FirstAsync();
        }

        public async Task<Survey> SaveAsync(Survey activity)
        {
            await _context.Survey.AddAsync(activity);
            await _context.SaveChangesAsync();

            return activity;
        }

        public async Task<Survey> UpdateAsync(Survey activity)
        {
            _context.Survey.Update(activity);
            await _context.SaveChangesAsync();

            return activity;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            Survey? survey = await _context.Survey.Where(filter => filter.Id == id).FirstOrDefaultAsync();

            if (survey is not null)
            {
                _context.Survey.Remove(survey);
                await _context.SaveChangesAsync();

                return true;
            }
            else
                return false;

        }
    }
}
