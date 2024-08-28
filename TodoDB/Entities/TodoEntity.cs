using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDB.Entities
{
    public class TodoEntity
    {
        public int Id { get; set; }

        public string Task { get; set; } = null!;

        public bool Iscompleted { get; set; }

        public string CreatedUserId { get; set; } = null!;

        public DateTime CreatedDateTime { get; set; }

        public string ModifieduserId { get; set; } = null!;

        public DateTime ModifiedDateTime { get; set; }
    }
}

