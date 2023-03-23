using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.Entities;

internal class CaseEntity
{
    public CaseEntity() 
    {
        Description = null!;
        Created = DateTime.Now;
        Modified = DateTime.Now;
        StatusId = 1;
        Status = null!;
        Customer = new CustomerEntity();

    }
    public int Id { get; set; }
    //public string Titel { get; set; }
    public string Description { get; set; } 
    public DateTime Created { get; set; } 
    public DateTime Modified { get; set; }
    public int StatusId { get; set; }
    public StatusEntity Status { get; set; }
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; }
    public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
}
