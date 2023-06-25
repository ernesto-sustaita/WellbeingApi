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
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }


        [HttpGet]
        public async Task<IEnumerable<Activity>> Get()
        {
            return await _activityService.GetAllAsync();
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<IEnumerable<Activity>> Get(DateTime startDate, DateTime endDate)
        {
            return await _activityService.GetByDateAsync(startDate,endDate);
        }

        [HttpGet("meditation/time/{startDate}/{endDate}")]
        public async Task<IEnumerable<DailyMeditationTime>> GetDailyMeditationTimeByDateIntervalAsync(DateTime startDate, DateTime endDate)
        {
            return await _activityService.GetDailyMeditationTimeByDateIntervalAsync(startDate, endDate);
        }

        [HttpGet("{id}")]
        public async Task<Activity> Get(int id)
        {
            return await _activityService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Activity> Post([FromBody] Activity activity)
        {
            return await _activityService.SaveAsync(activity);
        }

        [HttpPut("{id}")]
        public async Task<Activity> Put([FromBody] Activity activity)
        {
            return await _activityService.UpdateAsync(activity);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _activityService.DeleteByIdAsync(id);
        }
    }
}
