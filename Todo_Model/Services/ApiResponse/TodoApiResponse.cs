using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_Services.Services.Models;

namespace Todo_Services.Services.ApiResponse
{
    public class TodoApiResponse
    {
        public int statusCode {  get; set; }
        public bool IsSuccess {  get; set; }
        public Todoresponse todoApiResponse { get; set; }
    }
}
