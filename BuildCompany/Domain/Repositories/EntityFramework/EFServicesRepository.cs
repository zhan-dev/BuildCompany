﻿using BuildCompany.Domain.Entities;
using BuildCompany.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BuildCompany.Domain.Repositories.EntityFramework
{
    public class EFServicesRepository : IServicesRepository
    {
        private readonly AppDbContext _context;
        public EFServicesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await _context.Services.Include(x => x.ServiceCategory).ToListAsync();
        }
        public async Task<Service?> GetServiceByIdAsync(int id)
        {
            return await _context.Services.Include(x => x.ServiceCategory).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task SaveServiceAsync(Service entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteServiceAsync(int id)
        {
            _context.Entry(new Service { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
