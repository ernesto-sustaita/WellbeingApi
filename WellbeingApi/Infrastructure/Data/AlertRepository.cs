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

using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AlertRepository : IAlertRepository
    {
        private readonly ApplicationDbContext _context;
        public AlertRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Alert>> GetAllAsync()
        {
            return await _context.Alert
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Alert> GetByIdAsync(int id)
        {
            return await _context.Alert
                    .Where(filter => filter.Id == id)
                    .AsNoTracking()
                    .FirstAsync();
        }

        public async Task<Alert> SaveAsync(Alert alert)
        {
            await _context.Alert.AddAsync(alert);
            await _context.SaveChangesAsync();

            return alert;
        }

        public async Task<Alert> UpdateAsync(Alert alert)
        {
            _context.Alert.Update(alert);
            await _context.SaveChangesAsync();

            return alert;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            Alert? Alert = await _context.Alert.Where(filter => filter.Id == id).FirstOrDefaultAsync();
            
            if(Alert is not null)
            {
                _context.Alert.Remove(Alert);
                await _context.SaveChangesAsync();

                return true;
            }
            else
                return false;
            
        }
    }
}