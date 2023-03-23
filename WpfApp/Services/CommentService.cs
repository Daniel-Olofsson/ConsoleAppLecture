using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfApp.Context;

namespace ConsoleApp.Services;

internal class CommentService
{
    private readonly DataContext _context = new DataContext();
    private readonly CaseService _caseService = new CaseService();
    public async Task CreateAsync(CommentEntity commentEntity)
    {
        if (await _caseService.GetAsync(x => x.Id == commentEntity.CaseId) != null)
        {
            _context.Add(commentEntity);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<CommentEntity>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }


}
