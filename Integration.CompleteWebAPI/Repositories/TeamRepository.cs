using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.CompleteWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Integration.CompleteWebAPI.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Entities.TeamEntity>> GetTeamsAsync();
        Task<Entities.TeamEntity> GetTeamAsync(Guid id);
        Task<bool> CreateTeamAsync(Entities.TeamEntity team);
        Task<Entities.TeamEntity> UpdateTeamAsync(Entities.TeamEntity team);
        Task<bool> DeleteTeamAsync(Guid id);
    }

    public class TeamRepository : ITeamRepository, IDisposable
    {
        private ChampionshipDbContext _context;

        public TeamRepository(ChampionshipDbContext context)
        {
            this._context = context;
        }
        public Task<bool> CreateTeamAsync(TeamEntity team)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeamAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TeamEntity> GetTeamAsync(Guid id)
        {
            return await _context.Teams.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TeamEntity>> GetTeamsAsync()
        {
            return await _context.Teams.ToListAsync().ConfigureAwait(false); 
        }

        public Task<TeamEntity> UpdateTeamAsync(TeamEntity team)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

    }
}
