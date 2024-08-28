using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoDB.Entities;

namespace TodoDBContext;

public partial class TodoDatabaseContext : DbContext
{
   

    public TodoDatabaseContext()
    {
    }

    public TodoDatabaseContext(DbContextOptions<TodoDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoEntity> TodoList { get; set; }
}

  
           
