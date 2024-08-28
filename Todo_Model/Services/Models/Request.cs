using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_Services.Services.Models
{
   public class TodoRequest
    {

        public int Id { get; set; }
        public string Task { get; set; } = null!;

        public bool Iscompleted { get; set; }

      
    }
}
