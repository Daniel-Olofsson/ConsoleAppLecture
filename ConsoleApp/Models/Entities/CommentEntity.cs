using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.Entities;

internal class CommentEntity
{
    public int Id { get; set; }
    public string Comment { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;
    public int CaseId { get; set; }
    public CaseEntity Case { get; set; } = null!;

}
