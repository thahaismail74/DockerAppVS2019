﻿using DockerAppVs2019.Interfaces;
using DockerAppVs2019.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAppVs2019.Infrastructure
{
    public class BrainstormSessionRepository
    {
        public class EFStormSessionRepository : IBrainstormSessionRepository
        {
            private readonly AppDbContext _dbContext;

            public EFStormSessionRepository(AppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<BrainstormSession> GetByIdAsync(int id)
            {
                return _dbContext.BrainstormSessions
                    .Include(s => s.Ideas)
                    .FirstOrDefaultAsync(s => s.Id == id);
            }

            public Task<List<BrainstormSession>> ListAsync()
            {
                return _dbContext.BrainstormSessions
                    .Include(s => s.Ideas)
                    .OrderByDescending(s => s.DateCreated)
                    .ToListAsync();
            }

            public Task AddAsync(BrainstormSession session)
            {
                _dbContext.BrainstormSessions.Add(session);
                return _dbContext.SaveChangesAsync();
            }

            public Task UpdateAsync(BrainstormSession session)
            {
                _dbContext.Entry(session).State = EntityState.Modified;
                return _dbContext.SaveChangesAsync();
            }
        }
    }
}