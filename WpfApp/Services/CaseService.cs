﻿using ConsoleApp.Models.Entities;
using ConsoleApp.Services;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using WpfApp.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

internal class CaseService
{
    private readonly DataContext _context = new DataContext();
    private readonly StatusService _statusService = new StatusService();
    private readonly CustomerService _customerService = new CustomerService();
    public async Task<bool> CreateAsync(CaseEntity caseEntity)
    {
        if (await _customerService.GetAsync(customerEntity => customerEntity.Id == caseEntity.CustomerId) != null && await _statusService.GetAsync(statusEntity => statusEntity.Id == caseEntity.StatusId) != null)
        {
            _context.Add(caseEntity);
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
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
    public async Task<IEnumerable<CaseEntity>> GetAllAsync(Expression<Func<CaseEntity, bool>> predicate)
    {
        return await _context.Cases
            .Include(x => x.Customer)
            .Include(x => x.Status)
            .Include(x => x.Comments)
            .OrderByDescending(x => x.Created)
            .Where(predicate)
            .ToListAsync();
    }
    public async Task<CaseEntity> GetAsync(Expression<Func<CaseEntity, bool>> predicate)
    {
        var _caseEntity = await _context.Cases
            .Include(x => x.Customer)
            .Include(x => x.Status)
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(predicate);
        return _caseEntity!;
    }
    public async Task<CaseEntity> UpdateCaseInfoAsync(Expression<Func<CaseEntity, bool>> predicate, CaseEntity updatedCaseEntity)
    {
        var _caseEntity = await _context.Cases.FirstOrDefaultAsync(predicate);
        if (_caseEntity != null)
        {
            _caseEntity.Description = updatedCaseEntity.Description;
            _caseEntity.CustomerId = (await _customerService.CreateAsync(updatedCaseEntity.Customer)).Id;
            _caseEntity.Modified = DateTime.Now;
        }
        return _caseEntity!;
    }
    public async Task<CaseEntity> UpdateCaseStatusAsync(Expression<Func<CaseEntity, bool>> predicate)
    {
        var _caseEntity = await _context.Cases.FirstOrDefaultAsync(predicate);
        if (_caseEntity != null)
        {
            switch (_caseEntity.StatusId)
            {
                case 1:
                    _caseEntity.StatusId = 2;
                    _caseEntity.Modified = DateTime.Now;
                    break;
                case 2:
                    _caseEntity.StatusId = 3;
                    _caseEntity.Modified = DateTime.Now;
                    break;
                case 3:
                    _caseEntity.StatusId = 2;
                    _caseEntity.Modified = DateTime.Now;
                    break;

            }
            _context.Update(_caseEntity);
            await _context.SaveChangesAsync();

        }
        return _caseEntity!;

    }
}
