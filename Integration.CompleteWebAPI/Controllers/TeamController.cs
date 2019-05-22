using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Integration.CompleteWebAPI.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private Repositories.ITeamRepository _teamRepository;

        public TeamController(Repositories.ITeamRepository teamRepository)
        {
            this._teamRepository = teamRepository
                ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var result = await _teamRepository.GetTeamsAsync();

            return Ok(result);
        }
    }
}