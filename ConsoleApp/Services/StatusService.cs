using ConsoleApp.Context;
using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services;

internal class StatusService
{
    private readonly DataContext _context = new DataContext();
    public async Task<StatusEntity> GetOrCreateAsync(string statusName)
    {
        var _statusEntity = await _context.Statuses.FirstOrDefaultAsync(x => x.StatusName == statusName);
        if (_statusEntity == null)
        {
            _statusEntity = new StatusEntity { StatusName = statusName };
            await _context.AddAsync(_statusEntity);
            await _context.SaveChangesAsync();
        }

        return _statusEntity;
    }

    public async Task<IEnumerable<StatusEntity>> GetAllAsync()
    {
        return await _context.Statuses.ToListAsync();
    }
    public async Task InitializeAsync()
    {
        if (!await _context.Statuses.AnyAsync())
        {
            var statuses = new List<StatusEntity>()
            {
                new StatusEntity() { StatusName = "Non active"},
                new StatusEntity() { StatusName = "Active"},
                new StatusEntity() {StatusName = "Ended"}
            };
            _context.Add(statuses); 
            await _context.SaveChangesAsync();

        }
    }
    

}

