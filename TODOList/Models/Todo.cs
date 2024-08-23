using System;
using System.Collections.Generic;

namespace TODOList.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string Task { get; set; } = null!;

    public bool Iscompleted { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public string ModifieduserId { get; set; } = null!;

    public DateTime ModifiedDateTime { get; set; }
}
