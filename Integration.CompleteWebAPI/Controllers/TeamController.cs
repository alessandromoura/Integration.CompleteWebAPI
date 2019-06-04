using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Integration.CompleteWebAPI.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private Repositories.ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamController(Repositories.ITeamRepository teamRepository, IMapper mapper)
        {
            this._teamRepository = teamRepository
                ?? throw new ArgumentNullException(nameof(teamRepository));
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var result = await _teamRepository.GetTeamsAsync();

            return Ok(_mapper.Map<List<Models.TeamDto>>(result));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeam(Guid id)
        {
            var teamEntity = await _teamRepository.GetTeamAsync(id);
            if (teamEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Models.TeamDto>(teamEntity));
        }
    }
}