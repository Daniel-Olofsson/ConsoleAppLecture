using ConsoleApp.Context;
using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Context;

namespace ConsoleApp.Services;

internal class StatusService
{
    private readonly DataContext _context = new DataContext();
    public async Task InitializeAsync()
    {
        if (!await _context.Statuses.AnyAsync())
        {
            var statuses = new List<StatusEntity>()
            {
                new StatusEntity() { StatusName ="Non active" },
                new StatusEntity() {StatusName ="Active"},
                new StatusEntity() {StatusName ="Ended"}
            };
            _context.Add(statuses); 
            await _context.SaveChangesAsync();

        }
    }

}

