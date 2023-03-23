using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.Entities;

[Index(nameof(Email), IsUnique = true)]
internal class CustomerEntity
{
    public CustomerEntity() 
    { 
        CustomerName = null!;
        Email = null!;
        Cases = new HashSet<CaseEntity>();
    }

    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; } 
    public ICollection<CaseEntity> Cases { get; set; }
}
