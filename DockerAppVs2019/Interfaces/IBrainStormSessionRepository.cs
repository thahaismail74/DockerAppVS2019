using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerAppVs2019.Models;

namespace DockerAppVs2019.Interfaces
{
    public interface IBrainstormSessionRepository
    {
        Task<BrainstormSession> GetByIdAsync(int id);
        Task<List<BrainstormSession>> ListAsync();
        Task AddAsync(BrainstormSession session);
        Task UpdateAsync(BrainstormSession session);
    }
}
