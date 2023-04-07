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
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Question>> Get()
        {
            return await _questionService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Question> Get(int id)
        {
            return await _questionService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<Question> Post([FromBody] Question question)
        {
            return await _questionService.SaveAsync(question);
        }

        [HttpPut("{id}")]
        public async Task<Question> Put([FromBody] Question question)
        {
            return await _questionService.UpdateAsync(question);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _questionService.DeleteByIdAsync(id);
        }
    }
}
