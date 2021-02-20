﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timewaster.Core.Entities;
using Timewaster.Core.Interfaces;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Infrastructure.DataAccess
{
    public class AsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : Entity
    {
        private readonly TimewasterDbContext _context;

        public AsyncRepository(TimewasterDbContext context) => _context = context;

        public async Task<TEntity> AddAsync(ServiceContext context, TEntity entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(ServiceContext context, TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(ServiceContext context, string id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await _context.Set<TEntity>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync(ServiceContext context, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(ServiceContext context, TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}