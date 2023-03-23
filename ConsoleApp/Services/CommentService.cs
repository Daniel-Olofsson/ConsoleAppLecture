using ConsoleApp.Context;
using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services;

internal class CommentService
{
    private readonly DataContext _context = new DataContext();
    private readonly CaseService _caseService = new CaseService();
    public async Task CreateAsync(CommentEntity commentEntity)
    {
        if(await _context.Cases.AnyAsync(x => x.Id == commentEntity.CaseId)) {
            _context.Add(commentEntity);
            await _context.SaveChangesAsync();
        }
        
    }
    public async Task<IEnumerable<CommentEntity>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }


}
