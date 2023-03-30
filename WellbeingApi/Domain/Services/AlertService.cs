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
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class AlertService : IAlertService
    {
        private readonly IAlertRepository _alertRepository;

        public AlertService(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _alertRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Alert>> GetAllAsync()
        {
            return await _alertRepository.GetAllAsync();
        }

        public async Task<Alert> GetByIdAsync(int id)
        {
            return await _alertRepository.GetByIdAsync(id);
        }

        public async Task<Alert> SaveAsync(Alert alert)
        {
            return await _alertRepository.SaveAsync(alert);
        }

        public async Task<Alert> UpdateAsync(Alert Alert)
        {
            return await _alertRepository.UpdateAsync(Alert);
        }
    }
}