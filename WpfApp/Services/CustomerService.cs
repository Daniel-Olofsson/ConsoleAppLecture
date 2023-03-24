using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Context;

namespace ConsoleApp.Services;

internal class CustomerService
{
    private readonly DataContext _context = new DataContext();
    public async Task<CustomerEntity> CreateAsync(CustomerEntity customerEntity)
    {
        var _customerEntity = await _context.Customers.FirstOrDefaultAsync(x=> x.Email == customerEntity.Email);
        if(_customerEntity == null )
        {
            _customerEntity = customerEntity;
            _context.Add(_customerEntity);
            await _context.SaveChangesAsync();
        }
        return _customerEntity;
    }
    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }
    public async Task<CustomerEntity> GetAsync(Expression<Func<CustomerEntity, bool>> predicate)
    {
        var _customerEntity = await _context.Customers.FirstOrDefaultAsync(predicate);

        return _customerEntity!;
    }
}
