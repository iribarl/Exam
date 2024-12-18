using Exam.Application.DTOs;
using Exam.Application.Interfaces;
using Exam.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly IServiceBase<SportDto, Sport> _service;

        public SportController(IServiceBase<SportDto, Sport> service) 
            => _service = service; 

       
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            try
            {
                return Ok(await _service.GetAll(token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute, Range(0, int.MaxValue)] int id, CancellationToken token)
        {
            try
            {
                var data = await _service.GetbyKey(token, id);
                
                if(data is not null)
                    return Ok(data);

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SportDto sport, CancellationToken token)
        {
            try
            {
                var data = await _service.GetbyKey(token, sport.Id);
                
                if (data is not null)
                    return Conflict(data);

                await _service.Add(sport, token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SportDto sport, CancellationToken token)
        {
            try
            {
                if (id != sport.Id) 
                    return BadRequest();

                await _service.Update(token, sport, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            try
            {
                var data = await _service.GetbyKey(token, id);
                
                if (data is not null)
                {
                    await _service.RemoveByKey(token, id);
                    return NoContent();
                }                  

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
