using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.Entities;

internal class StatusEntity
{
    public StatusEntity() 
    {
        StatusName  = null!;
        Cases  = new HashSet<CaseEntity>();
    } 
    public int Id { get; set; }
    public string StatusName { get; set; }
    public ICollection<CaseEntity> Cases { get; set; }
}
