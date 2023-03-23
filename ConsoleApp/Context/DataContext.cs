using ConsoleApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Context;

internal class DataContext : DbContext
{
    public DataContext()
    {

    }

    public DataContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\livelecture\hans-lecture-6\casedb.mdf;Integrated Security=True;Connect Timeout=30");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<CaseEntity> Cases { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }
}
