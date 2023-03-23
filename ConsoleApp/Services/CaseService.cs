using ConsoleApp.Context;
using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services;

internal class CaseService
{
    private readonly DataContext _context = new DataContext();
    private readonly StatusService _statusService = new StatusService();
    private readonly CustomerService _customerService = new CustomerService();
    public async Task<CaseEntity> CreateAsync(CaseEntity caseEntity)
    {
        var customer = await _customerService.GetAsync(x => x.Id == caseEntity.CustomerId);
        var statuses = await _statusService.GetAllAsync();
        if (customer != null && statuses != null && statuses.Any())
        {
            _context.Add(caseEntity);
            await _context.SaveChangesAsync();
        }
        return caseEntity;

    }
        public async Task<IEnumerable<CaseEntity>> GetAllAsync()
    {
        return await _context.Cases
            .Include(x => x.Customer)
            .Include(x => x.Status)
            .Include(x => x.Comments)
            .OrderByDescending(x => x.Created)
            .ToListAsync();
    }
    public async Task<CaseEntity> GetAsync(Expression<Func<CaseEntity, bool>> predicate)
    {
        var _caseEntity = await _context.Cases
            .Include(x => x.Customer)
            .Include(x => x.Status)
            .Include(x=> x.Comments)
            .FirstOrDefaultAsync(predicate);
        return _caseEntity!;
    }
    public async Task<CaseEntity> UpdateCaseAsync(Expression<Func<CaseEntity, bool>> predicate, CaseEntity updatedCaseEntity)
    {
        var _caseEntity = await _context.Cases.FirstOrDefaultAsync(predicate);
        if (_caseEntity != null)
        {
            _caseEntity.Description = updatedCaseEntity.Description;
            _caseEntity.CustomerId = updatedCaseEntity.CustomerId;
            _caseEntity.Modified = DateTime.Now;
        }
        return _caseEntity!;
    }
    public async Task<CaseEntity> UpdateStatusAsync(Expression<Func<CaseEntity, bool>> predicate)
    {
        var _caseEntity = await _context.Cases.FirstOrDefaultAsync(predicate);
        if (_caseEntity != null)
        {
            switch (_caseEntity.StatusId, _caseEntity.Modified)
            {
                case 1: _caseEntity.StatusId = 2;
                    _caseEntity.Modified = DateTime.Now;
                        break;
                case 2: _caseEntity.StatusId = 3;
                    _caseEntity.Modified = DateTime.Now;
                        break;
                case 3: _caseEntity.StatusId = 2;
                    _caseEntity.Modified = DateTime.Now;
                        break;
                
            }
            _context.Update(_caseEntity);
            await _context.SaveChangesAsync();

        }
        return _caseEntity!;

    }
}
