using AutoMapper;
using Exam.Application.DTOs;
using Exam.Application.Interfaces;
using Exam.Domain.Common;
using Exam.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly IServiceBase<LeagueDto, League> _service;

        public LeagueController(IServiceBase<LeagueDto, League> service)
            => _service = service;   

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParam param, CancellationToken token)
        {
            try
            {
                return Ok(await _service.GetPaged(param, token));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute, Range(0, long.MaxValue)] long id, CancellationToken token)
        {
            try
            {
                var data = await _service.GetbyKey(token, id);
                return data is not null ? Ok(data) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LeagueDto league, CancellationToken token)
        {
            try
            {
                if (await _service.Exist(league.Id))
                    return Conflict();

                await _service.Add(league, token);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute, Range(0,long.MaxValue)] long id, 
                                                [FromBody] LeagueDto league, CancellationToken token)
        {
            try
            {
                if (id != league.Id)
                    return BadRequest();

                await _service.Update(token, league, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute, Range(0,long.MaxValue)] long id,  CancellationToken token)
        {
            try
            {
                if (await _service.Exist(id))
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
