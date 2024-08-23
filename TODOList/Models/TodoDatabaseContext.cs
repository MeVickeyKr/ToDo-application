using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TODOList.Models;

public partial class TodoDatabaseContext : DbContext
{
    public TodoDatabaseContext()
    {
    }

    public TodoDatabaseContext(DbContextOptions<TodoDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> TodoList { get; set; }
}

  
           
